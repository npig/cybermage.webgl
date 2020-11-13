using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Networking;

namespace Cybermage.Common
{
    public static class AudioManager
    {
        private static Dictionary<string, Clips> _audioCollection;
        private static AudioMixer _mixer;
        
        public static void Awake()
        {
            _mixer = CM_Resources.Mixer;
            _audioCollection = new Dictionary<string, Clips>();
            CM_Audio audioCollection = ResourceController.LoadFile<CM_Audio>("cm_audio.json").Result;
            
            foreach (Clips clip in audioCollection.Clips)
            {
                _audioCollection.Add(clip.Name, clip);
            }
        }
        
        public static void PlaySample(string name)
        {
            _audioCollection.TryGetValue(name, out Clips clipData);
            
            if (clipData == null)
                return;
            
            GameObject go = new GameObject($"cm_audio: {name}");
            go.transform.position = MainCamera.Camera.transform.position;
            AudioSource source = go.AddComponent<AudioSource>();
            AudioClip clip = Resources.Load<AudioClip>(clipData.Resource);
            source.outputAudioMixerGroup = _mixer.FindMatchingGroups(clipData.MixerGroup)[0];
            source.clip = clip;
            source.volume = clipData.Volume;
            source.pitch = clipData.Pitch;
            source.loop = clipData.Loop;
            source.Play();
        }
    }

    public class CM_Audio
    {
        public Clips[] Clips;
    }

    public class Clips
    {
        public string Name;
        public string Resource;
        public string MixerGroup;
        public float Volume;
        public float Pitch;
        public bool Loop;
    }
}