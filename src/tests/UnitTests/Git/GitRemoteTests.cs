using TestUtils;
using NUnit.Framework;
using GitHub.Unity;

namespace UnitTests
{
    [TestFixture]
    public class GitRemoteTests
    {
        // This test checks gitRemote's values against themselves, intended to be equal.
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

        // This test checks gitRemote's values against a slightly different gitRemote, intended to be unequal.
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

        // This test verifies that each instance of gitRemote has a unique hash attached to it by comparing them.
        [Test]
        public void ShouldHaveUniqueHashCode()
        {
            var gitRemote = new GitRemote("Name",
                "Host", "URL",
                GitRemoteFunction.Unknown,
                "User",
                "Login", "Token");

            var gitRemote2 = new GitRemote("Name",
               "Host", "URL",
               GitRemoteFunction.Push,
               "User",
               "Login", "Token");
            Assert.AreNotEqual(gitRemote.GetHashCode(), gitRemote2.GetHashCode());
        }
    }
}
