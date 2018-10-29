using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Range.Library
{
    public class CommaRange : BaseRange
    {
        private readonly string[] values;

        public CommaRange(string range) : base(range)
        {
            values = range.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
        }

        public override IEnumerator<string> GetEnumerator() => new CommaRangeEnumerator(values);

        private struct CommaRangeEnumerator : IEnumerator<string>
        {
            private int index;
            private readonly string[] values;

            public string Current { get; private set; }

            object IEnumerator.Current => Current;

            public CommaRangeEnumerator(string[] values)
            {
                index = 0;
                Current = "";
                this.values = values;
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