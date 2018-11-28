using System;
using GitHub.Logging;
using NUnit.Framework;
using GitHub.Unity;


namespace UnitTests
{
    [TestFixture]
    public class HostAddressTests
    {
        // This test checks whether the Uri is a Github address or not.
        [Test]
        public void IsUriAGithubAddress()
        {
            Uri test = new Uri("https://github.com");
            Uri test2 = new Uri("https://api.github.com");
            Assert.True(HostAddress.IsGitHubDotCom(test));
            Assert.True(HostAddress.IsGitHubDotCom(test2));
        }

        // Likewise, this tests fails as the Uri is not a Github address.
        [Test]
        public void UriIsNotAGitHubAddress()
        {
            Uri test = new Uri("https://gorphub.com");
            Assert.False(HostAddress.IsGitHubDotCom(test));
        }

        // This test assures that an exception is thrown when attempting to create a host with an invalid input.
        [Test]
        public void CreateInvalidHost()
        {
            Assert.Throws<InvalidOperationException>(() => HostAddress.Create("{0}"));
        }
    }
}
