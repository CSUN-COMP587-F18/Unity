using System;
using GitHub.Logging;
using NUnit.Framework;
using System.Text.RegularExpressions;
using TestUtils;
using GitHub.Unity;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestFixture]
    public class StringExtensionTests
    {
        // This test checks if a certain substring is in a provided string.
        [Test]
        public void StringContainsSubstring()
        {
            Assert.True(StringExtensions.Contains("this string contains borb", "borb", StringComparison.Ordinal));
        }

        // This automated test checks if a certain substring is in a randomly generated string.
        [Test]
        public void StringContainsSubstringAutomated()
        {
            var charlist = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            for (int stringLength = 1; stringLength < 100; stringLength++)
            {
                var randomString = new char[stringLength];
                for (int y = 0; y < randomString.Length; y++)
                {
                    randomString[y] = charlist[random.Next(charlist.Length)];
                }
                var testString = new String(randomString);
                Assert.True(StringExtensions.Contains(testString, testString.First().ToString(), StringComparison.Ordinal));
            }
        }

        // This test checks if certain chars exist in a provided string.
        [Test]
        public void StringContainsChars()
        {
            IEnumerable<char> charList = from ch in "abcd" select ch;
            Assert.True(StringExtensions.ContainsAny("this string contains abcd", charList));
        }

        // This test checks if a provided string begins with a certain char.
        [Test]
        public void StringStartsWithChar()
        {
            Assert.True(StringExtensions.StartsWith("abcd", 'a'));
        }

        // This test checks if a randomly generated string begins with a certain char.
        [Test]
        public void StringStartsWithCharAutomated()
        {
            var charlist = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            for (int stringLength = 1; stringLength < 100; stringLength++)
            {
                var randomString = new char[stringLength];
                for (int y = 0; y < randomString.Length; y++)
                {
                    randomString[y] = charlist[random.Next(charlist.Length)];
                }
                var testString = new String(randomString);
                Assert.True(StringExtensions.StartsWith(testString, testString.First()));
            }
        }

        // This test checks that the RightAfter returns everything in a String after a provided substring in it.
        [Test]
        public void ReturnsContentAfterSubstring()
        {
            Assert.True(StringExtensions.RightAfter("this string contains words", "string").Equals(" contains words"));
        }

        // This test checks that the RightAfterLast returns everything in a String after the last occurence of a certain substring in it.
        [Test]
        public void ReturnsContentAfterLastSubstring()
        {
            Assert.True(StringExtensions.RightAfterLast("big word small word large word apple", "word").Equals(" apple"));
        }

        // This test checks that the LeftBeforeLast returns everything in a String before the last occurence of a certain substring in it.
        [Test]
        public void ReturnsContentBeforeLastSubstring()
        {
            Assert.True(StringExtensions.LeftBeforeLast("big word small word large word apple", "word").Equals("big word small word large "));
        }
    }
}
