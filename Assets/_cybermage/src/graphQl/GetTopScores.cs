using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Cybermage.GraphQL
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
        
        public static async UniTask<GetTopScoresResult[]> Query()
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