using System;
using System.Runtime.CompilerServices;

namespace Microsoft.ProjectOxford.Face.Contract
{
    public class HeadPose
    {
        public double Pitch
        {
            get;
            set;
        }

        public double Roll
        {
            get;
            set;
        }

        public double Yaw
        {
            get;
            set;
        }

        public HeadPose()
        {
        }
    }
}