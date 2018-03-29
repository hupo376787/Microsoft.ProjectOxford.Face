using System;
using System.Runtime.CompilerServices;

namespace Microsoft.ProjectOxford.Face.Contract
{
    public class CreatePersonResult
    {
        public Guid PersonId
        {
            get;
            set;
        }

        public CreatePersonResult()
        {
        }
    }
}