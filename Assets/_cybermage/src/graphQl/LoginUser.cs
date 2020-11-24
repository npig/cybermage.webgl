using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Cybermage.GraphQL
{
    public class LoginUserResult
    {
       public string token;
       public string error;
    }
    
    public class LoginUserInput
    {
        public string userName { get; private set; }
        public string password{ get; private set; }

        public LoginUserInput(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }
    }
    
    public static class LoginUser
    {
        private static string _query = @"
            query ($userName: String!, $password: String!) {
                result: login (userName: $userName, password: $password) {
                    token
                    error
                  }
              }";
        
        public static async Task<LoginUserResult> Query(string userName, string password)
        {
            LoginUserInput variables = new LoginUserInput(userName, password);
            GraphQLQuery graphQLQuery = new GraphQLQuery(_query, variables);

            try
            {
                var response = await GraphQLClient.Request<GQLResponse<LoginUserResult>>(graphQLQuery);
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