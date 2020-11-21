using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DelegatesAndHigherOrderFunctions
{
    public sealed class FilteredMovieException : Exception
    {
        public FilteredMovieException()
        {
        }

        public FilteredMovieException(string message) : base(message)
        {
        }

        public FilteredMovieException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FilteredMovieException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
