using Range.Library;
using Range.Library.Star;
using Xunit;

namespace Range.Test.Star
{
    /// <summary>
    /// Contains the failure tests for star ranges.
    /// </summary>
    public class StarRangeFailureTests
    {
        
        /// <summary>
        /// The different range scenarios that lead to an infinite loop
        /// and are caught by a <see cref="RangeException"/>.
        /// </summary>
        /// <param name="start">The start value.</param>
        /// <param name="end">The end value.</param>
        /// <param name="step">The step value.</param>
        [Theory]
        [InlineData(1, 3, -1)]
        [InlineData(-1, 3, -1)]
        [InlineData(1, -3, 1)]
        [InlineData(-1, -3, 1)]
        [InlineData(0, 0, 0)]
        [InlineData(1, 3, 0)]
        [InlineData(-1, 3, 0)]
        [InlineData(-1, -3, 0)]
        public void InfiniteLoop(int start, int end, int step)
        {
            Assert.Throws<RangeException>(() =>
            {
                StarRange range = new StarRange(start, end, step);
            });
        }
    }
}
