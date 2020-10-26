using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cybermage
{
    public class MainMenu : State
    {
        private readonly string SCENE = "_ui";
        private readonly AsyncOperation _asyncOperation;
        private Scene _uiScene;
        private UI_MainScreen _mainScreen;

        public MainMenu()
        {
            _asyncOperation = SceneManager.LoadSceneAsync(SCENE, LoadSceneMode.Additive);
            _asyncOperation.allowSceneActivation = false;
            _asyncOperation.completed += SceneLoaded;
        }

        private void SceneLoaded(AsyncOperation obj)
        {
            _uiScene = SceneManager.GetSceneByName(SCENE);
            _asyncOperation.allowSceneActivation = true;
            SceneManager.SetActiveScene(_uiScene);
            Canvas mainCanvas = UIManager.BuildCanvas();
            MonoBehaviour.Instantiate(Resources.Load("prefabs/ui/background"), mainCanvas.transform);
            _mainScreen = MonoBehaviour.Instantiate(Resources.Load<UI_MainScreen>("prefabs/ui/mainScreen"), mainCanvas.transform);
            _mainScreen.SetData(new UIMainScreenData("CYBERMAGE","USERNAME"));
        }

        public override void Load()
        {

        }

        public override void Unload()
        {
            SceneManager.UnloadSceneAsync(_uiScene).allowSceneActivation = true;
        }
    }
    
    public class Game : State
    {
        private readonly string SCENE = "_main";

        public Game()
        {
            
        }
        
        public override void Load()
        {
            Cybermage.Common.CharacterController.Initialise();
        }

        public override void Unload()
        {
            
        }
    }

}