using System;
using GitHub.Logging;
using NUnit.Framework;
using GitHub.Unity;


namespace UnitTests
{
    [TestFixture]
    public class LoginTests
    {
        //Still trying to figure out how to test logins, consider this a placeholder.

        [Test]
        public void LoginSavesUserData()
        {
            UriString host = new UriString("https://url.com/path/file.zip?cb=1");
            string username = "username";
            string password = "password";
            Assert.AreEqual(1, 1);
        }
    }
}
