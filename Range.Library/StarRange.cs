using System.Collections;
using System.Collections.Generic;

namespace Range.Library
{
    /// <summary>
    /// Defines a range of values represented by a star (*).
    /// </summary>
    public class StarRange : BaseRange
    {
        /// <summary>
        /// Gets the start value.
        /// </summary>
        public int Start { get; }

        /// <summary>
        /// Gets the end value.
        /// </summary>
        public int End { get; }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new <see cref="T:Range.Library.StarRange" /> instance with the given values.
        /// </summary>
        /// <param name="start">The start value of the range.</param>
        /// <param name="end">The end value of the range.</param>
        /// <param name="range">The range statement.</param>
        public StarRange(int start, int end, string range = "*") : base(range)
        {
            Start = start;
            End = end;
        }

        /// <inheritdoc />
        public override IEnumerator<string> GetEnumerator() => new StarRangeEnumerator(Start, End);

        /// <summary>
        /// Defines an enumerator for star ranges.
        /// </summary>
        private struct StarRangeEnumerator : IEnumerator<string>
        {
            private readonly int start;
            private readonly int end;
            private int index;

            /// <inheritdoc />
            public string Current { get; private set; }

            /// <inheritdoc />
            object IEnumerator.Current => Current;

            /// <summary>
            /// Initializes a new <see cref="StarRangeEnumerator"/> instance with the given values.
            /// </summary>
            /// <param name="start">The start value of the range.</param>
            /// <param name="end">The end value of the range.</param>
            public StarRangeEnumerator(int start, int end)
            {
                Current = "";
                this.start = index = start;
                this.end = end;
            }

            /// <inheritdoc />
            public bool MoveNext()
            {
                if (index > end)
                {
                    return false;
                }

                Current = index.ToString();
                index++;
                return true;
            }

            /// <inheritdoc />
            public void Reset()
            {
                index = start;
                Current = "";
            }

            /// <inheritdoc />
            public void Dispose() { }
        }
    }
}
