using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Range.Library
{
    public class DashRange : BaseRange
    {
        private static readonly Regex regex = new Regex(@"(-?\d+)-?(-?\d+)?", RegexOptions.Compiled);

        private readonly int start;
        private readonly int end;

        public DashRange(string range) : base(range)
        {
            if (string.IsNullOrWhiteSpace(range))
            {
                end = -1;
                start = 0;
                return;
            }

            Match match = regex.Match(range);
            GroupCollection groups = match.Groups;
            start = int.Parse(groups[1].Value);
            end = !groups[2].Success ? start : int.Parse(groups[2].Value);
        }

        public override IEnumerator<string> GetEnumerator() => new DashRangeEnumerator(start, end);

        private struct DashRangeEnumerator : IEnumerator<string>
        {
            private readonly int start;
            private int index;
            private readonly int end;

            public string Current { get; private set; }

            object IEnumerator.Current => Current;

            public DashRangeEnumerator(int start, int end)
            {
                Current = "";
                this.start = index = start;
                this.end = end;
            }

            public bool MoveNext()
            {
                if (index <= end)
                {
                    Current = index.ToString();
                    index++;
                    return true;
                }

                return false;
            }

            public void Reset()
            {
                index = start;
                Current = "";
            }

            public void Dispose() { }
        }
    }
}