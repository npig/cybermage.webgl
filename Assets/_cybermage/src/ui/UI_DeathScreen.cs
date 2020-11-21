using System;
using System.Threading.Tasks;
using Cybermage;
using Cybermage.GraphQL.Mutations;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_DeathScreen : MonoBehaviour
{
    private Button _button;
    
    public void Awake()
    {
        _button = Utilities.FindDeepChild<Button>(this.transform, "button");
        _button.onClick.AddListener(OnCLickButton);
        PopulateTopScores();
    }

    private async UniTaskVoid PopulateTopScores()
    {
        GetTopScoresResult[] _scores = await GetTopScores.Query();
        Transform scoresContent = Utilities.FindDeepChild(this.transform, "scoresContent");

        for (var index = 0; index < _scores.Length; index++)
        {
            GetTopScoresResult user = _scores[index];
            GameObject go = Instantiate(CM_Resources.prefabs.ui.scoreItem.Load(), scoresContent);
            Utilities.FindDeepChild<TextMeshProUGUI>(go.transform, "number").text = (index + 1).ToString();
            Utilities.FindDeepChild<TextMeshProUGUI>(go.transform, "userName").text = user.userName;
            Utilities.FindDeepChild<TextMeshProUGUI>(go.transform, "score").text = user.score;
        }
    }

    private void OnCLickButton()
    {
        StateMachine.QueueState(new MainMenu());
    }
}

