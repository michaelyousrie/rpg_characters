using System;
using App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace App.Helpers.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class MustBeAdminAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User)context.HttpContext.Items["User"];
            if (user == null || !user.IsAdmin)
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Unauthorized! You are not an admin!" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
