using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Range.Library
{
    /// <summary>
    /// Defines a range of values separated by dashes.
    /// </summary>
    /// <example>1-3 will give an enumerator that returns "1", "2", and "3".</example>
    public class DashRange : BaseRange
    {
        private static readonly Regex regex = new Regex(@"(-?\d+)-?(-?\d+)?", RegexOptions.Compiled);

        private readonly int start;
        private readonly int end;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new <see cref="T:Range.Library.DashRange" /> instance.
        /// </summary>
        /// <param name="range"></param>
        public DashRange(string range) : base(range)
        {
            // If the input is blank, our enumerator shouldn't even loop once.
            // Thus, set the end to before the start.
            if (string.IsNullOrWhiteSpace(range))
            {
                end = -1;
                start = 0;
                return;
            }

            Match match = regex.Match(range);
            GroupCollection groups = match.Groups;
            start = int.Parse(groups[1].Value);

            // If groups[2].Success is true, that means we found two numbers, one on each side of the dash.
            // Ex: "1-3".
            // If not successful, we were given only one number so set the end equal to start.
            // Ex: "1" or "1-".
            end = !groups[2].Success ? start : int.Parse(groups[2].Value);
        }

        /// <inheritdoc />
        public override IEnumerator<string> GetEnumerator() => new DashRangeEnumerator(start, end);

        /// <summary>
        /// Defines an enumerator for dash ranges.
        /// </summary>
        private struct DashRangeEnumerator : IEnumerator<string>
        {
            private readonly int start;
            private int index;
            private readonly int end;

            /// <inheritdoc />
            public string Current { get; private set; }

            /// <inheritdoc />
            object IEnumerator.Current => Current;

            /// <summary>
            /// Initializes a new <see cref="DashRangeEnumerator"/> instance.
            /// </summary>
            /// <param name="start">The range's start value.</param>
            /// <param name="end">The range's end value.</param>
            public DashRangeEnumerator(int start, int end)
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