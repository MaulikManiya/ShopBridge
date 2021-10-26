using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.API.Infrastructure.Errors
{
    public class GeneralErrorResultModel
    {
        public string Message { get; }
        public ErrorCodes ErrorCode { get; }
        public GeneralErrorResultModel(ErrorCodes errorCode, string message)
        {
            Message = message;
            ErrorCode = errorCode;
        }
    }
}
