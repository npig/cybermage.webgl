using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

namespace Cybermage.Common
{
    public static class ObjectSpawner
    {
        private static List<Vector3> _availablePositions;
        private static List<Vector3> _usedPositions;
        private static Transform _spawnTransform;
        
        private static void Initialise()
        {
            _spawnTransform = MonoBehaviour.Instantiate(CM_Resources.prefabs.pickupSpawns.Load()).transform;
            _availablePositions = new List<Vector3>();
            _usedPositions = new List<Vector3>();
            
            foreach (Transform child in _spawnTransform)
            {
                _availablePositions.Add(child.transform.position);        
            }

            Reset();
        }

        public static void Update()
        {
            if(GlobalsConfig.GameState != GameState.Active)
                return;

            int j = GlobalsConfig.Difficulty - GlobalsConfig.MobileCollection.Count;

            if (j > 0)
            {
                Scene mainScene = SceneManager.GetSceneByName("_level");
                
                if(SceneManager.GetActiveScene() != mainScene)
                    SceneManager.SetActiveScene(mainScene);
                
                for (int i = 0; i < j; i++)
                {
                    EntityFactory.SpawnZombie(GetSpawnPosition());
                }
            }

        }

        private static void Reset()
        {
            _availablePositions.AddRange(_usedPositions);
            _usedPositions = new List<Vector3>();
            _availablePositions = RandomOrder(_availablePositions);
        }

        private static List<Vector3> RandomOrder(List<Vector3> scratch)
        {
            Random r = new Random();

            for (int i = scratch.Count - 1; i > 0; i--)
            {
                int j = r.Next(0, i+1);
                Vector3 temp = scratch[i]; 
                scratch[i] = scratch[j]; 
                scratch[j] = temp;
            }

            return scratch;
        }

        public static Vector3 GetSpawnPosition()
        {
            if(_availablePositions == null)
                Initialise();
            
            if (_availablePositions.Count == 0)
                Reset();

            Vector3 result = _availablePositions[0];
            _availablePositions.RemoveAt(0);
            _usedPositions.Add(result);
            return result;
        }

        public static void SpawnPickup()
        {
            Pickup pickup = MonoBehaviour.Instantiate(CM_Resources.prefabs.pickup.Load(), GetSpawnPosition(), Quaternion.identity).GetComponent<Pickup>();
        }
    }
}