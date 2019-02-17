using System;
using ThirdPartyTools;

namespace FileAttributeChecker
{
    public class FileAttributeRequestHandler : IFileAttributeRequestHandler
    {
        private readonly FileDetails _fileDataTools;
        private readonly IFileAttributeRequestParser _fileAttributeRequestParser;
        
        public FileAttributeRequestHandler(IFileAttributeRequestParser fileAttributeRequestParser, FileDetails fileAttributeCheckerTools)
        {
            _fileAttributeRequestParser = fileAttributeRequestParser ?? throw  new ArgumentNullException(nameof(fileAttributeRequestParser));
            _fileDataTools = fileAttributeCheckerTools ?? throw new ArgumentNullException(nameof(fileAttributeCheckerTools));
        }

        public string GetFileAttribute(string attributeRequest, string filePath)
        {
            if (string.IsNullOrEmpty(attributeRequest))
            {
                throw new ArgumentNullException(attributeRequest);
            }

            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException(filePath);
            }

            var fileAttribute = _fileAttributeRequestParser.ParseFileAttributeRequest(attributeRequest);

            if (fileAttribute == FileAttribute.Size)
            {
                return _fileDataTools.Size(filePath).ToString();
            }

            if(fileAttribute == FileAttribute.Version)
            {
                return _fileDataTools.Version(filePath);
            }

            throw new Exception("Invalid file attribute requested.");
        }
    }
}
