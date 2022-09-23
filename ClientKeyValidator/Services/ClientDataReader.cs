class ClientDataReader
{
    public static IEnumerable<Client>? GetMockData { get; private set; }

    public static async void ReadData(string stringPath)
    {
        //initialize new list to hold data
        List<Client> data = new();

        try
        {
            //instatitae stream reader and pass in file to read
            using var r = new StreamReader(stringPath);
            
            while (r.Peek() > -1)
            {
                //read records asynchronously
                string? tempData = await r.ReadLineAsync();


                //split data using delimiter
                var strippedData = tempData!.Split(";").ToList();


                //define dob variables
                string year = string.Empty, month = string.Empty, day = string.Empty;

                
                //check and remove blank records
                for (int i = 0; i < strippedData.Count; i++)
                    if (string.IsNullOrEmpty(strippedData.ElementAt(i)) && string.IsNullOrEmpty(strippedData.ElementAt(i)))
                        strippedData.RemoveAt(i);


                //check count of list items
                switch (strippedData.Count)
                {
                    case 3:
                        //get dob by yyyy mm dd
                        year = strippedData.ElementAt(2).Substring(0, 4);
                        month = strippedData.ElementAt(2).Substring(4, 2);
                        day = strippedData.ElementAt(2).Substring(6, 2);


                        //check if dob is valid and create new client
                        if (DateTime.TryParse(year + "-" + month + "-" + day, out DateTime validDob))
                            data.Add(new Client { FirstName = strippedData[0], LastName = strippedData[1], DateOfBirth = validDob });
                        else
                            data.Add(new Client { FirstName = strippedData[0], LastName = strippedData[1], DateOfBirth = default });

                        break;

                    case 4:
                        //get dob by yyyy mm dd
                        year = strippedData.ElementAt(3).Substring(0, 4);
                        month = strippedData.ElementAt(3).Substring(4, 2);
                        day = strippedData.ElementAt(3).Substring(6, 2);


                        //check if dob is valid and create new client
                        if (DateTime.TryParse(year + "-" + month + "-" + day, out DateTime validDOB))
                            data.Add(new Client { FirstName = strippedData[0], MiddleName = strippedData[1], LastName = strippedData[2], DateOfBirth = validDOB });
                        else
                            data.Add(new Client { FirstName = strippedData[0], MiddleName = strippedData[1], LastName = strippedData[2], DateOfBirth = default });
                        break;
                }
            }
        }
        catch (Exception e)
        {
            Console.Clear();
            Console.WriteLine("\nError occured\n");
            Console.WriteLine($"\nMessage -> {e.Message}");
            Console.WriteLine($"\n\nStackTrace\n\n{e.StackTrace}\n\n");
        }

        GetMockData = data;
    }
}