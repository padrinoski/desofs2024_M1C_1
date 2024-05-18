using System.Runtime.Serialization;

namespace DESOFT.Server.API.Shared.Infrastructure
{
    [DataContract]
    public class Result
    {
        [DataMember]
        public bool Success
        {
            get => !Errors.Any();
            internal set { }
        }

        [DataMember]
        public List<KeyVal> Errors { get; set; } = new List<KeyVal>();
        
        [DataMember]
        public List<KeyVal> Messages { get; set; } = new List<KeyVal>();
        
        [DataMember]
        public List<int> StatusCode { get; set; }

        [DataContract]
        public class ServiceResult : Result { }

        [DataContract]
        public class ServiceResult<T> : Result {
            [DataMember]
            public T Data { get; set; }
        }
    }
}
