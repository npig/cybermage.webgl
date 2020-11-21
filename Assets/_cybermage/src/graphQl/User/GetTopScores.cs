using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Cybermage.GraphQL.Mutations
{
    public class GetTopScoresResult
    {
        public string userName;
        public string score;
    }
    
    public static class GetTopScores 
    {
        private static string _query = @"
            query {
                result: topScores {
                    userName
                    score
                  }
              }";
        
        public static async Task<GetTopScoresResult[]> Query()
        {
            GraphQLQuery graphQLQuery = new GraphQLQuery(_query);

            try
            {
                var response = await GraphQLClient.Request<GQLResponse<GetTopScoresResult[]>>(graphQLQuery);
                return response.data.result;
            }
            catch (Exception e)
            {
                Debug.Log("Exception");
                System.Console.WriteLine(e.Message);
                
                return null;
            }
        }
    }
}