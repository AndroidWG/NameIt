using System;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;

namespace NameIt
{
    [Serializable]
    public class Mod
    {
        public string Filename;
        public string Type;
        public int AutomationVersion;
        public int ExporterVersion;
        
        public Vehicle VehicleInfo;
        public VehicleTechnicalDetails TechnicalDetails;

        void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Type", Type, typeof(string));
            info.AddValue("AutomationVersion", AutomationVersion, typeof(int));
            info.AddValue("ExporterVersion", ExporterVersion, typeof(int));
        }
    }
}