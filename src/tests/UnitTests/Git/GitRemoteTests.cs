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

        [Test]
        public void ShouldNotEqualDifferentRemote()
        {
            var gitRemote = new GitRemote("Name",
                "Host", "URL",
                GitRemoteFunction.Unknown,
                "User",
                "Login", "Token");

            var gitRemote2 = new GitRemote("`Name",
               "`Host", "`URL",
               GitRemoteFunction.Push,
               "`User",
               "`Login", "`Token");

            gitRemote.AssertNotEqual(gitRemote2);
        }
    }
}
