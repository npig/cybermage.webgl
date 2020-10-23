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
            SceneManager.sceneLoaded += SceneHandler;
        }

        public static void Initialise()
        {
            AddSceneLayer("ui");
        }

        private static void AddSceneLayer(string sceneName)
        {
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }

        private static void SceneHandler(Scene scene, LoadSceneMode mode)
        {
            SceneManager.SetActiveScene(scene);

            switch (scene.name)
            {
                case "ui":
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
            _canvas = MonoBehaviour.Instantiate(Resources.Load<Canvas>("prefabs/ui_canvas"));
            MonoBehaviour.Instantiate(Resources.Load("prefabs/background"), _canvas.transform);
            UI_MainScreen mainScreen = MonoBehaviour.Instantiate(Resources.Load<UI_MainScreen>("prefabs/main_screen"), _canvas.transform);
            mainScreen.Initialise(new UIMainScreenData("CYBERMAGE","Enter Username"));
        }
    }
}
