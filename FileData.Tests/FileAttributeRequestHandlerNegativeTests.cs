using System;
using FileAttributeChecker;
using NUnit.Framework;
using ThirdPartyTools;
using System.Linq;

namespace FileData.Tests
{
    [TestFixture("---s", FileAttribute.Size)]
    [TestFixture("-/s", FileAttribute.Size)]
    [TestFixture("/size", FileAttribute.Size)]
    [TestFixture("----size", FileAttribute.Size)]
    [TestFixture("---v", FileAttribute.Version)]
    [TestFixture("-/v", FileAttribute.Version)]
    [TestFixture("/version", FileAttribute.Version)]
    [TestFixture("----version", FileAttribute.Version)]
    public class FileAttributeRequestHandlerNegativeTests
    {
        private string _filePath = @"C:\test.txt";
        private readonly string _attributeRequest;
        private readonly FileAttribute _attribute;

        public FileAttributeRequestHandlerNegativeTests(string attributeRequest, FileAttribute attribute)
        {
            this._attributeRequest = attributeRequest;
            this._attribute = attribute;
        }

        [Test]
        public void TestGetFileSize_ShouldThrowException()
        {
            var classUnderTest = new FileAttributeRequestHandler(new FileAttributeRequestParser(), new FileDetails());
            Assert.Throws<Exception>(() => classUnderTest.GetFileAttribute(_attributeRequest, _filePath));
        }
    }
}
