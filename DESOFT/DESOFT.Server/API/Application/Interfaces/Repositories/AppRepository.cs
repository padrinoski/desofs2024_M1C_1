using DESOFT.Server.API.Infrastructure;
using DESOFT.Server.API.Shared.Infrastructure;

namespace DESOFT.Server.API.Application.Interfaces.Repositories
{
    public class AppRepository 
    {

        private readonly AppDBContext _context;
        private readonly ILogger _logger;

        public AppRepository(AppDBContext appDBContext, ILogger logger)
        {
            _context = appDBContext;
            _logger = logger;
        }


        public async Task<bool> SaveTransaction(Result result, string error)
        {
            try
            {
                if (await _context.SaveChangesAsync() == 0)
                {
                    _logger.LogInformation("No changes");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetBaseException().Message);
                result.Errors.Add(new KeyVal { Key = error });
                return false;
            }

            return true;
        }

    }
}
