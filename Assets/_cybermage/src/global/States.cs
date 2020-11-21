using System;
using Cybermage.Common;
using Cybermage.Core;
using Cybermage.Entities;
using Cybermage.Events;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cybermage
{
    public class MainMenu : State
    {
        private readonly string SCENE = "_ui";
        private UI_MainScreen _mainScreen;

        public override void Load()
        {
            LoadScene();
        }
        
        private async UniTaskVoid LoadScene()
        {
            await SceneLoader.LoadAdditive("_ui", () =>
            {
                MonoBehaviour.Instantiate(Resources.Load("prefabs/ui/background"), UIManager.Canvas.transform);
                _mainScreen = MonoBehaviour.Instantiate(Resources.Load<UI_MainScreen>("prefabs/ui/mainScreen"), UIManager.Canvas.transform);
                MonoBehaviour.Instantiate(Resources.Load("prefabs/ui/guideScreen"), UIManager.Canvas.transform);
                AudioManager.PlaySample("00MusicLoop");
            });
        }

        public override void Unload()
        {
            AudioManager.StopAudio(1);
            SceneLoader.UnloadScene("_ui");
        }
    }
    
    public class DeathMenu : State
    {
        private UI_DeathScreen _deathScreen;

        public override void Load()
        {
            LoadScene();
        }

        private async UniTaskVoid LoadScene()
        {
            await SceneLoader.LoadAdditive("_ui", () =>
            {
                MonoBehaviour.Instantiate(Resources.Load("prefabs/ui/background"), UIManager.Canvas.transform);
                _deathScreen = MonoBehaviour.Instantiate(Resources.Load<UI_DeathScreen>("prefabs/ui/deathScreen"), UIManager.Canvas.transform);
                AudioManager.PlaySample("00MusicLoop");
            });
        }

        public override void Unload()
        {
            SceneLoader.UnloadScene("_ui");
        }
    }
    
    public class Game : State
    {

        public override void Load()
        {
            AudioManager.PlaySample("09_manylpS");
            AudioManager.PlaySample("07_xxtur006");
            LoadScene();
        }
        
        private async UniTaskVoid LoadScene()
        {
            await SceneLoader.LoadAdditive("_ui", () =>
            {
                UI_Stats statsContainer = MonoBehaviour.Instantiate(Resources.Load<UI_Stats>("prefabs/ui/statsContainer"), UIManager.Canvas.transform);
                statsContainer.SetData(new UIStatsData(Application.version, GlobalsConfig.Username));
            });
            
            await SceneLoader.LoadAdditive("_level", () =>
            {
                EntityFactory.SpawnPlayer(GameObject.Find("_playerSpawn").transform.position);
                ObjectSpawner.SpawnPickup();
            });

            await SceneLoader.LoadAdditive("_world_ui");
            
            GlobalsConfig.GameState = GameState.Active;

            FadeManager.FadeFromBlack(5f, () =>
            {
                AudioManager.PlaySample("04Modem");
            });
        }

        public override void Unload()
        {
            SceneLoader.UnloadScene("_world_ui");
            SceneLoader.UnloadScene("_level");
            SceneLoader.UnloadScene("_ui");
        }
    }

    public class TransitionTo<T> : State
    {
        public override void Load()
        {
            FadeManager.FadeToBlack(1f, () =>
            {
                StateMachine.QueueState((State)Activator.CreateInstance(typeof(T)));
            });
        }

        public override void Unload()
        {
        }
    }
}