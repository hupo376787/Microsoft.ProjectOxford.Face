using System;
using System.Runtime.CompilerServices;

namespace Microsoft.ProjectOxford.Face.Contract
{
    public class SimilarPersistedFace
    {
        public double Confidence
        {
            get;
            set;
        }

        public Guid PersistedFaceId
        {
            get;
            set;
        }

        public SimilarPersistedFace()
        {
        }
    }
}