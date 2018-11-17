using System;

namespace WhiskeyDistiller.library.Common
{
    public class ReturnSet<T>
    {
        public T Value;

        public T Object => Value;

        public bool HasError => Error != null;

        public Exception Error { get; }

        public string AdditionalErrorInformation { get; }

        public ReturnSet(T objvalue)
        {
            Value = objvalue;
        }

        public ReturnSet(Exception exception, string additionalErrorInformation = null)
        {
            Error = exception;
            AdditionalErrorInformation = additionalErrorInformation;

            NLog.LogManager.GetCurrentClassLogger().Error(exception, message: additionalErrorInformation);
        }
    }
}