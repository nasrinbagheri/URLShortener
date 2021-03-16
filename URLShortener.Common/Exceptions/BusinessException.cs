using System;

namespace URLShortener.Common.Exceptions
{
    public class BusinessException<TErrorType> : Exception, IBusinessException<TErrorType> where TErrorType : Enum
    {
        private string _message;
        private readonly object _internalData;

        public BusinessException(TErrorType code, Exception innerException = null)
        {
            _internalData = innerException;
            Code = code;
        }

        public TErrorType Code { get; }

        public int GetCode()
        {

            int codeInt = Convert.ToInt32(Code);
            return codeInt;
        }

        public string ReturnMessage()
        {
            _message = Convert.ToString(Code);
            return _message;
        }

        public object GetData()
        {
            return _internalData;
        }

    }
}
