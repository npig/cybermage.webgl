using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;
using UnityEngine.Audio;
using Object = UnityEngine.Object;

namespace Cybermage
{
    //Audio Mixer groups to be added here
    public enum MixGroup
    {
        Music,
        Effect,
        Ambient,
    }

    public class AudioReceiver
    {
        public AudioSample AudioSample { get; }
        public AudioSource AudioSource { get; }
        public GameObject GameObject => AudioSource.gameObject;
        public bool KeepAlive { get; set; }

        public AudioReceiver(AudioSample sample, AudioSource source)
        {
            AudioSample = sample;
            AudioSource = source;
        }
    }

    public static class AudioManager
    {
        private static GameObject _audioManager;
        private static AudioMixer _audioMixer;
        private static readonly List<AudioReceiver> _audioReceivers = new List<AudioReceiver>();
        private static readonly Dictionary<string, AudioSample> _audioCollection = new Dictionary<string, AudioSample>();

        public static void Awake()
        {
            _audioManager = new GameObject("Audio Manager");
            Object.DontDestroyOnLoad(_audioManager);
            _audioMixer = CM_Resources.Mixer;
            CM_Audio audioCollection = ResourceController.LoadFile<CM_Audio>("cm_audio.json").Result;

            foreach (AudioSample clip in audioCollection.AudioSample)
            {
                _audioCollection.Add(clip.Name, clip);
            }
        }
        
        /// <summary>
        /// Play Audio Sample from Collection at Position
        /// </summary>
        /// <param name="sampleName"></param>
        /// <param name="position"></param>
        public static void PlaySampleAtPosition(string sampleName, Vector3 position)
        {
            _audioCollection.TryGetValue(sampleName, out AudioSample sample);
            
            if(sample == null)
                return;

            AudioReceiver receiver = CreateAudioObject(sample);
            receiver.GameObject.transform.position = position;
        }
        
        /// <summary>
        /// Play Audio Sample from Collection
        /// </summary>
        /// <param name="sampleName"></param>
        public static void PlaySample(string sampleName)
        {
            _audioCollection.TryGetValue(sampleName, out AudioSample sample);

            if (sample == null)
            {
                Debug.Log($"{sampleName} invalid");
                return;
            }

            CreateAudioObject(sample);
        }
        
        public static void StopAudio(float time)
        {
            foreach (var receiver in _audioReceivers)
            {
                FadeAudioSource fadeAudioSource = new FadeAudioSource(receiver.AudioSource, FadeAudioSource.AudioFade.FadeOut, receiver.AudioSample.Volume);
            }
        }

        private static AudioReceiver CreateAudioObject(AudioSample audioSample, bool keepAlive = false)
        {
            float fadeInDuration = 1;
            GameObject audioObject = new GameObject("Playing [" + audioSample.Name + "]");
            audioObject.transform.SetParent(_audioManager.transform);
            AudioSource audioSource = SetAudioSource(audioObject, audioSample);
            audioSource.loop = audioSample.Loop;

            if (audioSample.MixGroup != MixGroup.Effect)
            {
                audioSource.volume = 0;
                audioSource.Play();
                FadeAudioSource fadeAudioSource = new FadeAudioSource(audioSource, FadeAudioSource.AudioFade.FadeIn, audioSample.Volume, fadeInDuration);
            }
            else
            {
                audioSource.volume = audioSample.Volume;
                audioSource.Play();
            }

            AudioReceiver receiver = new AudioReceiver(audioSample, audioSource);
            CheckActive(receiver);
            _audioReceivers.Add(receiver);
            return receiver;
        }

        private static AudioSource SetAudioSource(GameObject audioObject, AudioSample audioSample)
        {
            AudioSource audioSource = audioObject.AddComponent<AudioSource>();
            audioSource.clip = Resources.Load<AudioClip>($"audio/{audioSample.Name}");
            audioSource.volume = audioSample?.Volume ?? 1;
            AudioMixer mixer = _audioMixer;
            string buss = audioSample.MixGroup.ToString();
            AudioMixerGroup mixerGroup = mixer.FindMatchingGroups(buss)[0];
            audioSource.outputAudioMixerGroup = mixerGroup;
            return audioSource;
        }

        private static void CheckActive(AudioReceiver receiver)
        {
            AudioReceiver existingReceiver = _audioReceivers.Find(x => x == receiver);
            
            if (existingReceiver == null)
            {
                ActiveAudioSource(receiver);
            }
        }

        private static async void ActiveAudioSource(AudioReceiver receiver)
        {
            while (receiver.AudioSource.isPlaying)
            {
                 await UniTask.Delay(60);
            }
            
            if (receiver.GameObject != null)
            {
                Object.Destroy(receiver.GameObject);
            }
            
            _audioReceivers.Remove(receiver);
        }
    }
    
    public class CM_Audio
    {
        public AudioSample[] AudioSample;
    }

    public class AudioSample
    {
        public string Name;
        [JsonConverter(typeof(StringEnumConverter))]
        public MixGroup MixGroup;
        public float Volume;
        public float Pitch;
        public bool Loop;
    }
}


