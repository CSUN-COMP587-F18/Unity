using System;
using NUnit.Framework;
using GitHub.Unity;

namespace UnitTests
{
    [TestFixture]
    public class UriExtensionsTests
    {
        //This test checks that "boi" is properly appended to the end of the "test" Uri.
        [Test]
        public void AppendToURI()
         {
            Uri test = new Uri("http://url.com/path/");
            Uri result = new Uri("http://url.com/path/boi");
            Assert.True(result.Equals(UriExtensions.Append(test, "boi")));
         }

        // Same as before, except it's supposed to add a forward-slash at the end if there isn't one.
        [Test]
        public void AppendToURIWithoutForwardSlash()
        {
            Uri test = new Uri("http://url.com/path");
            Uri result = new Uri("http://url.com/path/boi");
            Assert.True(result.Equals(UriExtensions.Append(test, "boi")));
        }

        // This test succeeds if the Uri uses an HTTP or HTTPS protocol.
        [Test]
        public void IsHTTPOrHTTPS()
        {
            Uri test = new Uri("http://url.com/path/file.zip?cb=1");
            Uri test2 = new Uri("https://url.com/path/file.zip?cb=1");
            Assert.True(UriExtensions.IsHypertextTransferProtocol(test) && UriExtensions.IsHypertextTransferProtocol(test2));
        }

        // Likewise, this test fails if the Uri does not use an HTTP or HTTPS protocol.
        [Test]
        public void IsNotHTTPOrHTTPS()
        {
            Uri test = new Uri("randomtext://url.com/path/file.zip?cb=1");
            Assert.False(UriExtensions.IsHypertextTransferProtocol(test));
        }

        // This test succeeds if both Uris have the same host, that being "url.com".
        [Test]
        public void IsSameHost()
        {
            Uri test = new Uri("https://url.com/path/file.zip?cb=1");
            Uri test2 = new Uri("https://url.com/path/file.zip?cb=1");
            Assert.True(UriExtensions.IsSameHost(test, test2));
        }

        // This test fails if both Uris don't have the same host, that being "url.com" and "lru.com".
        [Test]
        public void IsNotSameHost()
        {
            Uri test = new Uri("https://url.com/path/file.zip?cb=1");
            Uri test2 = new Uri("https://lru.com/path/file.zip?cb=1");
            Assert.False(UriExtensions.IsSameHost(test, test2));
        }
    }
}
