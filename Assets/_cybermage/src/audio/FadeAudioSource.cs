using Cybermage;
using Cybermage.Core;
using UnityEngine;

public class FadeAudioSource
{
    public enum AudioFade
    {
        FadeIn,
        FadeOut
    }

    private Timer _timer;
    private AudioSource _audioSource;
    private AudioFade _fadeType;
    private float _volume;

    public FadeAudioSource(AudioSource audioSource, AudioFade fadeType, float volume, float duration = 1)
    {
        _timer = new Timer();
        _timer.Duration = duration;
        _timer.UpdateAction = FadeUpdate;
        _timer.FinishedAction = FadeComplete;

        _volume = volume;
        _audioSource = audioSource;
        _fadeType = fadeType;

        TimerManager.StartTimer(_timer);
    }

    private void FadeUpdate(float t)
    {
        if(!_audioSource)
            return;

        t = Mathf.Clamp(t, 0, _volume);
            
        if (_fadeType == AudioFade.FadeIn)
        {
            _audioSource.volume = t;
        }
        else
        {
            _audioSource.volume -= t;
        }
    }

    private void FadeComplete()
    {
        if (!_audioSource)
            return;

        if (_fadeType != AudioFade.FadeIn)
        {
            _audioSource.Stop();
        }
    }
}