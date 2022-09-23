namespace ClientKeyValidator.Services
{
    internal class ClientMockData
    {
        private static readonly List<Client> keysList = new();

        public static void AddKeyToList(Client client)
        {
            try
            {
                if (keysList != null)
                {
                    int duplicateCount = 0;

                    client.UniqueKey = client.UniqueKey + "-" + (duplicateCount + 1);

                    keysList.Add(client);

                    duplicateCount = 0;
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("\nError occured\n");
                Console.WriteLine("\nMessage -> Failed to initialize list.");
                Console.WriteLine($"\n\nStackTrace\n\n{e.StackTrace}\n\n");
            }
        }

        public static IEnumerable<Client> GetClientKeys()
        {
            return keysList;
        }

        public static int GetClientKeyCount()
        { 
            return keysList.Count;
        }
    }
}
