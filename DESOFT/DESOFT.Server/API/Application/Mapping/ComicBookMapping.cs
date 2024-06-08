using DESOFT.Server.API.Application.DTO.ComicBook;
using DESOFT.Server.API.Domain.Entities.ComicBooks;

namespace DESOFT.Server.API.Application.Mapping
{
    public class ComicBookMapping : MappingProfile
    {
        public ComicBookMapping() : base()
        {
            CreateMap<ComicBook, ComicBookDTO>()
                .ForMember(a => a.PublishingDate, b => b.MapFrom(c => c.PublishingDate.ToString("yyyy-MM-dd")));
            CreateMap<ComicBookDTO, ComicBook>();
        }
    }
}
