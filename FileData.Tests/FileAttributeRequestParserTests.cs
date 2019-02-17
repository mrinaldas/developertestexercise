using System;
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
    [TestFixture("--versionn", FileAttribute.Unknown)]
    [TestFixture("--siz", FileAttribute.Unknown)]
    public class FileAttributeRequestParserTests
    {
        private readonly string _attributeRequest;
        private readonly FileAttribute _attribute;

        public FileAttributeRequestParserTests(string attributeRequest, FileAttribute attribute)
        {
            _attributeRequest = attributeRequest;
            _attribute = attribute;
        }

        [Test]
        public void TestParseFileAttributeRequest()
        {
            IFileAttributeRequestParser classUnderTest = new FileAttributeRequestParser();
            var fileAttribute = classUnderTest.ParseFileAttributeRequest(_attributeRequest);

            Assert.That(fileAttribute == _attribute);
        }
    }
}
