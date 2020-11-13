using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Cybermage.Common
{
    public static class AudioManager
    {
        private static Dictionary<string, Clips> _audioCollection = new Dictionary<string, Clips>();
        
        public static void Awake()
        {
            Task<CM_Audio> audioJson = ResourceController.LoadFile<CM_Audio>("cm_audio.json");
            
            foreach (Clips clip in audioJson.Result.Clips)
            {
                Debug.Log(clip.Resource);
                _audioCollection.Add(clip.Resource, clip);
            }
        }
        
        public static void PlaySample(Vector3 position)
        {
            
        }
    }

    public class CM_Audio
    {
        public Clips[] Clips;
    }

    public class Clips
    {
        public string Resource;
        public string MixerGroup;
        public float Volume;
        public float Pitch;
        public bool Loop;
    }
}