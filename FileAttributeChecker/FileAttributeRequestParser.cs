using System.Collections.Generic;

namespace FileAttributeChecker
{
    public class FileAttributeRequestParser : IFileAttributeRequestParser
    {
        private readonly Dictionary<string, FileAttribute> _expectedCommands = new Dictionary<string, FileAttribute>();

        public FileAttributeRequestParser()
        {
            _expectedCommands.Add("-V", FileAttribute.Version);
            _expectedCommands.Add("--V", FileAttribute.Version);
            _expectedCommands.Add("/V", FileAttribute.Version);
            _expectedCommands.Add("--VERSION", FileAttribute.Version);

            _expectedCommands.Add("-S", FileAttribute.Size);
            _expectedCommands.Add("--S", FileAttribute.Size);
            _expectedCommands.Add("/S", FileAttribute.Size);
            _expectedCommands.Add("--SIZE", FileAttribute.Size);
        }

        public FileAttribute ParseFileAttributeRequest(string functionality)
        {
            foreach (var expectedArgument in _expectedCommands)
            {
                if (expectedArgument.Key == functionality.ToUpper())
                {
                    return expectedArgument.Value;
                }
            }

            return FileAttribute.Unknown;
        }
    }
}
