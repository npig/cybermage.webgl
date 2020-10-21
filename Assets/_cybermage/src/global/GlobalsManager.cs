using Cybermage.Global;
using UnityEngine;

public class GlobalsManager : MonoBehaviour
{
    public void Awake()
    {
        Globals.Initialise();
    }
}
