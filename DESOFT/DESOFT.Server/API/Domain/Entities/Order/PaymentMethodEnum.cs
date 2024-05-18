using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DESOFT.Server.API.Domain.Entities.Order
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PaymentMethod
    {
        DebitCard,
        CreditCard,
        MBWay
    }
}
