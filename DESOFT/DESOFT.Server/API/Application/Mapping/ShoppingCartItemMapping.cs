using DESOFT.Server.API.Application.DTO.ShoppingCart;
using DESOFT.Server.API.Domain.Entities.ShoppingCart;

namespace DESOFT.Server.API.Application.Mapping
{
    public class ShoppingCartItemMapper : MappingProfile
    {
        public ShoppingCartItemMapper() : base()
        {
            CreateMap<ShoppingCartItem, ShoppingCartItemDTO>().ReverseMap();
        }
    }
}
