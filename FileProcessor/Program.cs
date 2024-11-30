using FileProcessor.Services;
using FileProcessor.TextProcessor.TextFilter;
using Microsoft.Extensions.DependencyInjection;
internal class Program
{
    private static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IFileService, FileService>()
            .AddSingleton<IFilter, VowelInMiddleFilter>()
            .AddSingleton<IFilter, LengthLessThanThreeFilter>()
            .AddSingleton<IFilter, CharTFilter>()
            .BuildServiceProvider();

        var fileProcessor = serviceProvider.GetService<IFileService>();
        try 
        {
            string? filePath;
            if(args.Length == 0 || string.IsNullOrEmpty(args[0]))
            {
                Console.WriteLine("Please provide a file path and press enter:\n");
                filePath = Console.ReadLine();
            }
            else
            {
                filePath = args[0];
            }
            if(string.IsNullOrEmpty(filePath))
            {
                Console.WriteLine("File path cannot be empty. press any key to exit.");
                Console.ReadKey();
                return;
            }
            if (fileProcessor != null)
            {
                string result = fileProcessor.processFilters(filePath.ToString());
            }
            else
            {
                throw new Exception("Error in initializing the service.");
            }
        } 
        catch (Exception e) 
        {
            Console.WriteLine(e.Message);
        }
    }


}