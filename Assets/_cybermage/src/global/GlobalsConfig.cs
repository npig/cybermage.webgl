using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

namespace Cybermage
{
    public enum GameState
    {
        Active,
        Standby,
    }
    
    public static class GlobalsConfig
    {
        public static bool Dev;
        public static CM_Information Information { get; private set; }
        
        public static string Username { get; private set; }
        public static int Difficulty = 3;
        public static int CorpseRemoval = 4200;

        public static GameState GameState = GameState.Standby;
        public static Mobile Player { get; set; }
        public static int Score = 0;
        public static List<Mobile> MobileCollection { get; set; } = new List<Mobile>();
        
        public static void Initialise(bool devMode)
        {
            Dev = devMode;
            GetLibrary();
        }
        
        private static async UniTaskVoid GetLibrary()
        {
            Information = await ResourceController.LoadFile<CM_Information>("cm_info.json");
        }

        public static void ResetGame()
        {
            MobileCollection.Clear();
            MobileCollection = new List<Mobile>();
            Player = null;
            Score = 0;
            GameState = GameState.Standby;
        }
        
        public static void SetUsername(string userName)
        {
            Username = userName;
        }
    }

    public static class ResourceController
    {
        private static string GetLocalLocation(string fileName)
        {
            return $"https://cybermage.live/StreamingAssets/{fileName}";
        }

        public static async UniTask<T> LoadFile<T>(string s)
        {
            UnityWebRequest request = UnityWebRequest.Get(GetLocalLocation(s));
            try
            {
                await request.SendWebRequest();
                string responseString = request.downloadHandler.text;
                T response = JsonConvert.DeserializeObject<T>(responseString);
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
    
    public static class CM_Theme
    {
        public static readonly Color H1 = new Color32(246,1,157, 255);
        public static readonly Color H3 = new Color32(84,19,136, 255);
        public static readonly Color Text = new Color32(244,244,244, 255);
        public static readonly Color Link = new Color32(84,19,136, 255);
        public static readonly Color LinkHighlight = new Color32(246,1,157, 255);
        public static readonly Color Background = new Color32(36,23,52, 255);


        public static void SetColor(TextMeshProUGUI text, CM_Style style)
        {
            text.color = ColorMap(style);
        }

        private static Color ColorMap(CM_Style style)
        {
            switch (style)
            {
                case CM_Style.H1:
                    return H1;
                case CM_Style.H3:
                    return H3;
                case CM_Style.Text:
                    return Text;
                case CM_Style.Link:
                    return Link;
                case CM_Style.LinkVisited:
                    return LinkHighlight;
                default:
                    return Color.white;
            }
        }
    }

    public enum CM_Style
    {
        Default,
        H1,
        H3,
        Text,
        Link,
        LinkVisited
    }
    
    public class CM_Information
    {
        public Biography biography;
        public string[] features;
        public Skills[] skills;
        public Folio[] folio;
    }

    public class Biography
    {
        public string name;
        public string content;
        public string email;
        public string linkedin;
        public string imdb;
    }
    
    public class Skills
    {
        public string header;
        public string content;
    }
    
    public class Folio
    {
        public string header;
        public string[] tags;
        public string content;
    }
}