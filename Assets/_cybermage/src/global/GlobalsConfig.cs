using System;
using System.IO;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

namespace Cybermage
{
    public static class GlobalsConfig
    {
        public static bool Dev;
        public static string Username { get; private set; }
        public static Mobile Player { get; private set; }
        public static CM_Information Information { get; private set; }

        public static void Initialise(bool devMode)
        {
            Dev = devMode;
            Information = ResourceController.LoadInformation().Result;
        }
        
        public static void SetUsername(string userName)
        {
            Username = userName;
        }
        
        public static void SetPlayer(Mobile player)
        {
            Player = player;
        }
     }

    public static class ResourceController
    {
        private static string GetLocalLocation(string fileName)
        {
            return $"file://{Path.Combine(Application.streamingAssetsPath, fileName)}";
        }

        public static async Task<CM_Information> LoadInformation()
        {
            UnityWebRequest request = UnityWebRequest.Get(GetLocalLocation("cm_info.json"));
            try
            {
                await request.SendWebRequest();
                string responseString = request.downloadHandler.text;
                CM_Information information = JsonConvert.DeserializeObject<CM_Information>(responseString);
                return information;
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
        public static readonly Color Default = Color.magenta;
        public static readonly Color H1 = Color.green;
        public static readonly Color H3 = Color.green;
        public static readonly Color Text = Color.red;
        public static readonly Color Link = Color.yellow;
        public static readonly Color LinkVisited = Color.white;

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
                    return LinkVisited;
                default:
                    return Default;
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