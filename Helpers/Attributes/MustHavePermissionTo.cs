using System;
using App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace App.Helpers.Attributes
{
    public class MustHavePermissionTo : AbstractAttribute
    {
        protected readonly string _permission;

        public MustHavePermissionTo(string permission)
        {
            _permission = permission.ToLower();
        }

        public override void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User) context.HttpContext.Items["User"];

            if (! user.HasPermissionTo(_permission)) {
                context.Result = new JsonResult(new { message = "You do NOT have permission to do that!" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
