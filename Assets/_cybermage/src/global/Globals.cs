using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cybermage.Common;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
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
            GlobalsConfig.Initialise(true);
            SceneManager.sceneLoaded += SceneLoaded;
        }

        private static void SceneLoaded(Scene scene, LoadSceneMode mode) { }

        public static void Awake()
        {
            MainCamera.Awake(6);
            //AudioManager.Awake();
            UIManager.Awake();
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

    public static class SceneLoader
    {
        private static CancellationTokenSource _cancellationTokenSource;

        public static async Task LoadAdditive(string sceneName, Action sceneLoadAction = null)
        {
            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
                _cancellationTokenSource = null;
                return;
            }

            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                await SceneLoadOperation(_cancellationTokenSource.Token, sceneName, LoadSceneMode.Additive);
                Scene scene = SceneManager.GetSceneByName(sceneName);
                SceneManager.SetActiveScene(scene);
                sceneLoadAction?.Invoke();
            }
            catch (OperationCanceledException ex)
            {
                if (ex.CancellationToken == _cancellationTokenSource.Token)
                {
                    Debug.Log("Task cancelled");
                }
            }
            finally
            {
                _cancellationTokenSource.Cancel();
                _cancellationTokenSource = null;
            }
        }
        
        private static async Task SceneLoadOperation(CancellationToken token, string sceneName, LoadSceneMode mode)
        {
            token.ThrowIfCancellationRequested();

            if (token.IsCancellationRequested)
                return;
            
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, mode);
            asyncOperation.allowSceneActivation = false;

            while (true)
            {
                token.ThrowIfCancellationRequested();
                
                if (token.IsCancellationRequested)
                    return;
                
                if (asyncOperation.progress >= 0.9f)
                    break;            
            }
            
            asyncOperation.allowSceneActivation = true;
            
            while (!asyncOperation.isDone)
            {
                if (token.IsCancellationRequested)
                    return;
                
                await UniTask.DelayFrame(1, PlayerLoopTiming.Update, token);
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
