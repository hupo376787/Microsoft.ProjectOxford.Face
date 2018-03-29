using System;
using System.Runtime.CompilerServices;

namespace Microsoft.ProjectOxford.Face.Contract
{
    public class AddPersistedFaceResult
    {
        public Guid PersistedFaceId
        {
            get;
            set;
        }

        public AddPersistedFaceResult()
        {
        }
    }
}