using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientKeyValidator.Services
{
    internal class ClientCalculator
    {
        public static long AgeCalculator(Client client)
        {
            long age = default;

            try
            {
                age = DateTime.Now.Subtract(client.DateOfBirth).Ticks;
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("\nError occured\n");
                Console.WriteLine("\nMessage -> There's a problem parsing the data. Please check your datasource and verify that the data is in the expected format.");
                Console.WriteLine($"\n\nStackTrace\n\n{e.StackTrace}\n\n");
            }

            return age;
        }
    }
}
