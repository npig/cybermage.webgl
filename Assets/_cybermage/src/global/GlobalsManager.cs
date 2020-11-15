using System;
using UnityEngine;

namespace Cybermage
{
    public class GlobalsManager : MonoBehaviour
    {
        public void Awake()
        {
            DontDestroyOnLoad(this);
            Globals.Awake();
        }

        public void Update()
        {
            Globals.Update();
        }

        public void OnDestroy()
        {
            Globals.Sleep();
        }
    }
}
