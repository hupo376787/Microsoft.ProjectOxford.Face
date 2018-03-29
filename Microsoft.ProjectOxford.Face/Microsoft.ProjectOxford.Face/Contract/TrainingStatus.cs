using System;
using System.Runtime.CompilerServices;

namespace Microsoft.ProjectOxford.Face.Contract
{
    public class TrainingStatus
    {
        public DateTime CreatedDateTime
        {
            get;
            set;
        }

        public DateTime LastActionDateTime
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public Status Status
        {
            get;
            set;
        }

        public TrainingStatus()
        {
        }
    }
}