using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Cybermage.GraphQL.Mutations
{
    public class AddUserResult
    {
       public string userName;
       public string error;
    }
    
    public class AddUserInput
    {
        public string input;

        public AddUserInput(string userName)
        {
            this.input = userName;
        }
    }
    
    public static class AddUser 
    {
        private static string _query = @"
            mutation ($input: String!) {
                addUser (userName: $input) {
                    userName
                    error
                  }
              }";
        
        public static async Task<AddUserResult> Query(string userName)
        {
            AddUserInput variables = new AddUserInput(userName);
            GraphQLQuery graphQLQuery = new GraphQLQuery(_query, variables);

            try
            {
                GraphQLResponse response = await GraphQLClient.Request(graphQLQuery);
                AddUserResult userResult = response.Get<AddUserResult>("addUser");
                return userResult;
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