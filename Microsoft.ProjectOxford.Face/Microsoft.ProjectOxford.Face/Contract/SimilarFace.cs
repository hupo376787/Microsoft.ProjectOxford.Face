using System;
using System.Runtime.CompilerServices;

namespace Microsoft.ProjectOxford.Face.Contract
{
    public class SimilarFace
    {
        public double Confidence
        {
            get;
            set;
        }

        public Guid FaceId
        {
            get;
            set;
        }

        public SimilarFace()
        {
        }
    }
}