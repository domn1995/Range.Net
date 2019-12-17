using System;

namespace Range.Library
{
    /// <summary>
    /// Represents a runtime error related to range calculation.
    /// </summary>
    public class RangeException : Exception
    {
        /// <summary>
        /// Initalizes a new <see cref="RangeException"/> with the given message.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public RangeException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new <see cref="RangeException"/> with the given message and inner exception.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="inner">The inner exception.</param>
        public RangeException(string message, Exception inner) : base(message, inner) { }
    }
}