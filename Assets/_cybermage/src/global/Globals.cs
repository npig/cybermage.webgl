using Cybermage.Common;
using UnityEngine;
using UnityEngine.SceneManagement;
using CharacterController = UnityEngine.CharacterController;

namespace Cybermage
{
    public static class Globals
    {
        private static GlobalsManager _globalsManager;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Main()
        {
            _globalsManager = new GameObject("GlobalsManager").AddComponent<GlobalsManager>();
            SceneManager.sceneLoaded += SceneLoaded;
        }

        private static void SceneLoaded(Scene scene, LoadSceneMode mode)
        {
            
        }

        public static void Awake()
        {
            MainCamera.Awake(3);
            EntityFactory.Awake();
            StateMachine.QueueState(new MainMenu());
        }
        
        public static void Update()
        {
            CommandInvoker.Update();
            StateMachine.Update();
            InputController.Update();
        }
    }

    public static class UIManager
    {
        public static Canvas BuildCanvas()
        {
            return MonoBehaviour.Instantiate(Resources.Load<Canvas>("prefabs/ui/uiCanvas"));
        }
    }
}
