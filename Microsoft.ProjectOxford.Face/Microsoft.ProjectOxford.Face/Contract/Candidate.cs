using System;
using System.Runtime.CompilerServices;

namespace Microsoft.ProjectOxford.Face.Contract
{
    public class Candidate
    {
        public double Confidence
        {
            get;
            set;
        }

        public Guid PersonId
        {
            get;
            set;
        }

        public Candidate()
        {
        }
    }
}