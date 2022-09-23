namespace ClientKeyValidator.Services
{
    internal class RunClientValidator
    {
        public static async Task BeginExec()
        {
            await Task.Run(() =>
            {
                //Get file path
                string path = ClientFileLocator.ClientFilePath();


                Console.Clear();

                //Read data from file
                ClientDataReader.ReadData(path);


                Console.WriteLine("\n===[Client Keys]===\n");


                //Format data into expected format
                foreach (var mockObj in ClientDataReader.GetMockData!)
                    ClientKeyDataDisplay.ValidateData(mockObj);


                //Sort data and display
                foreach (var item in KeyValidator.ValidateKeys().OrderBy(k => k.UniqueKey))
                    ClientKeyDataDisplay.DisplayKeyData(item);


                //Output results
                Console.WriteLine($"\nTotal keys processed: {ClientMockData.GetClientKeyCount()}");


                Console.Write("\n\nPress any key to exit....");

                Console.ReadKey();
            });
        }
    }
}
