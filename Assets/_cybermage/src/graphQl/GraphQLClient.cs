using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace Cybermage.GraphQL
{
    public static class GraphQLClient
    {
        private const string ApiURL = "https://slipgate.vercel.app/api/graphql";
        private const string Token = "";

        public static async Task<GraphQLResponse> Request(GraphQLQuery query)
        {
            string json = JsonConvert.SerializeObject(query);
            byte[] payload = Encoding.UTF8.GetBytes(json);

            UnityWebRequest request = UnityWebRequest.Post(ApiURL, UnityWebRequest.kHttpVerbPOST);
            request.uploadHandler = new UploadHandlerRaw(payload);

            //Set Headers
            request.SetRequestHeader("Content-Type", "application/json");
            
            if (!string.IsNullOrEmpty(Token))
                request.SetRequestHeader("Authorization", "Bearer " + Token);

            try
            {
                await request.SendWebRequest();
                string responseString = request.downloadHandler.text;
                GraphQLResponse result = new GraphQLResponse(responseString);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

    public class GraphQLQuery 
    {
        public string query;
        public object variables;

        public GraphQLQuery(string query, object variables = null)
        {
            this.query = query;

            if (variables != null)
            {
                this.variables = variables;
            }
        }
    }

    public class GraphQLResponse 
    {
        public string Raw { get; private set; }
        private readonly JObject data;
        public string Exception { get; private set; }
        
        public GraphQLResponse (string text, string ex = null) {
            Exception = ex;
            Raw = text;
            data = text != null ? JObject.Parse(text) : null;
        }
        
        public T Get<T> (string key) {
            return GetData()[key].ToObject<T>();
        }
        
        private JObject GetData () {
            return data == null ? null : JObject.Parse(data["data"].ToString());
        }
    }
    
    public class GQLMutationError
    {
        public string message = "";
        public string title = "";
        public string type = "";
    }
}

/* 
      private static string query = @"
            query {
                users {
                    userName                    
                  }
              }";
        
        private static string mutation = @"
            query {
                users {
                    userName                    
                  }
              }";


        public static async void QueryUsers()
        {
            UnityWebRequest request = UnityWebRequest.Post(ApiURL, UnityWebRequest.kHttpVerbPOST);
            GraphQLQuery fullQuery = new GraphQLQuery() {
                query = query,
                
            };
            string json = JsonConvert.SerializeObject(fullQuery);
            byte[] payload = Encoding.UTF8.GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(payload);
            request.SetRequestHeader("Content-Type", "application/json");
            await request.SendWebRequest();
            
            if (request.isNetworkError) {
                Debug.Log(request.error);
                return;
            }
            else
            {
                Debug.Log(request.downloadHandler.text);
                JsonConvert.DeserializeObject<>()
            }
        }
                
    }
*/