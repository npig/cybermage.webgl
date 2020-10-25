using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Cybermage
{
    public static class Utilities
    {
        public static Color ColorHex(string hex)
        {
            ColorUtility.TryParseHtmlString(hex, out Color color);
            return color;
        }

        public static Transform FindDeepChild(Transform aParent, string aName)
        {
            Queue<Transform> queue = new Queue<Transform>();
            queue.Enqueue(aParent);

            while (queue.Count > 0)
            {
                var c = queue.Dequeue();
                if (c.name == aName)
                    return c;
                foreach (Transform t in c)
                    queue.Enqueue(t);
            }

            return null;
        }
        
        public static T FindDeepChild<T>(Transform parentTransform, string gameObjectName)
        {
            Queue<Transform> queue = new Queue<Transform>();
            queue.Enqueue(parentTransform);

            while (queue.Count > 0)
            {
                var c = queue.Dequeue();
                if (c.name == gameObjectName)
                {
                    return c.gameObject.GetComponent<T>();
                }

                foreach (Transform t in c)
                    queue.Enqueue(t);
            }

            return default(T);
        }
        
        public static List<T> FindAllDeepChild<T>(Transform aParent)
        {
            List<T> typeList = new List<T>();
            Queue<Transform> queue = new Queue<Transform>();
            queue.Enqueue(aParent);

            while (queue.Count > 0)
            {
                var c = queue.Dequeue();
                T typeComponent = c.gameObject.GetComponent<T>();
                
                if (typeComponent != null)
                {
                    typeList.Add(typeComponent);
                }

                foreach (Transform t in c)
                    queue.Enqueue(t);
            }

            return typeList;
        }
    }
}
