using System;
using System.Text.RegularExpressions;
using Cybermage;
using Cybermage.GraphQL.Mutations;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_MainScreen : MonoBehaviour
{
    private TextMeshProUGUI _title;
    private TextMeshProUGUI _placeHolderText;
    private TMP_InputField _inputField;
    private TextMeshProUGUI _inputText;
    private TextMeshProUGUI _errorLabel;
    private Transform _errorTransform;
    private Button _button;
    private Regex _regex = new Regex(@"^(?=.{4,20}$)(?:[a-zA-Z\d]+(?:(?:\.|-|_)[a-zA-Z\d])*)+$", RegexOptions.IgnoreCase);
    
    public void Awake()
    {
        _title = Utilities.FindDeepChild<TextMeshProUGUI>(this.transform, "title");
        _placeHolderText = Utilities.FindDeepChild<TextMeshProUGUI>(this.transform, "inputPlaceholder");
        _inputText = Utilities.FindDeepChild<TextMeshProUGUI>(this.transform, "inputText");
        _errorLabel = Utilities.FindDeepChild<TextMeshProUGUI>(this.transform, "errorLabel");
        _button = Utilities.FindDeepChild<Button>(this.transform, "button");
        _inputField = Utilities.FindDeepChild<TMP_InputField>(this.transform, "inputField");
        _errorTransform = _errorLabel.transform.parent;
        _errorTransform.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    public void SetData(UIMainScreenData data)
    {
        _title.text = data.Title;
        _placeHolderText.text = data.InputPlaceHolderText;
        _button.onClick.AddListener(OnCLickButton);
    }

    private async UniTaskVoid DisplayError(string errorMessage)
    {
        if (_errorTransform.gameObject.activeSelf)
            return;

        string currentText = _inputText.text;
        
        _errorLabel.text = $"{errorMessage}";
        _errorTransform.gameObject.SetActive(true);
        
        while (String.Equals(_inputText.text, currentText))
        {
            await UniTask.Delay(1);  
        }
        
        _errorTransform.gameObject.SetActive(false);
        _errorLabel.text = "";

    }

    private async void OnCLickButton()
    {
        if (GlobalsConfig.Dev)
        {
            GlobalsConfig.SetUsername("Developer");
            StateMachine.QueueState(new Game());
            return;
        }
        
        if (!_regex.IsMatch(_inputText.text)) {
            DisplayError("illegal characters");
            return;
        }

        //GlobalsConfig.SetUsername(_inputText.text);
        AddUserResult result = await AddUser.Query(_inputText.text);
        
        if (result.userName != null)
        {
            GlobalsConfig.SetUsername(result.userName);
            StateMachine.QueueState(new Game());
        }
        else
        {
            DisplayError(result.error);
        }
    }
}

public class UIMainScreenData
{
    public string Title { get; private set; }
    public string InputPlaceHolderText { get; private set; }

    public UIMainScreenData(string title, string inputPlaceHolderText)
    {
        Title = title;
        InputPlaceHolderText = inputPlaceHolderText;
    }
}

