﻿using System;
using System.Text.RegularExpressions;
using TestUtils;
using NUnit.Framework;
using GitHub.Unity;
using System.Linq;

namespace UnitTests
{
    [TestFixture]
    public class LineProcessorTests
    {
        // This test verifies that ReadUntil correctly stops reading a line at the indicated char.
        [Test]
        public void LineShouldReadUntilChar()
        {
            var line = new LineParser("apple orange banana");
            Assert.True(line.ReadUntil('b').Equals("apple orange "));
        }

        // This test verifies that ReadUntilWhitespace stops reading at the first whitespace in the line.
        [Test]
        public void LineShouldReadUntilWhitespace()
        {
            var line = new LineParser("apple orange banana");
            Assert.True(line.ReadUntilWhitespace().Equals("apple"));
        }

        // This test verifies that ReadChunk reads exclusively between the two indicated chars.
        [Test]
        public void LineShouldReadChunk()
        {
            var line = new LineParser("apple orange banana");
            Assert.True(line.ReadChunk('o', 'e').Equals("rang"));
        }

        // This test verifies that ReadToEnd reads until the last char in a line.
        [Test]
        public void LineShouldReadToEnd()
        {
            var line = new LineParser("apple orange banana");
            Assert.True(line.ReadToEnd().Equals("apple orange banana"));
        }

        [Test]
        public void LineShouldReadToEndAutomated()
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
                var line = new LineParser(testString);
                Assert.True(line.ReadToEnd().Equals(testString));
            }
        }

        // This test verifies that ReadUntilLast reads until the last string indicated.
        [Test]
        public void LineShouldReadUntilLastString()
        {
            var line = new LineParser("apple orange banana");
            Assert.True(line.ReadUntilLast("ana").Equals("apple orange ban"));
        }

        // This test verifies that ReadUntilLast reads until the last string indicated.
        [Test]
        public void LineShouldReadUntilLastStringAutomated()
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
                var line = new LineParser(testString);
                Assert.True(line.ReadUntilLast(testString.Substring(testString.Length - 1)).Equals(testString.LeftBeforeLast(testString.Substring(testString.Length - 1))));
            }
        }

        // This test verifies that SkipWhitespace correctly throws an exception when presented with an empty string.
        [Test]
        public void EmptyStringThrowsExceptionWhitespace()
        {
            var line = new LineParser("");
            Assert.Throws<InvalidOperationException>(() => line.SkipWhitespace());
        }

        // This test verifies that MoveToAfter correctly throws an exception when presented with an empty string.
        [Test]
        public void EmptyStringThrowsExceptionMoveToAfter()
        {
            var line = new LineParser("");
            Assert.Throws<InvalidOperationException>(() => line.MoveToAfter(""));
        }
    }
}

