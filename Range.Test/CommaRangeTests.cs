using System.Collections.Generic;
using System.Linq;
using Range.Library;
using Range.Library.Comma;
using Xunit;

namespace Range.Test
{
    public class CommaRangeTests
    { 
        [Theory]
        [InlineData("1", new int[] { 1 })]
        [InlineData("1,", new int[] { 1 })]
        [InlineData("-1", new int[] { -1 })]
        [InlineData("-1,", new int[] { -1 })]
        [InlineData("1,2,3", new int[] { 1, 2, 3})]
        [InlineData("1,2,3,", new int[] { 1, 2, 3})]
        [InlineData("-1,2,-3,", new int[] { -1, 2, -3})]
        [InlineData("-1,0,1,", new int[] { -1, 0, 1})]
        [InlineData("-1,1,-1,1", new int[] { -1, 1, -1, 1})]
        [InlineData("0,3,100,254", new int[] { 0, 3, 100, 254 })]
        [InlineData(",1,2,3", new int[] { 1, 2, 3 })]
        [InlineData("1,2,,,3", new int[] { 1, 2, 3 })]
        [InlineData(",,,,1,,2,3,,", new int[] { 1, 2, 3 })]
        public void SuccessTests(string rangeStr, int[] expected)
        {
            CommaRange range = new CommaRange(rangeStr);
            var actual = range.AsEnumerable();
            Assert.Equal(expected, actual);
        }
    }
}