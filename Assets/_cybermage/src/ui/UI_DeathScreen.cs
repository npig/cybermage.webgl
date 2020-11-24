using System;
using Cybermage;
using Cybermage.GraphQL;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_DeathScreen : MonoBehaviour
{
    private Button _button;
    private Transform _loader;
    
    public void Awake()
    {
        _button = Utilities.FindDeepChild<Button>(this.transform, "button");
        _button.onClick.AddListener(OnCLickButton);
        _loader = Utilities.FindDeepChild(this.transform, "loaderWrapper");
        Utilities.FindDeepChild<TextMeshProUGUI>(this.transform, "statText").text = $"You eliminated {StateMachine.CurrentState<DeathMenu>().GetScore().ToString()} mobs ";
        PopulateTopScores();
    }

    private async UniTaskVoid PopulateTopScores()
    {
        GetTopScoresResult[] _scores = await GetTopScores.Query();
        Transform scoresContent = Utilities.FindDeepChild(this.transform, "scoresContent");
        _loader.gameObject.SetActive(false);
        
        for (var index = 0; index < _scores.Length; index++)
        {
            GetTopScoresResult user = _scores[index];
            GameObject go = Instantiate(CM_Resources.prefabs.ui.scoreItem.Load(), scoresContent);
            
            TextMeshProUGUI number = Utilities.FindDeepChild<TextMeshProUGUI>(go.transform, "number");
            number.text = (index + 1).ToString();
            
            TextMeshProUGUI userName = Utilities.FindDeepChild<TextMeshProUGUI>(go.transform, "userName");
            userName.text = user.userName;
            
            TextMeshProUGUI score = Utilities.FindDeepChild<TextMeshProUGUI>(go.transform, "score");
            score.text = user.score;

            if (String.Equals(GlobalsConfig.Username, user.userName))
            {
                number.color = Color.cyan;
                userName.color = Color.cyan;
                score.color = Color.cyan;
            }
        }
    }

    private void OnCLickButton()
    {
        StateMachine.QueueState(new MainMenu());
    }
}

