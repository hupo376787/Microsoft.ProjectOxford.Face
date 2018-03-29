using System;
using System.Runtime.CompilerServices;

namespace Microsoft.ProjectOxford.Face.Contract
{
    public class FaceRectangle
    {
        public int Height
        {
            get;
            set;
        }

        public int Left
        {
            get;
            set;
        }

        public int Top
        {
            get;
            set;
        }

        public int Width
        {
            get;
            set;
        }

        public FaceRectangle()
        {
        }
    }
}