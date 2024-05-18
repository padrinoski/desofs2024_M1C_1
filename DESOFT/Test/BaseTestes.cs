using AutoMapper;

namespace Test
{
    public class BaseTestes
    {

        internal readonly IMapper _mapper;

        internal BaseTestes()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(new[] {"DESOFT.Server"}));
            configuration.CompileMappings();
            _mapper = configuration.CreateMapper();
        }

    }
}
