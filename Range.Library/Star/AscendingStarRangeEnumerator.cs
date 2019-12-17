using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Range.Library.Star
{
    /// <summary>
    /// Defines an enumerator for integer star ranges with ascending values.
    /// </summary>
    internal struct AscendingStarRangeEnumerator : IEnumerator<int>
    {
        private readonly int start;
        private readonly int end;
        private readonly int step;
        private int current;

        /// <inheritdoc />
        public int Current { get; private set; }

        /// <inheritdoc />
        object IEnumerator.Current => Current;

        /// <summary>
        /// Initializes a new <see cref="AscendingStarRangeEnumerator"/> instance with the given values.
        /// </summary>
        /// <param name="start">The start value of the range.</param>
        /// <param name="end">The end value of the range.</param>
        public AscendingStarRangeEnumerator(int start, int end, int step)
        {
            this.start = current = start;
            this.end = end;
            this.step = step;
            Current = start;
        }

        /// <inheritdoc />
        public bool MoveNext()
        {
            if (current > end)
            {
                return false;
            }

            Current = current;
            current += step;
            return true;
        }

        /// <inheritdoc />
        public void Reset()
        {
            Current = current = start;
        }

        /// <inheritdoc />
        public void Dispose() { }
    }
}
