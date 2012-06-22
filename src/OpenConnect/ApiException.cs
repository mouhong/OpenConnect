using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect
{
    [Serializable]
    public class ApiException : Exception
    {
        public string ErrorCode { get; set; }

        public ApiException() { }

        public ApiException(string message)
            : base(message)
        {
        }

        public ApiException(string message, string errorCode)
            : base(message.EndsWith(".") ? message : message + "." + " Error code: " + errorCode + ".")
        {
            ErrorCode = errorCode;
        }

        public ApiException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ApiException(string message, string errorCode, Exception inner)
            : base(message.EndsWith(".") ? message : message + "." + " Error code: " + errorCode + ".", inner)
        {
        }

        protected ApiException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }

        public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            base.GetObjectData(info, context);

            if (ErrorCode != null)
                info.AddValue("ErrorCode", ErrorCode);
        }
    }
}
