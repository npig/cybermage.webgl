using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Cybermage.GraphQL
{
    public class AddUserResult
    {
       public string token;
       public string error;
    }
    
    public class AddUserInput
    {
        public string userName { get; private set; }
        public string password{ get; private set; }

        public AddUserInput(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }
    }
    
    public static class AddUser 
    {
        private static string _query = @"
            mutation ($userName: String!, $password: String!) {
                result: addUser (userName: $userName, password: $password) {
                    token
                    error
                  }
              }";
        
        public static async UniTask<AddUserResult> Query(string userName, string password)
        {
            AddUserInput variables = new AddUserInput(userName, password);
            GraphQLQuery graphQLQuery = new GraphQLQuery(_query, variables);

            try
            {
                var response = await GraphQLClient.Request<GQLResponse<AddUserResult>>(graphQLQuery);
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