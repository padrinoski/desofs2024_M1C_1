﻿using DESOFT.Server.API.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace DESOFT.Server.API.Authorization
{
    public class PodeAcederFrontOfficeFilter : ActionFilterAttribute
    {

        private readonly IAuthService _authService;
        private readonly ILogger<PodeAcederFrontOfficeFilter> _logger;

        public PodeAcederFrontOfficeFilter(IAuthService authService, ILogger<PodeAcederFrontOfficeFilter> logger)
        {
            _logger = logger;
            _authService = authService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                var authorizationHeader = context.HttpContext.Request.Headers["Authorization"];

                string accessToken = string.Empty;

                if (!authorizationHeader.IsNullOrEmpty() || authorizationHeader.ToString().StartsWith("Bearer"))
                {
                    accessToken = authorizationHeader.ToString().Substring("Bearer ".Length).Trim();

                    var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadToken(accessToken);
                    var tokenS = jsonToken as JwtSecurityToken;

                    var currentUserId = "1";
                    if (tokenS.Payload.ContainsKey("userId"))
                    {
                        tokenS.Payload.TryGetValue("userId", out var userId);
                        currentUserId = userId.ToString();
                    }
                    else if (tokenS.Payload.ContainsKey("sub"))
                    {
                        tokenS.Payload.TryGetValue("sub", out var userId);
                        currentUserId = userId.ToString();
                    }

                    if (currentUserId == null)
                    {
                        context.Result = new UnauthorizedObjectResult("Acesso Proibido");
                    }
                    else
                    {

                        var result = _authService.PodeAcederFrontOffice(currentUserId).Result;

                        if (!result.Success || !result.Data)
                        {
                            context.Result = new UnauthorizedObjectResult("Acesso Proibido");
                        }
                    }

                }
                else
                {
                    context.Result = new UnauthorizedObjectResult("Acesso Proibido");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                context.Result = new UnauthorizedObjectResult("Acesso Proibido");
            }

        }
    }
}
