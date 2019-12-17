using System.Collections.Generic;
using System.Linq;
using Range.Library;
using Range.Library.Dash;
using Xunit;

namespace Range.Test
{
    public class DashRangeTests
    {
        [Theory]
        [InlineData("1-3", new int[] { 1, 2, 3 })]
        [InlineData("-1-3", new int[] { -1, 0, 1, 2, 3 })]
        [InlineData("-1--3", new int[] { -1, -2, -3 })]
        [InlineData("1--3", new int[] { 1, 0, -1, -2, -3})]
        [InlineData("0-5", new int[] { 0, 1, 2, 3, 4, 5 })]
        [InlineData("-5--2", new int[] { -5, -4, -3, -2 })]
        [InlineData("9-9", new int[] { 9 })]
        [InlineData("-9--9", new int[] { -9 })]
        public void SuccessTests(string rangeStr, int[] expected)
        {
            DashRange range = new DashRange(rangeStr);
            var actual = range.AsEnumerable();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1---3")]
        public void FailureTests(string rangeStr)
        {
            Assert.Throws<RangeException>(() =>
            {
                var range = new DashRange(rangeStr);
                var actual = range.AsEnumerable();
            });
        }
    }
}