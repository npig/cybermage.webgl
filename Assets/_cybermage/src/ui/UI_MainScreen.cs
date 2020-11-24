using System;
using System.Text.RegularExpressions;
using System.Threading;
using Cybermage;
using Cybermage.GraphQL;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_MainScreen : MonoBehaviour
{
    private TMP_InputField _userNameField;
    private TMP_InputField _passwordField;
    private TextMeshProUGUI _errorLabel;
    private Button _signupButton;
    private Button _loginButton;
    private Button _eyeButton;
    private Transform _loaderWrapper;
    private Transform _buttonWrapper;
    
    private Regex _regex = new Regex(@"^(?=.{4,20}$)(?:[a-zA-Z\d]+(?:(?:\.|-|_)[a-zA-Z\d])*)+$", RegexOptions.IgnoreCase);
    
    private static CancellationTokenSource _displayCancellationTokenSource;

    
    public void Awake()
    {
        _userNameField = Utilities.FindDeepChild<TMP_InputField>(transform, "userNameInput");
        _userNameField.onSubmit.AddListener(UserNameSubmit);

        _passwordField = Utilities.FindDeepChild<TMP_InputField>(transform, "passwordInput");
        _passwordField.onSubmit.AddListener(PasswordSubmit);

        _buttonWrapper = Utilities.FindDeepChild(transform, "buttonWrapper");
        _loaderWrapper = Utilities.FindDeepChild(transform, "loaderWrapper");
        
        _signupButton = Utilities.FindDeepChild<Button>(transform, "signupButton");
        _signupButton.onClick.AddListener(OnSignupButton);
        
        _loginButton = Utilities.FindDeepChild<Button>(transform, "loginButton");
        _loginButton.onClick.AddListener(OnLoginButton);
        
        _eyeButton = Utilities.FindDeepChild<Button>(transform, "eyeButton");
        _eyeButton.onClick.AddListener(OnEyeButton);
        
        _errorLabel = Utilities.FindDeepChild<TextMeshProUGUI>(transform, "errorLabel");
        _errorLabel.text = "";
        
        EnableButton(true);
    }

    public void OnDestroy()
    {
        _userNameField.onSubmit.RemoveListener(UserNameSubmit);
        _passwordField.onSubmit.RemoveListener(PasswordSubmit);
    }

    private void UserNameSubmit(string arg0)
    {
        _passwordField.ActivateInputField();
    }
    
    private void PasswordSubmit(string arg0)
    {
        OnLoginButton();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (_userNameField.isFocused)
            {
                _passwordField.ActivateInputField();
            }
            else
            {
                _userNameField.ActivateInputField();
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _passwordField.DeactivateInputField();
            _userNameField.DeactivateInputField();
        }

    }

    private void EnableButton(bool status)
    {
        _buttonWrapper.gameObject.SetActive(status);
        _loaderWrapper.gameObject.SetActive(!status);
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
        _passwordField.contentType = _passwordField.contentType == TMP_InputField.ContentType.Password ? TMP_InputField.ContentType.Standard : TMP_InputField.ContentType.Password;
        _passwordField.ForceLabelUpdate();
    }

    private void OnSignupButton()
    {
        if (GlobalsConfig.Dev)
        {
            GlobalsConfig.SetUsername("Developer");
            StateMachine.QueueState(new TransitionTo<Game>());
            return;
        }
        
        if (!_regex.IsMatch(_userNameField.text)) {
            DisplayError("illegal username characters");
            return;
        }

        if(_passwordField.text.Length < 6)
        {
            DisplayError("minimum password length is 6 characters"); 
            return;
        } 
        
        CreateUser();
    }
    
    private void OnLoginButton()
    {
        if (GlobalsConfig.Dev)
        {
            GlobalsConfig.SetUsername("Developer");
            StateMachine.QueueState(new TransitionTo<Game>());
            return;
        }
        
        if (!_regex.IsMatch(_userNameField.text)) {
            DisplayError("illegal username characters");
            return;
        }
        
        LoginUser();
    }
    
    private async UniTaskVoid CreateUser()
    {
        EnableButton(false);

        AddUserResult result = await AddUser.Query(_userNameField.text, _passwordField.text);

        if (String.IsNullOrEmpty(result.token))
        {
            DisplayError(result.error);
            EnableButton(true);
        }
        else
        {
            GraphQLClient.Token = result.token;
            GlobalsConfig.SetUsername(_userNameField.text);
            StateMachine.QueueState(new TransitionTo<Game>());
        }
    }
    
    private async UniTaskVoid LoginUser()
    {
        EnableButton(false);

        LoginUserResult result = await Cybermage.GraphQL.LoginUser.Query(_userNameField.text, _passwordField.text);

        if (String.IsNullOrEmpty(result.token))
        {
            DisplayError(result.error);
            EnableButton(true);
        }
        else
        {
            GraphQLClient.Token = result.token;
            GlobalsConfig.SetUsername(_userNameField.text);
            StateMachine.QueueState(new TransitionTo<Game>());
        }
    }
}

