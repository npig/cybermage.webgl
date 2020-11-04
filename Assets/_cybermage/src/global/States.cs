using UnityEngine;
using UnityEngine.AI;
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
        private readonly string MAIN_SCENE = "_main";
        private readonly string UI_SCENE = "_ui";
        private readonly string LEVEL_SCENE = "_ui";
        private Scene _mainScene;

        public Game()
        {
        }
        
        public override void Load()
        {
            _mainScene = SceneManager.GetSceneByName(MAIN_SCENE);
            SceneManager.SetActiveScene(_mainScene);
            Canvas mainCanvas = UIManager.BuildCanvas();
            UI_Stats statsContainer = MonoBehaviour.Instantiate(Resources.Load<UI_Stats>("prefabs/ui/statsContainer"), mainCanvas.transform);
            statsContainer.SetData(new UIStatsData(Application.version, GlobalsConfig.Username));
            
            

            EntityFactory.SpawnPlayer(Vector3.zero);
            EntityFactory.SpawnZombie(Vector3.one);
            EntityFactory.SpawnZombie(Vector3.one * 2);
            
            

        }

        public override void Unload()
        {
            
        }
    }

}