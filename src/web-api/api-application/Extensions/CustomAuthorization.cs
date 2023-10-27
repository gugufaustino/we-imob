using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApiApplication.Extensions
{
    public class Action
    {
        public const string GET = "CONSULTAR";
        public const string POST = "INSERIR";
        public const string PUT = "EDITAR";
        public const string DELETE = "DELETAR";
    }
    public class CustomAuthorization
    {
        public static bool ValidarClaimsUsuario(HttpContext context, string claimName, string claimValue)
        {
            return context.User.Identity.IsAuthenticated &&
                   context.User.Claims.Any(c => c.Type == claimName && c.Value.Contains(claimValue));
        }
    }

    public class ClaimsAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimsAuthorizeAttribute(string claimName, string claimValue = "") : base(typeof(RequisitoClaimFilter))
        {
            Arguments = new object[] { new Claim(claimName, claimValue) };
        }
    }
    public class RequisitoClaimFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;

        public RequisitoClaimFilter(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new StatusCodeResult(401);
                return;
            }

            var claimValue = string.Empty;
            if (!string.IsNullOrEmpty(_claim.Type) && string.IsNullOrEmpty(_claim.Value))
            {
                var method = context.ActionDescriptor.ActionConstraints.FirstOrDefault();
                if (method.GetType() == typeof(Microsoft.AspNetCore.Mvc.ActionConstraints.HttpMethodActionConstraint))
                {
                    var methodType = ((Microsoft.AspNetCore.Mvc.ActionConstraints.HttpMethodActionConstraint)method).HttpMethods.First();
                    claimValue = methodType switch
                    {
                        "GET" => Action.GET,
                        "DELETE" => Action.DELETE,
                        "POST" => Action.POST,
                        "PUT" => Action.PUT,
                        _ => throw new InvalidOperationException(),
                    };
                }
            }
            else
            {
                claimValue = _claim.Value;
            }

            if (!CustomAuthorization.ValidarClaimsUsuario(context.HttpContext, _claim.Type, claimValue))
            {
                context.Result = new StatusCodeResult(403);
            }
        }
    }


}
