using System.Text;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Cybermage.API
{
    public static class GraphQuery
    {
        private const string ApiURL = "https://slipgate.vercel.app/api/graphql";
        private static string query = @"
            query {
                users {
                    userName                    
                  }
              }";

        public static async void Query()
        {
            UnityWebRequest request = UnityWebRequest.Post(ApiURL, UnityWebRequest.kHttpVerbPOST);
            var fullQuery = new GraphQLQuery() {
                query = query,
            };
            
            string json = JsonConvert.SerializeObject(fullQuery);
            byte[] payload = Encoding.UTF8.GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(payload);
            request.SetRequestHeader("Content-Type", "application/json");
            await request.SendWebRequest();
            
            if (request.isNetworkError) {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);
            }
        }
        
    }
    
    public class GraphQLQuery {
        public string query;
        public object variables;
    }

}