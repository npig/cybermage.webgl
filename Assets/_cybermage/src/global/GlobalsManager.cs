using Cybermage.Global;
using UnityEngine;

public class GlobalsManager : MonoBehaviour
{
   
    public void Awake()
    {
        Globals.GlobalsAwake();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
        }
    }
    
}
