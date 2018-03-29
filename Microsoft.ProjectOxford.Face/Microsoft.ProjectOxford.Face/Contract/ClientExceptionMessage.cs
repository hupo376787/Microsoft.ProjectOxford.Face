using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Microsoft.ProjectOxford.Face.Contract
{
    [DataContract]
    public class ClientExceptionMessage
    {
        [DataMember(Name = "code")]
        public string ErrorCode
        {
            get;
            set;
        }

        [DataMember(Name = "message")]
        public string Message
        {
            get;
            set;
        }

        public ClientExceptionMessage()
        {
        }
    }
}