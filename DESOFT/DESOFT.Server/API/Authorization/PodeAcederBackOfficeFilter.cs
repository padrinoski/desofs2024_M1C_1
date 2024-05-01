using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DESOFT.Server.API.Authorization
{
    public class PodeAcederBackOfficeFilter : ActionFilterAttribute
    {

        public PodeAcederBackOfficeFilter()
        {
            //services
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //condição
            context.Result = new UnauthorizedObjectResult("Acesso Proibido");
        }

    }
}
