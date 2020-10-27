using CodingProblems;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CodingProblemsTests
{
    public class StringCalculator_Add
    {
        private const string _expectedMessageOnNegativesException = "Negatives not allowed: ";

        [Theory]
        [InlineData("", 0)]
        [InlineData("3", 3)]
        [InlineData("5,6", 11)]
        [InlineData("5,6,0,5", 16)]
        [InlineData("5\n6\n0,5", 16)]
        [InlineData("//;\n5;6;0;5", 16)]

        [InlineData("3,1001", 3)]
        [InlineData("5,6,0,1001", 11)]

        [InlineData("//;\n5;6;0;5;10100", 16)]

        [InlineData("//[|||]\n1|||2|||3", 6)]
        [InlineData("//[|][%]\n1|2%3", 6)]
        [InlineData("//[|i][%i]\n1|i2%i3", 6)]
        public void Adds(string numSeq, int expected)
        {
            StringCalculator.Add(numSeq).Should().Be(expected);
        }

        [Fact]
        public void ThrowsOnNegatives()
        {
            var ex = Assert.Throws<ArgumentException>(() => StringCalculator.Add("-3"));

            ex.Message.Should().StartWith(_expectedMessageOnNegativesException);
        }

        [Theory]
        [InlineData("-3", new[] { -3 })]
        [InlineData("5,-6", new[] { -6 })]
        [InlineData("5,-6,0,-5", new[] { -6, -5 })]
        [InlineData("//;\n-5;-6;0;5", new[] { -5, -6 })]
        public void ReportsNegatives(string numSeq, int[] expected)
        {
            var ex = Assert.Throws<ArgumentException>(() => StringCalculator.Add(numSeq));

            IEnumerable<int> reportedNumbers = ex.Message.Substring(_expectedMessageOnNegativesException.Length)
                .Split(',').Select(Int32.Parse);
            expected.Should().BeEquivalentTo(reportedNumbers);
        }
    }
}
