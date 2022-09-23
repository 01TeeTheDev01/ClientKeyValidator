namespace ClientKeyValidator.Services
{
    internal class ClientDateValidator
    {
        public static char ValidateDate(Client client)
        {
            try
            {
                if (client != null)
                {
                    var oldestDate = new DateTime(1900, 01, 01);

                    if (client.DateOfBirth >= oldestDate && client.DateOfBirth <= DateTime.Now)
                    {
                        client.ValidIndicator = 'Y';

                        return client.ValidIndicator;
                    }

                    client.DateOfBirth = default;

                    client.ValidIndicator = 'N';
                }

            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("\nError occured\n");
                Console.WriteLine("\nMessage -> There's a problem parsing the data. Please check your datasource and verify that the data is in the expected format.");
                Console.WriteLine($"\n\nStackTrace\n\n{e.StackTrace}\n\n");
            }

            return client!.ValidIndicator;
        }
    }
}
