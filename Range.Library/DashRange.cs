using System.Collections;
using System.Collections.Generic;

namespace Range.Library
{
    public class DashRange : BaseRange
    {
        public DashRange(string range) : base(range) { }

        public override IEnumerator<string> GetEnumerator() => new DashRangeEnumerator(Range);

        private struct DashRangeEnumerator : IEnumerator<string>
        {
            private readonly int start;
            private int index;
            private readonly int end;

            public string Current { get; private set; }

            object IEnumerator.Current => Current;

            public DashRangeEnumerator(string range)
            {
                Current = "";

                // Handle empty range.
                if (string.IsNullOrWhiteSpace(range))
                {
                    end = -1;
                    start = 0;
                    index = start;
                    return;
                }

                // Handle a range that doesn't contain a dash.
                if (!range.Contains("-"))
                {
                    start = int.Parse(range);
                    end = index = start;
                    return;
                }

                // Handle a normal range.
                string[] values = range.Split('-');
                start = int.Parse(values[0]);
                index = start;
                end = values.Length > 1 ? int.Parse(values[1]) : start;
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