using Cybermage.GraphQL.Mutations;

namespace Cybermage
{
    public static class GlobalsConfig
    {
        public static string Username { get; private set; }

        public static void SetUsername(string userName)
        {
            Username = userName;
        }
    }

    public static class ResourceController
    {
        public static void BuildResource()
        {
            
        }
    }
}