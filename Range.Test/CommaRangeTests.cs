using System.Collections.Generic;
using System.Linq;
using Range.Library;
using Xunit;

namespace Range.Test
{
    public class CommaRangeTests
    { 
        [Theory]
        [InlineData("", new string[] { })]
        [InlineData("1", new string[] { "1" })]
        [InlineData("1,", new string[] { "1" })]
        [InlineData("-1", new string[] { "-1" })]
        [InlineData("1,2,3", new string[] { "1", "2", "3"})]
        [InlineData("1,2,3,", new string[] { "1", "2", "3"})]
        [InlineData("-1,2,-3,", new string[] { "-1", "2", "-3"})]
        [InlineData("-1,0,1,", new string[] { "-1", "0", "1"})]
        [InlineData("0,3,100,254", new string[] { "0", "3", "100", "254" })]
        public void Test(string rangeStr, string[] expected)
        {
            CommaRange range = new CommaRange(rangeStr);
            List<string> actual = range.ToList();
            Assert.Equal(expected, actual);
        }
    }
}