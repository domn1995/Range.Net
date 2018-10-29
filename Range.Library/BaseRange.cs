using System.Collections;
using System.Collections.Generic;

namespace Range.Library
{
    public abstract class BaseRange : IEnumerable<string>
    {
        protected string Range { get; }

        protected BaseRange(string range)
        {
            Range = range;
        }

        public abstract IEnumerator<string> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}