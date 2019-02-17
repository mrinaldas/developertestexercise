using FileAttributeChecker;
using NUnit.Framework;
using ThirdPartyTools;
using System.Linq;

namespace FileData.Tests
{
    [TestFixture("-s", FileAttribute.Size)]
    [TestFixture("--s", FileAttribute.Size)]
    [TestFixture("/s", FileAttribute.Size)]
    [TestFixture("--size", FileAttribute.Size)]
    [TestFixture("-v", FileAttribute.Version)]
    [TestFixture("--v", FileAttribute.Version)]
    [TestFixture("/v", FileAttribute.Version)]
    [TestFixture("--version", FileAttribute.Version)]
    public class FileAttributeRequestHandlerPositiveTests
    {
        private string _filePath = @"C:\test.txt";
        private readonly string _attributeRequest;
        private readonly FileAttribute _attribute;

        public FileAttributeRequestHandlerPositiveTests(string attributeRequest, FileAttribute attribute)
        {
            _attributeRequest = attributeRequest;
            _attribute = attribute;
        }

        [Test]
        public void TestGetFileSize_ShouldReturnFileAttribute()
        {
            var classUnderTest = new FileAttributeRequestHandler(new FileAttributeRequestParser(), new FileDetails());

            var fileAttribute = classUnderTest.GetFileAttribute(_attributeRequest, _filePath);

            Assert.That(!string.IsNullOrEmpty(fileAttribute), "File attribute is expected to be non-null value.");
            if (_attribute == FileAttribute.Size)
            {
                int fileSize;
                if (!int.TryParse(fileAttribute, out fileSize))
                {
                    Assert.Fail("File size must be an integer.");
                }

                Assert.That(fileSize > 0, "File size much be greater than zero.");
            }
            else if(_attribute == FileAttribute.Version)
            {
                var versionStringArray = fileAttribute.Split('.');
                Assert.That(versionStringArray != null && versionStringArray.Length >= 3, "Invalid file version.");

                foreach (var versionComponent in versionStringArray)
                {
                    int versionNumber;
                    Assert.That(int.TryParse(versionComponent, out versionNumber), "File version parts must be numeric.");
                }
            }
            
        }
    }
}
