using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DESOFT.Server.API.Authorization
{
    public class PodeAcederFrontOfficeFilter : ActionFilterAttribute
    {

        public PodeAcederFrontOfficeFilter()
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
