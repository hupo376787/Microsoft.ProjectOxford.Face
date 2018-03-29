using System;
using System.Runtime.CompilerServices;

namespace Microsoft.ProjectOxford.Face.Contract
{
    public class Person
    {
        public string Name
        {
            get;
            set;
        }

        public Guid[] PersistedFaceIds
        {
            get;
            set;
        }

        public Guid PersonId
        {
            get;
            set;
        }

        public string UserData
        {
            get;
            set;
        }

        public Person()
        {
        }
    }
}