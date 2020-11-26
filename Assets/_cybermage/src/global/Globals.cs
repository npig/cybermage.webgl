using System;
using System.Threading;
using Cybermage.Common;
using Cybermage.Core;
using Cybermage.Entities;
using Cybermage.Events;
using Cybermage.GraphQL;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Cybermage
{
    public static class Globals
    {
        private static GlobalsManager _globalsManager;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void Main()
        {
            _globalsManager = new GameObject("GlobalsManager").AddComponent<GlobalsManager>();
            GlobalsConfig.Initialise(false);
            EventManager.Instance.AddListener<DeathEvent>(DeathEvent);
        }

        private static void SceneLoaded(Scene scene, LoadSceneMode mode) { }

        public static void Awake()
        {
            MainCamera.Awake(6);
            AudioManager.Awake();
            UIManager.Awake();
            EntityFactory.Awake();
            FadeManager.Awake();
            StateMachine.QueueState(new MainMenu());
        }
        
        public static void Update()
        {
            CommandInvoker.Update();
            FadeManager.Update();
            StateMachine.Update();
            InputController.Update();
            ObjectSpawner.Update();
            TimerManager.Update();
        }
        
        private static void DeathEvent(DeathEvent e)
        {
            if (e.Mobile.EntityType == EntityType.PLAYER)
            {
                int score = GlobalsConfig.Score;
                UpdateScore(GlobalsConfig.Score);
                GlobalsConfig.ResetGame();
                StateMachine.QueueState(new DeathMenu(score));
                
            }
            else
            {
                GlobalsConfig.Score += 1;
                GlobalsConfig.MobileCollection.Remove(e.Mobile);
            }
        }

        private static async UniTaskVoid UpdateScore(int score)
        {
            UpdateScoreResult result = await Cybermage.GraphQL.UpdateScore.Query(score);
        }

        public static void Sleep()
        {
            SceneManager.sceneLoaded -= SceneLoaded;
            EventManager.Instance.RemoveListener<DeathEvent>(DeathEvent);        }
    }

    public static class SceneLoader
    {
        public static async UniTask LoadAdditive(string sceneName, Action sceneLoadAction = null)
        {
            try
            {
                await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
                Scene scene = SceneManager.GetSceneByName(sceneName);
                SceneManager.SetActiveScene(scene);
                sceneLoadAction?.Invoke();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public static void UnloadScene(string sceneName)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }
    }

    public static class UIManager
    {
        public static Canvas Canvas => BuildCanvas(); 
        private static Canvas _canvas;

        public static void Awake()
        {
            GameObject eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
            eventSystem.AddComponent<BaseInput>();
            MonoBehaviour.DontDestroyOnLoad(eventSystem);
        }
        
        private static Canvas BuildCanvas()
        {
            if (_canvas == null)
            {
                _canvas = MonoBehaviour.Instantiate(Resources.Load<Canvas>("prefabs/ui/uiCanvas"));
            }

            return _canvas;
        }
    }
}
