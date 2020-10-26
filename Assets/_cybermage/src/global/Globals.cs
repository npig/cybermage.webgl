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
            MainCamera.Awake();
            StateMachine.QueueState(new MainMenu());
        }
        
        public static void Update()
        {
            CommandInvoker.Update();
            StateMachine.Update();
            InputController.Update();
            Cybermage.Common.CharacterController.Update();
        }
    }

    public static class UIManager
    {
        public static Canvas BuildCanvas()
        {
            return MonoBehaviour.Instantiate(Resources.Load<Canvas>("prefabs/ui/uiCanvas"));
        }

        private static void BuildStatsMenu()
        {
            UI_Stats statsContainer = MonoBehaviour.Instantiate(Resources.Load<UI_Stats>("prefabs/ui/statsContainer"));
            statsContainer.SetData(new UIStatsData(Application.version, GlobalsConfig.Username));
        }
    }
}
