using System;
using System.Collections;
using System.Collections.Generic;

namespace Range.Library
{
    /// <inheritdoc />
    /// <summary>
    /// Defines a range of values separated by commas.
    /// </summary>
    /// <example>"1,3,6" will give an enumerator that returns "1", "3", and "6".</example>
    public class CommaRange : BaseRange
    {
        private readonly string[] values;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new <see cref="CommaRange"/> instance.
        /// </summary>
        /// <param name="range">The range string.</param>
        public CommaRange(string range) : base(range)
        {
            values = range.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <inheritdoc />
        public override IEnumerator<string> GetEnumerator() => new CommaRangeEnumerator(values);

        /// <summary>
        /// Defines an enumerator for comma ranges.
        /// </summary>
        private struct CommaRangeEnumerator : IEnumerator<string>
        {
            private int index;
            private readonly string[] values;

            /// <inheritdoc />
            public string Current { get; private set; }

            /// <inheritdoc />
            object IEnumerator.Current => Current;

            /// <summary>
            /// Initializes a new <see cref="CommaRangeEnumerator"/> instance.
            /// </summary>
            /// <param name="values">The values to enumerate.</param>
            public CommaRangeEnumerator(string[] values)
            {
                index = 0;
                Current = "";
                this.values = values;
            }

            /// <inheritdoc />
            public bool MoveNext()
            {
                if (index < values.Length)
                {
                    Current = values[index];
                    index++;
                    return true;
                }

                return false;
            }

            /// <inheritdoc />
            public void Reset()
            {
                index = 0;
                Current = "";
            }

            /// <inheritdoc />
            public void Dispose() { }
        }
    }
}