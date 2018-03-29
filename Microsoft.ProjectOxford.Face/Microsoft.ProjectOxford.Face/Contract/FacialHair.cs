using System;
using System.Runtime.CompilerServices;

namespace Microsoft.ProjectOxford.Face.Contract
{
    public class FacialHair
    {
        public double Beard
        {
            get;
            set;
        }

        public double Moustache
        {
            get;
            set;
        }

        public double Sideburns
        {
            get;
            set;
        }

        public FacialHair()
        {
        }
    }
}