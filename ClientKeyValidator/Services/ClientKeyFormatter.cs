namespace ClientKeyValidator.Services
{
    internal class ClientKeyFormatter
    {
        public static string FormatInput(Client client)
        {
            string tempFirst = string.Empty, tempMiddle = string.Empty, tempLast, shortLastName , finalOutput = string.Empty;

            try
            {
                if (client.FirstName!.Length > 0)
                    tempFirst = client.FirstName!.Substring(0, 1);


                if (!string.IsNullOrEmpty(client.MiddleName) && !string.IsNullOrWhiteSpace(client.MiddleName))
                    tempMiddle = client.MiddleName!.Substring(0, 1);


                if (client.LastName!.Length > 0 && client.LastName!.Length < 5)
                {
                    tempLast = client.LastName!.Substring(0, client.LastName!.Length) + "....";
                    shortLastName = tempLast.Substring(0, 5);
                    tempLast = shortLastName;
                }
                else
                    tempLast = client.LastName!;


                if (client.LastName.Length - tempLast.Length > 0)
                    return tempLast + (client.LastName.Length - tempLast.Length) + tempFirst + (client.FirstName.Length - tempFirst.Length) + 0;


                finalOutput = tempLast + tempFirst + (client.FirstName.Length - tempFirst.Length) + tempMiddle;
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("\nError occured\n");
                Console.WriteLine("\nMessage -> Failed to create key. Please check your datasource and verify that the data is in the expected format.");
                Console.WriteLine($"\n\nStackTrace\n\n{e.StackTrace}\n\n");
            }


            return finalOutput;
        }
    }
}
