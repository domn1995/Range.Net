using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Range.Library.Comma
{

    /// <summary>
    /// Defines an enumerator for comma ranges.
    /// </summary>
    internal struct CommaRangeEnumerator : IEnumerator<int>
    {
        private int index;
        private readonly int[] values;

        /// <inheritdoc />
        public int Current { get; private set; }

        /// <inheritdoc />
        object IEnumerator.Current => Current;

        /// <summary>
        /// Initializes a new <see cref="CommaRangeEnumerator"/> instance.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        public CommaRangeEnumerator(int[] values)
        {
            this.values = values;
            index = 0;
            Current = values[index];
        }

        /// <inheritdoc />
        public bool MoveNext()
        {
            if (index >= values.Length)
            {
                return false;
            }

            Current = values[index];
            ++index;
            return true;
        }

        /// <inheritdoc />
        public void Reset()
        {
            index = 0;
            Current = values[index];
        }

        /// <inheritdoc />
        public void Dispose() { }
    }
}
