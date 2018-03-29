using System;
using System.Runtime.CompilerServices;

namespace Microsoft.ProjectOxford.Face.Contract
{
    public class FaceListMetadata
    {
        public string FaceListId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string UserData
        {
            get;
            set;
        }

        public FaceListMetadata()
        {
        }
    }
}