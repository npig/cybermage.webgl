using System;
using System.Collections;
using System.Collections.Generic;
using Cybermage;
using Lithodomos.Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_MainScreen : MonoBehaviour
{
    private TextMeshProUGUI _title;
    private TextMeshProUGUI _placeHolderText;
    private TextMeshProUGUI _inputText;
    private Button _button;
    
    public void Awake()
    {
        _title = Utilities.FindDeepChild<TextMeshProUGUI>(this.transform, "title");
        _placeHolderText = Utilities.FindDeepChild<TextMeshProUGUI>(this.transform, "Placeholder");
        _inputText = Utilities.FindDeepChild<TextMeshProUGUI>(this.transform, "Text");
        _button = Utilities.FindDeepChild<Button>(this.transform, "Button");
    }

    // Start is called before the first frame update
    public void Initialise(UIMainScreenData data)
    {
        _title.text = data.Title;
        _placeHolderText.text = data.InputPlaceHolderText;
        _button.onClick.AddListener(OnCLickButton);
    }

    private void OnCLickButton()
    {
        Debug.Log(_inputText.text);
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

