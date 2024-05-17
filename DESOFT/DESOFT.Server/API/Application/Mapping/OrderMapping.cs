using DESOFT.Server.API.Application.DTO.Order;
using DESOFT.Server.API.Domain.Entities.Order;

namespace DESOFT.Server.API.Application.Mapping
{
    public class OrderMapping : MappingProfile
    {
        public OrderMapping() : base()
        {
            CreateMap<Order, OrderDTO>().ReverseMap();
        }
    }
}
