using System;

namespace WhiskeyDistiller.library.Common
{
    public class ReturnSet<T>
    {
        public T Object;

        public bool HasError => Error != null;

        public Exception Error { get; }

        public string AdditionalErrorInformation { get; }

        public ReturnSet(T objectValue)
        {
            Object = objectValue;
        }

        public ReturnSet(Exception exception, string additionalErrorInformation = null)
        {
            Error = exception;
            AdditionalErrorInformation = additionalErrorInformation;

            NLog.LogManager.GetCurrentClassLogger().Error(exception, message: additionalErrorInformation);
        }
    }
}