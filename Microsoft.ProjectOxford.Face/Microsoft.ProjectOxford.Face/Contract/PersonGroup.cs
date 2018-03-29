using System;
using System.Runtime.CompilerServices;

namespace Microsoft.ProjectOxford.Face.Contract
{
    public class PersonGroup
    {
        public string Name
        {
            get;
            set;
        }

        public string PersonGroupId
        {
            get;
            set;
        }

        public string UserData
        {
            get;
            set;
        }

        public PersonGroup()
        {
        }
    }
}