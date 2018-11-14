using GitHub.Unity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTests.Primitives
{
    [TestFixture]
    class UriStringTests
    {
        //Existing test, this is checks the filename value of uriString.
        [TestCase("http://url.com/path/file.zip?cb=1", "file.zip")]
        [TestCase("http://url.com/path/file?cb=1", "file")]
        public void FilenameParsing(string url, string expectedFilename)
        {
            var uriString = new UriString(url);
            Assert.AreEqual(expectedFilename, uriString.Filename);
        }

        //Checks the host value of uriString.
        [TestCase("http://url.com/path/file.zip?cb=1", "url.com")]
        [TestCase("http://url.com/path/file?cb=1", "url.com")]
        public void HostParsing(string url, string expectedHost)
        {
            var uriString = new UriString(url);
            Assert.AreEqual(expectedHost, uriString.Host);
        }

        //Checks the length of uriString.
        [TestCase("http://url.com/path/file.zip?cb=1", 33)]
        [TestCase("http://url.com/path/file?cb=1", 29)]
        public void LengthParsing(string url, int expectedLength)
        {
            var uriString = new UriString(url);
            Assert.AreEqual(uriString.Length, expectedLength);
        }

        //Checks the owner value of uriString.
        [TestCase("http://url.com/path/file.zip?cb=1", "path")]
        [TestCase("http://url.com/path/file?cb=1", "path")]
        public void OwnerParsing(string url, string expectedOwner)
        {
            var uriString = new UriString(url);
            Assert.AreEqual(expectedOwner, uriString.Owner);
        }

        //Checks the protocol value of uriString.
        [TestCase("http://url.com/path/file.zip?cb=1", "http")]
        [TestCase("http://url.com/path/file?cb=1", "http")]
        public void ProtocolParsing(string url, string expectedProtocol)
        {
            var uriString = new UriString(url);
            Assert.AreEqual(expectedProtocol, uriString.Protocol);
        }

        //Checks the repository value of uriString.
        [TestCase("http://url.com/path/file.zip?cb=1", "file.zip")]
        [TestCase("http://url.com/path/file?cb=1", "file")]
        public void RepositoryParsing(string url, string expectedRepository)
        {
            var uriString = new UriString(url);
            Assert.AreEqual(expectedRepository, uriString.RepositoryName);
        }

        //Generates a completely random url of varying length and checks uriString's values against it.
        [Test]
        public void GenerateRandomUriAndCheckValues()
        {
            var charlist = "abcdefghijklmnopqrstuvwxyz";
            var random = new Random();
            for (int stringLength = 2; stringLength < 100; stringLength++)
            {
                var randomString = new char[stringLength];
                for (int y = 0; y < randomString.Length; y++)
                {
                    randomString[y] = charlist[random.Next(charlist.Length)];
                }
                var testString = new String(randomString);
                String url = (testString + "://" + testString + "/" + testString + "/" + testString);
                var uriString = new UriString(url);
                Assert.AreEqual(testString, uriString.Filename);
                Assert.AreEqual(testString, uriString.Host);
                Assert.AreEqual(testString, uriString.Owner);
                Assert.AreEqual(testString, uriString.Protocol);
                Assert.AreEqual(testString, uriString.RepositoryName);
                Assert.AreEqual(stringLength, uriString.Filename.Length);
            }
        }
    }
}
