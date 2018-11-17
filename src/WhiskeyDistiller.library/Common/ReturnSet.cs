using System;

namespace WhiskeyDistiller.library.Common
{
    public class ReturnSet<T>
    {
        public T Value;

        public T Object => Value;

        private readonly Exception _error;

        public bool HasError => _error != null;

        public Exception Error => _error;

        private readonly string _additionalErrorInformation;

        public string AdditionalErrorInformation => _additionalErrorInformation;

        public ReturnSet(T objvalue)
        {
            Value = objvalue;
        }

        public ReturnSet(Exception exception, string additionalErrorInformation = null)
        {
            _error = exception;
            _additionalErrorInformation = additionalErrorInformation;
        }
    }
}