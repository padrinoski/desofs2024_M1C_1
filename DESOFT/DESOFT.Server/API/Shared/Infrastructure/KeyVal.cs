using System.Runtime.Serialization;

namespace DESOFT.Server.API.Shared.Infrastructure
{
    [DataContract]
    public class KeyVal
    {
        public KeyVal()
        {
            
        }

        public KeyVal(string key)
        {
            Key = key;
        }

        [DataMember]
        public string Key { get; set; }

    }
}
