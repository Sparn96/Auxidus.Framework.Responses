using Auxidus.Framework.Responses.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auxidus.Framework.Responses.Json
{
    public class Response<T>
    {
        public ResponseStatus Status { get; set; }
        public List<string> Messages { get; set; }
        public T Data { get; set; }

        public static Response<T> EmptySuccess()
        {
            return new Response<T>()
            {
                Status = ResponseStatus.SUCCESS,
                Data = default(T),
                Messages = new List<string>()
            };
        }
    }

    public class ExceptionResponseDebug
    {
        public ResponseStatus Status { get; set; }
        public List<string> Messages { get; set; }
        public Exception Exception { get; set; }
        public List<Exception> InnerExceptions { get; set; }
    }

    public class ExceptionResponse
    {
        private ExceptionResponse() {}
        public ExceptionResponse(Exception ex, ResponseStatus responseStatus)
        {
            Status = responseStatus;
            Messages = new List<string>();
            Messages.Add(ex.Message);
            AddInnerExceptionMessage(ex);
        }
        public ResponseStatus Status { get; protected set; }
        public List<string> Messages { get; protected set; }

        private void AddInnerExceptionMessage(Exception ex)
        {
            if(ex.InnerException != null)
            {
                Messages.Add(ex.InnerException.Message);
                AddInnerExceptionMessage(ex.InnerException);
            }
            return;
        }
    }


}
