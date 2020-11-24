using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Cybermage.GraphQL
{
    public class UpdateScoreResult
    {
       public string userName;
       public string score;
    }
    
    public class UpdateScoreInput
    {
        public int score { get; private set; }

        public UpdateScoreInput(int score)
        {
            this.score = score;
        }
    }
    
    public static class UpdateScore 
    {
        private static string _query = @"
            mutation ($score: Int!) {
                result: updateScore (score: $score) {
                    userName
                    score
                  }
              }";
        
        public static async Task<UpdateScoreResult> Query(int score)
        {
            UpdateScoreInput variables = new UpdateScoreInput(score);
            GraphQLQuery graphQLQuery = new GraphQLQuery(_query, variables);
            
            try
            {
                var response = await GraphQLClient.Request<GQLResponse<UpdateScoreResult>>(graphQLQuery);
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