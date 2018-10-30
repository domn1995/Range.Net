using System.Collections.Generic;
using System.Linq;
using Range.Library;
using Xunit;

namespace Range.Test
{
    public class StarRangeTests
    {
        [Theory]
        [InlineData(0, 0, new string[] { "0" })]
        [InlineData(-1, 1, new string[] { "-1", "0", "1" })]
        [InlineData(-3, -2, new string[] { "-3", "-2" })]
        [InlineData(1, 3, new string[] { "1", "2", "3" })]
        public void Test(int start, int end, string[] expected)
        {
            StarRange range = new StarRange(start, end);
            List<string> actual = range.ToList();
            Assert.Equal(expected, actual);
        }
    }
}