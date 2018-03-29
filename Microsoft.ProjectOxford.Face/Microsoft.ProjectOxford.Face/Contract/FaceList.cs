using System;
using System.Runtime.CompilerServices;

namespace Microsoft.ProjectOxford.Face.Contract
{
    public class FaceList : FaceListMetadata
    {
        public PersonFace[] PersistedFaces
        {
            get;
            set;
        }

        public FaceList()
        {
        }
    }
}