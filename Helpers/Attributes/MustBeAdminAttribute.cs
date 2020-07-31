using System;
using App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace App.Helpers.Attributes
{
    public class MustBeAdminAttribute : AbstractAttribute
    {
        public override void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User)context.HttpContext.Items["User"];
            if (user == null || !user.IsAdmin)
            {
                // User is not an admin!
                context.Result = new JsonResult(new { message = "Unauthorized! You are not an admin!" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
