using System;
using System.Runtime.CompilerServices;

namespace Microsoft.ProjectOxford.Face.Contract
{
    public class VerifyResult
    {
        public double Confidence
        {
            get;
            set;
        }

        public bool IsIdentical
        {
            get;
            set;
        }

        public VerifyResult()
        {
        }
    }
}