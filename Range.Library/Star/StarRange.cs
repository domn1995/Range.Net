using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Range.Library.Star
{
    /// <summary>
    /// Defines a range of values represented by a star (*).
    /// Star ranges represent a set of all the values for a contextual range.
    /// </summary>
    public class StarRange : BaseRange<int>
    {
        /// <summary>
        /// Gets the start value.
        /// </summary>
        public int Start { get; }

        /// <summary>
        /// Gets the end value.
        /// </summary>
        public int End { get; }

       /// <summary>
       /// Gets the step value.
       /// </summary>
        public int Step { get; }

        /// <summary>
        /// Gets whether the range is ascending in value.
        /// </summary>
        public bool Ascending => Start < End;

        /// <summary>
        /// Gets whether the range is descending in value.
        /// </summary>
        public bool Descending => Start > End;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new <see cref="StarRange" /> instance with the given values.
        /// </summary>
        /// <param name="start">The start value of the range.</param>
        /// <param name="end">The end value of the range.</param>
        /// <param name="range">The range statement.</param>
        public StarRange(int start, int end, int step = 1) : base("*")
        {
            Start = start;
            End = end;
            Step = step;
            Validate();
        }

        /// <summary>
        /// Validates that the different parameters of the <see cref="StarRange"/> are valid.
        /// </summary>
        /// <exception cref="RangeException">
        /// An infinite loop is detected; the step value is 0.
        /// </exception>
        private void Validate()
        {
            if (Ascending && Step < 0 || Descending && Step > 0)
            {
                string message = $"End value '{End}' unreachable from " +
                                 $"start value '{Start}' with " +
                                 $"step value '{Step}'.";
                throw new RangeException(message);
            }
            if (Step is 0)
            {
                throw new RangeException("Step value cannot be 0.");
            }
        }

        /// <inheritdoc />
        public override IEnumerator<int> GetEnumerator() 
        {
            if (Ascending)
            {
                return new AscendingStarRangeEnumerator(Start, End, Step);
            }
            else if (Descending)
            {
                return new DescendingStarRangeEnumerator(Start, End, Step);
            }
            else
            {
                return Enumerable.Range(Start, 1).GetEnumerator();
            }
        }
    }
}
