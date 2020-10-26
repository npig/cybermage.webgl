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

        public static async Task<T> Request<T>(GraphQLQuery query)
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
                T responseJSON = JsonConvert.DeserializeObject<T>(responseString);
                return responseJSON;
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

    public class GQLData<T>
    {
        public T result;
    }

    public class GQLResponse<T>
    {
        public GQLData<T> data;
    }
}
