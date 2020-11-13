using System;
using Cybermage;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Stats : MonoBehaviour
{
    private UIStatsData _data;
    private TextMeshProUGUI _versionText;
    private TextMeshProUGUI _usernameText;
    private TextMeshProUGUI _playerHealthText;
    private TextMeshProUGUI _playerTargetText;
    private Image _leftHealth;
    private Image _rightHealth;

    private void Awake()
    {
        _versionText = Utilities.FindDeepChild<TextMeshProUGUI>(this.transform, "buildVersion");
        _usernameText = Utilities.FindDeepChild<TextMeshProUGUI>(this.transform, "userName");
        _playerHealthText = Utilities.FindDeepChild<TextMeshProUGUI>(this.transform, "playerHealth");
        _playerTargetText = Utilities.FindDeepChild<TextMeshProUGUI>(this.transform, "playerTarget");
        _leftHealth = Utilities.FindDeepChild<Image>(this.transform, "leftHealth");
        _rightHealth = Utilities.FindDeepChild<Image>(this.transform, "rightHealth");
    }

    private void Start()
    {
        UpdateData();
    }

    public async UniTaskVoid UpdateData()
    {
        while (true)
        {
            await UniTask.Delay(240);
            
            if(_data == null)
                return;
            
            _data.Update();
            UpdateText(_data);
            UpdateHealth(_data.PlayerHealth);
        }
    }

    private void UpdateHealth(float dataPlayerHealth)
    {
        float f = dataPlayerHealth / 50;
        _leftHealth.fillAmount = f;
        _rightHealth.fillAmount = f;
    }

    public void SetData(UIStatsData data)
    {
        _data = data;
    }

    private void UpdateText(UIStatsData data)
    {
        _data = data;
        _versionText.text = data.Version;
        _usernameText.text = data.PlayerName;
        _playerHealthText.text = data.PlayerHealth.ToString();
        _playerTargetText.text = data.PlayerTarget ?? "null";
    }
}

public class UIStatsData
{
    public string Version { get; private set; }
    public string PlayerName { get; private set; }
    public int PlayerHealth { get; private set; }
    public string PlayerTarget { get; private set; }


    public UIStatsData(string version, string playerName)
    {
        Version = version;
        PlayerName = playerName;
        PlayerHealth = 0;
        PlayerTarget = null;
    }

    public void Update()
    {
        Version = Application.version;
        PlayerName = GlobalsConfig.Username;
        
        if(GlobalsConfig.Player == null)
            return;
        
        PlayerHealth = GlobalsConfig.Player.GetData().Health;
        Mobile target = GlobalsConfig.Player.GetTarget();     
        PlayerTarget = target == null ? "null" : target.GetData().EntityType.ToString();
    }
}

