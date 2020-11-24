using System;
using System.Threading;
using Cybermage;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Stats : MonoBehaviour
{
    private UIStatsData _data;
    
    //Developer Console
    private TextMeshProUGUI _versionText;
    private TextMeshProUGUI _usernameText;
    private TextMeshProUGUI _playerHealthText;
    private TextMeshProUGUI _playerTargetText;
    
    //Player HUD
    private TextMeshProUGUI _scoreText;
    private TextMeshProUGUI _healthText;
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
        _healthText = Utilities.FindDeepChild<TextMeshProUGUI>(this.transform, "healthText");
        _scoreText = Utilities.FindDeepChild<TextMeshProUGUI>(this.transform, "scoreText");
        
        if (!GlobalsConfig.Dev)
            Utilities.FindDeepChild(transform, "consoleWrapper").gameObject.SetActive(false);
    }

    private void Start()
    {
        UpdateData();
    }

    private static CancellationTokenSource _cancellationTokenSource;

    public async UniTaskVoid UpdateData()
    {
        while (true)
        {
            await UniTask.Delay(120, DelayType.DeltaTime, PlayerLoopTiming.Update, this.GetCancellationTokenOnDestroy());
            
            if(_data == null)
                continue;
            
            _data.Update();
            _scoreText.text = _data.PlayerScore.ToString();
            UpdateHealth(_data.PlayerHealth);
            
            if (!GlobalsConfig.Dev)
                continue;
            
            UpdateText(_data);
        }
    }

    private void UpdateHealth(float dataPlayerHealth)
    {
        float f = dataPlayerHealth / 30;
        _leftHealth.fillAmount = f;
        _rightHealth.fillAmount = f;
        _healthText.text = dataPlayerHealth.ToString();
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
    public int PlayerScore { get; private set; }
    public string PlayerTarget { get; private set; }


    public UIStatsData(string version, string playerName)
    {
        Version = version;
        PlayerName = playerName;
        PlayerHealth = 0;
        PlayerTarget = null;
        PlayerScore = 0;
    }

    public void Update()
    {
        Version = Application.version;
        PlayerName = GlobalsConfig.Username;
        
        if(GlobalsConfig.Player == null)
            return;
        
        PlayerHealth = GlobalsConfig.Player.Health;
        Mobile target = GlobalsConfig.Player.GetTarget();     
        PlayerTarget = target == null ? "null" : target.EntityType.ToString();
        PlayerScore = GlobalsConfig.Score;
    }
}

