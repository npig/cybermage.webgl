using Cybermage.GraphQL.Mutations;

namespace Cybermage
{
    public static class GlobalsConfig
    {
        public static bool Dev = true;
        public static string Username { get; private set; }
        public static Mobile Player { get; private set; }

        public static void SetUsername(string userName)
        {
            Username = userName;
        }
        
        public static void SetPlayer(Mobile player)
        {
            Player = player;
        }
    }

    public static class ResourceController
    {
        public static void BuildResource()
        {
            
        }
    }
}