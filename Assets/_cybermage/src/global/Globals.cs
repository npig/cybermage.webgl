using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cybermage
{
    public static class Globals
    {
        private static GlobalsManager _globalsManager;
        
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Main()
        {
            _globalsManager = new GameObject("GlobalsManager").AddComponent<GlobalsManager>();
            SceneManager.sceneLoaded += LoadScene;
        }

        public static void Initialise()
        {
            AddSceneLayer("_ui");
        }

        private static void AddSceneLayer(string sceneName)
        {
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }

        private static void LoadScene(Scene scene, LoadSceneMode mode)
        {
            SceneManager.SetActiveScene(scene);

            switch (scene.name)
            {
                case "_ui":
                    UIManager.Initialise();
                    break;
                default:
                    return;
            }
        }
    }

    public static class UIManager
    {
        private static Canvas _canvas;
        public static void Initialise()
        {
            _canvas = MonoBehaviour.Instantiate(Resources.Load<Canvas>("prefabs/ui/uiCanvas"));
            BuildMainMenu();
        }

        private static void BuildMainMenu()
        {
            MonoBehaviour.Instantiate(Resources.Load("prefabs/ui/background"), _canvas.transform);
            UI_MainScreen mainScreen = MonoBehaviour.Instantiate(Resources.Load<UI_MainScreen>("prefabs/ui/mainScreen"), _canvas.transform);
            mainScreen.SetData(new UIMainScreenData("CYBERMAGE","Enter Username"));
        }

        private static void BuildStatsMenu()
        {
            UI_Stats statsContainer = MonoBehaviour.Instantiate(Resources.Load<UI_Stats>("prefabs/ui/statsContainer"), _canvas.transform);
            statsContainer.SetData(new UIStatsData(Application.version, GlobalsConfig.Username));
        }
    }
}
