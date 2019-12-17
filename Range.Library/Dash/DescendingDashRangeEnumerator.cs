using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Range.Library.Dash
{
    /// <summary>
    /// Defines an enumerator for dash ranges.
    /// </summary>
    internal struct DescendingDashRangeEnumerator : IEnumerator<int>
    {
        private readonly int start;
        private int current;
        private readonly int end;

        /// <inheritdoc />
        public int Current { get; private set; }

        /// <inheritdoc />
        object IEnumerator.Current => Current;

        /// <summary>
        /// Initializes a new <see cref="AscendingDashRangeEnumerator"/> instance.
        /// </summary>
        /// <param name="start">The range's start value.</param>
        /// <param name="end">The range's end value.</param>
        public DescendingDashRangeEnumerator(int start, int end)
        {
            Current = current = start;
            this.start = start;
            this.end = end;
        }

        /// <inheritdoc />
        public bool MoveNext()
        {
            if (current < end)
            {
                return false;
            }

            Current = current;
            --current;
            return true;
        }

        /// <inheritdoc />
        public void Reset() => Current = current = start;

        /// <inheritdoc />
        public void Dispose() { }
    }
}
