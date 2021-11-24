using System;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.Security.Attributes
{
    // Creating a custom attribute, the attribute name is "Authorize"
    // In every custom attributes -> <Name>Attribute, <Name> will be used [<Name>]
    // In our case : [Authorize]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User) context.HttpContext.Items["User"];
            if (user == null)
            {
                // Not logged in
                context.Result = 
                    new JsonResult(new
                    {
                        message = "Unauthorized"
                    })
                    {
                        StatusCode = StatusCodes.Status401Unauthorized
                    };
            }
            // TODO : check role
        }
    }
}