using System.Collections.Generic;
using System.Linq;
using Range.Library;
using Xunit;

namespace Range.Test
{
    public class DashRangeTests
    {
        [Theory]
        [InlineData("", new string[] { })]
        [InlineData("1", new string[] { "1" })]
        [InlineData("-1", new string[] { "-1" })]
        [InlineData("1-3", new string[] { "1", "2", "3" })]
        [InlineData("-1-3", new string[] { "-1", "0", "1", "2", "3" })]
        [InlineData("2-5", new string[] { "2", "3", "4", "5" })]
        [InlineData("-5--2", new string[] { "-5", "-4", "-3", "-2" })]
        [InlineData("9-9", new string[] { "9" })]
        public void Test(string rangeStr, string[] expected)
        {
            DashRange range = new DashRange(rangeStr);
            List<string> actual = range.ToList();
            Assert.Equal(expected, actual);
        }
    }
}