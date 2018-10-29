using System.Collections;
using System.Collections.Generic;

namespace Range.Library
{
    /// <summary>
    /// An abstract representation of a range that can be enumerated and is defined with a string.
    /// </summary>
    public abstract class BaseRange : IEnumerable<string>
    {
        /// <summary>
        /// Gets the original range string.
        /// </summary>
        protected string Range { get; }

        /// <summary>
        /// Initializes a new <see cref="BaseRange"/> instance.
        /// </summary>
        /// <param name="range"></param>
        protected BaseRange(string range)
        {
            Range = range;
        }

        /// <summary>
        /// Gets this range's enumerator, providing foreach support.
        /// </summary>
        /// <returns>A string enumerator for this range.</returns>
        public abstract IEnumerator<string> GetEnumerator();

        /// <inheritdoc />
        /// <summary>
        /// Gets this range's enumerator, providing foreach support.
        /// </summary>
        /// <returns>A string enumerator for this range.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}