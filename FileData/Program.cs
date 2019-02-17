using System;
using FileAttributeChecker;
using ThirdPartyTools;

namespace FileData
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            IFileAttributeRequestHandler fileAttributeRequestHandler =
                new FileAttributeRequestHandler(new FileAttributeRequestParser(), new FileDetails());

            var attribute = fileAttributeRequestHandler.GetFileAttribute(args[0], args[1]);

            Console.WriteLine("File Attribute : {0}", attribute);
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}
