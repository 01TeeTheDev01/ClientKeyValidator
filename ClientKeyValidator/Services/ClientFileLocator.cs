namespace ClientKeyValidator.Services
{
	internal class ClientFileLocator
	{

		public static string ClientFilePath()
		{
			string filePath = string.Empty;

			try
			{
				while (filePath == string.Empty)
				{
					Console.Clear();

					Console.WriteLine("\n===[Client key verifier]===\n");

					Console.WriteLine("Enter full path and extension of filename:");
					Console.WriteLine(@"E.g. c:\users\john\myfile\data.csv");
					Console.Write("\nFile path: ");
					filePath = Console.ReadLine()!;

					if (!string.IsNullOrEmpty(filePath) && !string.IsNullOrWhiteSpace(filePath))
						break;
				}
			}
			catch (Exception ex)
			{
				Console.Clear();
				Console.WriteLine($"Error occured\n\nMessage -> {ex.Message}\n\nStackTrace:\n\n{ex.StackTrace}");
			}

			return filePath;
		}
	}
}
