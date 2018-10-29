using System;
using System.Collections;
using System.Collections.Generic;

namespace Range.Library
{
    public class CommaRange : BaseRange
    {
        public CommaRange(string range) : base(range) { }

        public override IEnumerator<string> GetEnumerator() => new CommaRangeEnumerator(Range);

        private struct CommaRangeEnumerator : IEnumerator<string>
        {
            private int index;
            private readonly string[] values;

            public string Current { get; private set; }

            object IEnumerator.Current => Current;

            public CommaRangeEnumerator(string range)
            {
                index = 0;
                Current = "";
                values = range.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
            }
            
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

            public void Reset()
            {
                index = 0;
                Current = "";
            }

            public void Dispose() { }
        }
    }
}