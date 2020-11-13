using Cybermage.Common;
using Cysharp.Threading.Tasks;
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
            MonoBehaviour.Instantiate(Resources.Load("prefabs/ui/background"), UIManager.Canvas.transform);
            _mainScreen = MonoBehaviour.Instantiate(Resources.Load<UI_MainScreen>("prefabs/ui/mainScreen"), UIManager.Canvas.transform);
            _mainScreen.SetData(new UIMainScreenData("Cybermage","USERNAME"));
            AudioManager.PlaySample("00MusicLoop");
        }

        public override void Load()
        {

        }

        public override void Unload()
        {
            SceneLoader.UnloadScene("_ui");
        }
    }
    
    public class Game : State
    {
        public Game()
        {
        }
        
        public override void Load()
        {
            LoadScenes();
        }

        private async UniTaskVoid LoadScenes()
        {
            await SceneLoader.LoadAdditive("_ui", () =>
            {
                UI_Stats statsContainer = MonoBehaviour.Instantiate(Resources.Load<UI_Stats>("prefabs/ui/statsContainer"), UIManager.Canvas.transform);
                statsContainer.SetData(new UIStatsData(Application.version, GlobalsConfig.Username));
            });
            
            await SceneLoader.LoadAdditive("_level", () =>
            {
                EntityFactory.SpawnPlayer(GameObject.Find("_playerSpawn").transform.position);
                EntityFactory.SpawnZombie(ObjectSpawner.GetSpawnPosition());
                EntityFactory.SpawnZombie(ObjectSpawner.GetSpawnPosition());
            });

            await SceneLoader.LoadAdditive("_world_ui");
        }

        public override void Unload()
        {
            
        }
    }

}