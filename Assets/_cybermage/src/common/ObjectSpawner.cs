using System.Collections.Generic;
using UnityEngine;

namespace Cybermage.Common
{
    public static class ObjectSpawner
    {
        private static List<Vector3> _spawnPositions = new List<Vector3>();
        private static Transform _spawnTransform;
        
        private static void Initialise()
        {
            _spawnTransform = MonoBehaviour.Instantiate(CM_Resources.prefabs.pickupSpawns.Load()).transform;
            
            foreach (Transform child in _spawnTransform)
            {
                _spawnPositions.Add(child.transform.position);        
            }
        }

        public static Vector3 GetSpawnPosition()
        {
            if (_spawnTransform == null)
                Initialise();
                
            return _spawnPositions[Random.Range(0, _spawnPositions.Count - 1)];
        }
    }
}