
using Cybermage.API;
using UnityEngine;

namespace Cybermage.Global
{
    
    public static class Globals
    {
        private static GlobalsManager _globalsManager;
        
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Main()
        {
            _globalsManager = new GameObject("GlobalsManager").AddComponent<GlobalsManager>();
        }

        public static void Initialise()
        {
            
        }
    }
    
}
