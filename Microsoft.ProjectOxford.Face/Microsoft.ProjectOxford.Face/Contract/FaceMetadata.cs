using System;
using System.Runtime.CompilerServices;

namespace Microsoft.ProjectOxford.Face.Contract
{
    public class FaceMetadata
    {
        public Guid FaceId
        {
            get;
            set;
        }

        public string UserData
        {
            get;
            set;
        }

        public FaceMetadata()
        {
        }
    }
}