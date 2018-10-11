using TestUtils;
using NUnit.Framework;
using GitHub.Unity;

namespace UnitTests
{
    [TestFixture]
    public class GitRemoteTests
    {
        [Test]
        public void ShouldEqualSelf()
        {
             var gitRemote = new GitRemote("Name",
                "Host", "URL",
                GitRemoteFunction.Unknown,
                "User",
                "Login", "Token");

            gitRemote.AssertEqual(gitRemote);
        }
    }
}
