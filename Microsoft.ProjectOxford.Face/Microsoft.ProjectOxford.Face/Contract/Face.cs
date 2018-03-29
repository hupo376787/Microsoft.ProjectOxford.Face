using System;
using System.Runtime.CompilerServices;

namespace Microsoft.ProjectOxford.Face.Contract
{
    public class Face
    {
        public FaceAttributes FaceAttributes
        {
            get;
            set;
        }

        public Guid FaceId
        {
            get;
            set;
        }

        public FaceLandmarks FaceLandmarks
        {
            get;
            set;
        }

        public FaceRectangle FaceRectangle
        {
            get;
            set;
        }

        public Face()
        {
        }
    }
}