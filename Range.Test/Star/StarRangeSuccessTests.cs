using System.Collections.Generic;
using System.Linq;
using Range.Library;
using Range.Library.Star;
using Xunit;

namespace Range.Test.Star
{
    /// <summary>
    /// Defines the success scenarios for star ranges.
    /// </summary>
    public class StarRangeSuccessTests
    {
        /// <summary>
        /// Ensures <see cref="StarRange"/>s enumerate the correct values 
        /// for different inputs with a step value of 1 or -1.
        /// </summary>
        /// <param name="start">The start value.</param>
        /// <param name="end">The end value.</param>
        /// <param name="step">The step value; 1 or -1.</param>
        /// <param name="expected">The expected output values.</param>
        [Theory]
        [InlineData(0, 2, 1, new int[] { 0, 1, 2 })]
        [InlineData(0, -2, -1, new int[] { 0, -1, -2 })]
        [InlineData(2, 8, 1, new int[] { 2, 3, 4, 5, 6, 7, 8 })]
        [InlineData(2, -8, -1, new int[] { 2, 1, 0, -1, -2, -3, -4, -5, -6, -7, -8 })]
        [InlineData(-2, -8, -1, new int[] { -2, -3, -4, -5, -6, -7, -8 })]
        [InlineData(-2, 8, 1, new int[] { -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8 })]  
        public void CorrectValuesByOne(int start, int end, int step, int[] expected)
        {
            Test(start, end, step, expected);
        }

        /// <summary>
        /// Ensures <see cref="StarRange"/>s enumerate the correct values for 
        /// different inputs with a step value that's not 1 or -1.
        /// </summary>
        /// <param name="start">The start value.</param>
        /// <param name="end">The end value.</param>
        /// <param name="step">The step value; not 1 or -1.</param>
        /// <param name="expected">The expected output values.</param>
        [Theory]
        [InlineData(0, 10, 2, new int[] { 0, 2, 4, 6, 8, 10 })]
        [InlineData(0, -10, -2, new int[] { 0, -2, -4, -6, -8, -10 })]
        [InlineData(3, 9, 3, new int[] { 3, 6, 9 })]
        [InlineData(-3, -9, -3, new int[] { -3, -6, -9 })]
        [InlineData(3, -9, -3, new int[] { 3, 0, -3, -6, -9 })]
        [InlineData(-3, 9, 3, new int[] { -3, 0, 3, 6, 9 })]
        [InlineData(-1, 10, 3, new int[] { -1, 2, 5, 8 })]
        [InlineData(-1, -10, -3, new int[] { -1, -4, -7, -10 })]
        [InlineData(-1, -9, -3, new int[] { -1, -4, -7 })]
        [InlineData(-1, 11, 3, new int[] { -1, 2, 5, 8, 11})]
        public void CorrectValuesByMany(int start, int end, int step, int[] expected)
        {
            Test(start, end, step, expected);
        }

        /// <summary>
        /// Ensures <see cref="StarRange"/>s enumerate the correct values
        /// when the star and end values are the same and the step value is 1.
        /// </summary>
        /// <param name="start">The start value.</param>
        /// <param name="end">The nd value.</param>
        /// <param name="step">The step value; 1 or -1.</param>
        /// <param name="expected">The expected values.</param>
        [Theory]
        [InlineData(0, 0, 1, new int[] { 0 })]
        [InlineData(5, 5, 1, new int[] { 5 })]
        [InlineData(-3, -3, 1, new int[] { -3 })]
        [InlineData(0, 0, -1, new int[] { 0 })]
        [InlineData(5, 5, -1, new int[] { 5 })]
        [InlineData(-3, -3, -1, new int[] { -3 })]
        public void SameStartAndEndByOne(int start, int end, int step, int[] expected)
        {
            Test(start, end, step, expected);
        }

        [Theory]
        [InlineData(0, 0, 3, new int[] { 0 })]
        [InlineData(5, 5, 12, new int[] { 5 })]
        [InlineData(-3, -3, 5, new int[] { -3 })]
        [InlineData(0, 0, -3, new int[] { 0 })]
        [InlineData(5, 5, -12, new int[] { 5 })]
        [InlineData(-3, -3, -5, new int[] { -3 })]
        public void SameStartAndEndByMany(int start, int end, int step, int[] expected)
        {
            Test(start, end, step, expected);
        }

        private void Test(int start, int end, int step, int[] expected)
        {
            StarRange range = new StarRange(start, end, step);
            var actual = range.AsEnumerable();
            Assert.Equal(expected, actual);
        }
    }
}