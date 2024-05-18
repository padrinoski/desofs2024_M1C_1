using DESOFT.Server.API.Application.DTO.ShoppingCart;
using DESOFT.Server.API.Domain.Entities.ShoppingCart;

namespace DESOFT.Server.API.Application.Mapping
{
    public class ShoppingCartMapper : MappingProfile
    {
        public ShoppingCartMapper() : base()
        {
            CreateMap<ShoppingCart, ShoppingCartDTO>().ReverseMap();
        }
    }
}
