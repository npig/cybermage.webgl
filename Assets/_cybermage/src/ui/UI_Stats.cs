using System;
using System.Collections;
using System.Collections.Generic;
using Cybermage;
using Cybermage.GraphQL.Mutations;
using Lithodomos.Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Stats : MonoBehaviour
{
    private UIStatsData _data;
    private TextMeshProUGUI _versionText;
    private TextMeshProUGUI _usernameText;

    private void Awake()
    {
        _versionText = Utilities.FindDeepChild<TextMeshProUGUI>(this.transform, "buildVersion");
        _usernameText = Utilities.FindDeepChild<TextMeshProUGUI>(this.transform, "userName");
    }

    public void SetData(UIStatsData data)
    {
        _versionText.text = data.Version;
        _usernameText.text = data.Username;
        Debug.Log(_data.Version);
        Debug.Log(_data.Username);
    }
}

public class UIStatsData
{
    public string Version { get; private set; }
    public string Username { get; private set; }

    public UIStatsData(string version, string username)
    {
        Version = version;
        Username = username;
    }
}

