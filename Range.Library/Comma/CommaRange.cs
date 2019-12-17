using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Range.Library.Comma
{
    /// <inheritdoc />
    /// <summary>
    /// Defines a range of values separated by commas.
    /// </summary>
    /// <example>"1,3,6" will give an enumerator that returns "1", "3", and "6".</example>
    public class CommaRange : BaseRange<int>
    {
        private readonly int[] values;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new <see cref="CommaRange"/> instance.
        /// </summary>
        /// <param name="range">The range string.</param>
        public CommaRange(string range) : base(range)
        {
            values = range.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();
        }

        /// <inheritdoc />
        public override IEnumerator<int> GetEnumerator() => new CommaRangeEnumerator(values);
    }
}