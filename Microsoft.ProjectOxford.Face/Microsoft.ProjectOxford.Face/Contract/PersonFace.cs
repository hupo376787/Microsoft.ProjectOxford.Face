using System;
using System.Runtime.CompilerServices;

namespace Microsoft.ProjectOxford.Face.Contract
{
    public class PersonFace
    {
        public Guid PersistedFaceId
        {
            get;
            set;
        }

        public string UserData
        {
            get;
            set;
        }

        public PersonFace()
        {
        }
    }
}