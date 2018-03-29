using System;
using System.Runtime.CompilerServices;

namespace Microsoft.ProjectOxford.Face.Contract
{
    public class IdentifyResult
    {
        public Candidate[] Candidates
        {
            get;
            set;
        }

        public Guid FaceId
        {
            get;
            set;
        }

        public IdentifyResult()
        {
        }
    }
}