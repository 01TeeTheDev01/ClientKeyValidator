namespace ClientKeyValidator.Services
{
    internal class KeyValidator
    {
        public static IEnumerable<Client> ValidateKeys()
        {
            try
            {
                if (ClientMockData.GetClientKeys() != null)
                {
                    for (int clientCounter = 0; clientCounter < ClientMockData.GetClientKeys().Count(); clientCounter++)
                    {
                        var duplicateKeys = ClientMockData.GetClientKeys()
                                                                     .Where(key => key.UniqueKey!.Equals(ClientMockData.GetClientKeys().ElementAt(clientCounter).UniqueKey))
                                                                     .ToList();

                        if (duplicateKeys.Count > 1)
                        {
                            for (int counter = 0; counter < duplicateKeys.Count - 1; counter++)
                            {
                                var nextClient = duplicateKeys.ElementAt(counter + 1);

                                int nextClientIndex = ClientMockData.GetClientKeys().ToList().IndexOf(nextClient);

                                var splitVal = nextClient.UniqueKey.Split('-');

                                if (int.TryParse(splitVal[1], out int dup))
                                {
                                    splitVal[1] = (++dup).ToString();

                                    ClientMockData.GetClientKeys().ElementAt(nextClientIndex).UniqueKey = string.Join('-', splitVal);
                                }
                            }
                        }    
                    }
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("\nError occured\n");
                Console.WriteLine("\nMessage -> Failed to initialize list.");
                Console.WriteLine($"\n\nStackTrace\n\n{e.StackTrace}\n\n");
            }

            return ClientMockData.GetClientKeys();
        }
    }
}
