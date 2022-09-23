namespace ClientKeyValidator.Services
{
    internal class ClientKeyDataDisplay
    {
        public static void DisplayKeyData(Client item)
        {
            if (item.ValidIndicator.Equals('Y'))
            {
                if (string.IsNullOrEmpty(item.MiddleName) && string.IsNullOrWhiteSpace(item.MiddleName))
                    Console.WriteLine($"{item.UniqueKey} | {item.ValidIndicator} | {item.FormattedYear} | {item.FirstName}, {item.LastName}\n");
                else
                    Console.WriteLine($"{item.UniqueKey} | {item.ValidIndicator} | {item.FormattedYear} | {item.FirstName}, {item.MiddleName}, {item.LastName}\n");
            }
            else
            {
                if (string.IsNullOrEmpty(item.MiddleName) && string.IsNullOrWhiteSpace(item.MiddleName))
                    Console.WriteLine($"{item.UniqueKey} | {item.ValidIndicator} | {item.FirstName}, {item.LastName}\n");
                else
                    Console.WriteLine($"{item.UniqueKey} | {item.ValidIndicator} | {item.FirstName}, {item.MiddleName}, {item.LastName}\n");
            }
        }

        public static void ValidateData(Client client)
        {
            if (ClientDateValidator.ValidateDate(client).Equals('Y'))
            {
                client.UniqueKey = ClientKeyFormatter.FormatInput(client);
                client.FormattedYear = $"{new DateTime(ClientCalculator.AgeCalculator(client)).Year} 0 0";
                ClientMockData.AddKeyToList(client);
            }
            else
            {
                client.UniqueKey = ClientKeyFormatter.FormatInput(client);
                ClientMockData.AddKeyToList(client);
            }
        }
    }
}
