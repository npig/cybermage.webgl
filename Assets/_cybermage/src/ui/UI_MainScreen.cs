using System;
using System.Text.RegularExpressions;
using System.Threading;
using Cybermage;
using Cybermage.GraphQL.Mutations;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_MainScreen : MonoBehaviour
{
    private TMP_InputField _userNameField;
    private TMP_InputField _passwordField;
    private TextMeshProUGUI _errorLabel;
    private Button _goButton;
    private Button _eyeButton;
    
    private Regex _regex = new Regex(@"^(?=.{4,20}$)(?:[a-zA-Z\d]+(?:(?:\.|-|_)[a-zA-Z\d])*)+$", RegexOptions.IgnoreCase);
    
    private static CancellationTokenSource _displayCancellationTokenSource;

    
    public void Awake()
    {
        _errorLabel = Utilities.FindDeepChild<TextMeshProUGUI>(transform, "errorLabel");
        _userNameField = Utilities.FindDeepChild<TMP_InputField>(transform, "userNameInput");
        _passwordField = Utilities.FindDeepChild<TMP_InputField>(transform, "passwordInput");
        _goButton = Utilities.FindDeepChild<Button>(transform, "goButton");
        _goButton.onClick.AddListener(OnGoButton);
        _eyeButton = Utilities.FindDeepChild<Button>(transform, "eyeButton");
        _eyeButton.onClick.AddListener(OnEyeButton);
        _errorLabel.text = "";
    }

    private async UniTaskVoid DisplayError(string errorMessage)
    {
        if (_displayCancellationTokenSource != null)
        {
            _displayCancellationTokenSource.Cancel();
            _displayCancellationTokenSource = null;
            return;
        }
        
        _displayCancellationTokenSource = new CancellationTokenSource();
        
        string currentText = _userNameField.text;
        _errorLabel.text = $"{errorMessage}";

        while (String.Equals(_userNameField.text, currentText))
        {
            await UniTask.Delay(60, DelayType.Realtime, PlayerLoopTiming.Update, _displayCancellationTokenSource.Token);
        }
        
        _displayCancellationTokenSource.Cancel();
        _displayCancellationTokenSource = null;
        _errorLabel.text = "";
    }

    private void OnEyeButton()
    {
        _passwordField.contentType = _passwordField.contentType == TMP_InputField.ContentType.Password ? TMP_InputField.ContentType.Alphanumeric : TMP_InputField.ContentType.Password;
    }

    private void OnGoButton()
    {
        if (GlobalsConfig.Dev)
        {
            GlobalsConfig.SetUsername("Developer");
            StateMachine.QueueState(new TransitionTo<Game>());
            return;
        }
        
        if (!_regex.IsMatch(_userNameField.text)) {
            DisplayError("illegal characters");
            return;
        }

        CreateUser();
    }
    
    private async UniTaskVoid CreateUser()
    {
        AddUserResult result = await AddUser.Query(_userNameField.text, _passwordField.text);

        if (result.token == null)
        {
            DisplayError(result.error);
        }
        else
        {
            Debug.Log(result.token);
            GlobalsConfig.SetUsername(_userNameField.text);
            StateMachine.QueueState(new TransitionTo<Game>());
        }
    }
}

