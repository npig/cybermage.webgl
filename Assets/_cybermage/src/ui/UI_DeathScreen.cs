using Cybermage;
using UnityEngine;
using UnityEngine.UI;

public class UI_DeathScreen : MonoBehaviour
{
    private Button _button;
    
    public void Awake()
    {
        _button = Utilities.FindDeepChild<Button>(this.transform, "button");
        _button.onClick.AddListener(OnCLickButton);
    }
    
    private void OnCLickButton()
    {
        StateMachine.QueueState(new MainMenu());
    }
}

