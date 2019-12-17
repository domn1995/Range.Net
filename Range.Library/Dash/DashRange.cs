using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Range.Library.Dash
{
    /// <summary>
    /// Defines a range of values separated by dashes.
    /// </summary>
    /// <example>1-3 will give an enumerator that returns "1", "2", and "3".</example>
    public class DashRange : BaseRange<int>
    {
        private static readonly Regex regex = new Regex(@"(-?\d+)-(-?\d+)", RegexOptions.Compiled);
        private readonly int start;
        private readonly int end;

        public bool Ascending => start < end;

        public bool Descending => start > end;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new <see cref="T:Range.Library.DashRange" /> instance.
        /// </summary>
        /// <param name="range"></param>
        public DashRange(string range) : base(range)
        {
            Match match = regex.Match(range);
            GroupCollection groups = match.Groups;
            start = int.Parse(groups[1].Value);
            end = int.Parse(groups[2].Value);
        }

        /// <inheritdoc />
        public override IEnumerator<int> GetEnumerator() 
        {
            if (Ascending)
            {
                return new AscendingDashRangeEnumerator(start, end);
            }
            else
            {
                return new DescendingDashRangeEnumerator(start, end);
            }
        }
    }
}