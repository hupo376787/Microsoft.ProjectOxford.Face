using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Microsoft.ProjectOxford.Face.Contract
{
    public class GroupResult
    {
        public List<Guid[]> Groups
        {
            get;
            set;
        }

        public Guid[] MessyGroup
        {
            get;
            set;
        }

        public GroupResult()
        {
        }
    }
}