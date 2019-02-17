using System;
using System.Collections.Generic;
using System.Linq;

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
            if (string.IsNullOrEmpty(functionality))
            {
                throw new ArgumentNullException(functionality);
            }

            var command = functionality.Trim().ToUpper();
            return _expectedCommands.ContainsKey(command) ? _expectedCommands[command] : FileAttribute.Unknown;
        }
    }
}
