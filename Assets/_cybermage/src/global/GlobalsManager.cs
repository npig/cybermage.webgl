using UnityEngine;

namespace Cybermage
{
    public class GlobalsManager : MonoBehaviour
    {
        public void Awake()
        {
            Globals.Initialise();
        }
    }
}
