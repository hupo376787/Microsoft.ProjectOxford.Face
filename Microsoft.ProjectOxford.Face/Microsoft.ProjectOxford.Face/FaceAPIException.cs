using System;
using System.Net;
using System.Runtime.CompilerServices;

namespace Microsoft.ProjectOxford.Face
{
    public class FaceAPIException : Exception
    {
        public string ErrorCode
        {
            get;
            set;
        }

        public string ErrorMessage
        {
            get;
            set;
        }

        public HttpStatusCode HttpStatus
        {
            get;
            set;
        }

        public FaceAPIException()
        {
        }

        public FaceAPIException(string errorCode, string errorMessage, HttpStatusCode statusCode)
        {
            this.ErrorCode = errorCode;
            this.ErrorMessage = errorMessage;
            this.HttpStatus = statusCode;
        }
    }
}