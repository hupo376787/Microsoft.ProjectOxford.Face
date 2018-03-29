using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Microsoft.ProjectOxford.Face.Contract
{
    [DataContract]
    public class ClientError
    {
        [DataMember(Name = "error")]
        public ClientExceptionMessage Error
        {
            get;
            set;
        }

        public ClientError()
        {
        }
    }
}