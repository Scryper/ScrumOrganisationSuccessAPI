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
    // This attribute allows to say who has access to what
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private bool DeveloperAccess { get; set; }
        private bool ScrumMasterAccess { get; set; }
        private bool ProductOwnerAccess { get; set; }

        public AuthorizeAttribute(bool developerAccess, bool scrumMasterAccess, bool productOwnerAccess)
        {
            DeveloperAccess = developerAccess;
            ScrumMasterAccess = scrumMasterAccess;
            ProductOwnerAccess = productOwnerAccess;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User) context.HttpContext.Items["User"];
            if (user == null
                || !DeveloperAccess && user.Role == 1
                || !ScrumMasterAccess && user.Role == 2
                || !ProductOwnerAccess && user.Role == 3)
            {
                SendUnauthorizedAccessMessage(context);
            }
        }

        private void SendUnauthorizedAccessMessage(AuthorizationFilterContext context)
        {
            context.Result = 
                new JsonResult(new
                {
                    message = "Unauthorized"
                })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
        }
    }
}