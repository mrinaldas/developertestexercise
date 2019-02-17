using System;
using FileAttributeChecker;
using NUnit.Framework;
using ThirdPartyTools;
using System.Linq;

namespace FileData.Tests
{
    public class FileAttributeRequestHandlerParameterTests
    {
        private string _filePath = @"C:\test.txt";

        [Test]
        public void TestGetFileSize_NullAttributeRequest_ShouldThrowArgumentNullException()
        {
            var classUnderTest = new FileAttributeRequestHandler(new FileAttributeRequestParser(), new FileDetails());
            Assert.Throws<ArgumentNullException>(() => classUnderTest.GetFileAttribute(null, _filePath));
        }

        [Test]
        public void TestGetFileSize_NullFilePath_ShouldThrowArgumentNullException()
        {
            var classUnderTest = new FileAttributeRequestHandler(new FileAttributeRequestParser(), new FileDetails());
            Assert.Throws<ArgumentNullException>(() => classUnderTest.GetFileAttribute("-s", null));
        }
    }
}
