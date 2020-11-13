using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Cybermage.Core
{
    public enum FadeState
    {
        ToBlack,
        FromBlack
    }

    public abstract class FadeObject
    {
        public abstract FadeState FadeState { get; set; }
        public abstract GameObject FadeGameObject { get; set; }
        public abstract Timer Timer { get; set; }
        protected Color _fadeColor = Color.black;
        protected abstract void SetColor(Color color);
        private static Action _fadeCompleted;
        
        protected FadeObject(float duration, Action fadeCompleted)
        {
            _fadeCompleted = fadeCompleted;
            
            Timer = new Timer
            {
                FinishedAction = TimerCompleted, 
                UpdateAction = TimerUpdate,
                Duration = duration
            };

            Timer.Start();
        }

        private void TimerCompleted()
        {
            _fadeCompleted?.Invoke();
            
            //Every FadeToBlack is followed by a FadeFromBlack
            if (FadeState == FadeState.ToBlack)
            {
                FadeGameObject.SetActive(false);
                return;
            }

            while (FadeManager.FadeObjectQueue.Peek() != this)
            {
                FadeObject objectFade = FadeManager.FadeObjectQueue.Dequeue();
                Object.Destroy(objectFade.FadeGameObject);
            }
          
            FadeManager.FadeObjectQueue.Dequeue();
            Object.Destroy(FadeGameObject);
        }

        private void TimerUpdate(float t)
        {
            if (FadeState == FadeState.ToBlack)
                _fadeColor.a = t;
            else
                _fadeColor.a = 1.0f - t;

            SetColor(_fadeColor);
        }
    }
    
    public class ScreenFadeObject : FadeObject
    {
        public sealed override FadeState FadeState { get; set; }
        public sealed override GameObject FadeGameObject { get; set; }
        public sealed override Timer Timer { get; set; }
        public Image ScreenObject { get; set; }
        
        public ScreenFadeObject(FadeState fadeState, GameObject gameObject, Image image, float duration, Action fadeCompleted) : base(duration, fadeCompleted)
        {
            FadeState = fadeState; 
            FadeGameObject = gameObject;
            ScreenObject = image;
        }

        protected override void SetColor(Color color)
        {
            ScreenObject.color = color;
        }
    }
    
    /// <summary>
    /// FadeManager handles transitions between/for WorldSpace and ScreenSpace XR.
    /// </summary>
    public static class FadeManager
    {
        private static GameObject _parent;
        private static Color _color;
        public static Queue<FadeObject> FadeObjectQueue;

        public static void Awake()
        {
            _parent = new GameObject("FadeManager");
            Object.DontDestroyOnLoad(_parent);
            FadeObjectQueue = new Queue<FadeObject>();
        }

        private static ScreenFadeObject CreateUIFadeObject(FadeState fadeState, float duration, Action fadeCompleteDelegate)
        {
            GameObject screenGameObject = new GameObject("ScreenSpace Canvas");
            screenGameObject.transform.SetParent(_parent.transform);
            Canvas fadeCanvas = screenGameObject.AddComponent<Canvas>();
            fadeCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
            fadeCanvas.sortingOrder = 100;
            GameObject blackRectangle = new GameObject("ScreenSpace Object");
            blackRectangle.transform.SetParent(screenGameObject.transform);
            RectTransform rectTransform = blackRectangle.AddComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(1, 1);
            rectTransform.offsetMin = new Vector2(0, 0);
            rectTransform.offsetMax = new Vector2(0, 0);
            Image screenObject = blackRectangle.AddComponent<Image>();
            screenObject.color = Color.black;
            return new ScreenFadeObject(fadeState, screenGameObject, screenObject, duration, fadeCompleteDelegate);
        }
        
        private static void CreateFadeObject(FadeState fadeState, float duration, Action fadeCompleteDelegate)
        {
            FadeObjectQueue.Enqueue(CreateUIFadeObject(fadeState, duration, fadeCompleteDelegate));
        }
        
        public static void UpdateFades()
        {
            List<FadeObject> objectsToUpdate = FadeObjectQueue.ToList();

            foreach (var obj in objectsToUpdate)
            {
                obj.Timer.Update();
            }
        }

        public static void FadeToBlack(float duration, Action fadeCompleteDelegate)
        {
            CreateFadeObject(FadeState.ToBlack, duration, fadeCompleteDelegate);
        }

        public static void FadeFromBlack(float duration, Action fadeCompleteDelegate)
        {
            CreateFadeObject(FadeState.FromBlack, duration, fadeCompleteDelegate);
        }
        
        public static void SetAlpha(float alpha)
        {
            _color.a = alpha;
        }

        public static void SetColor(Color color)
        {
            _color = color;
        }
    }
}