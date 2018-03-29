using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Runtime.CompilerServices;

namespace Microsoft.ProjectOxford.Face.Contract
{
    public class FaceAttributes
    {
        public double Age
        {
            get;
            set;
        }

        public FacialHair FacialHair
        {
            get;
            set;
        }

        public string Gender
        {
            get;
            set;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public Glasses Glasses
        {
            get;
            set;
        }

        public HeadPose HeadPose
        {
            get;
            set;
        }

        public double Smile
        {
            get;
            set;
        }

        public FaceAttributes()
        {
        }
    }
}