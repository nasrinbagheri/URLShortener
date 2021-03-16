using System;

namespace URLShortener.Common.Exceptions
{
    public interface IBusinessException
    {
        int GetCode();
        string ReturnMessage();
        object GetData();
    }

    public interface IBusinessException<TErrorType> : IBusinessException where TErrorType : Enum
    {
        TErrorType Code { get; }
    }
}
