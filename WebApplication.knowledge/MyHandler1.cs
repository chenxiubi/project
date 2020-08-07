using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication.knowledge
{
    public class MyHandler1 : IAuthorizationHandler
    {
        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            var identity = new ClaimsIdentity();
            identity.AddClaim(new Claim(ClaimTypes.Role, "User"));
           
            //context.Succeed(new User { Name = "张三" });

            //throw new NotImplementedException();
            return Task.CompletedTask;
        }
    }
}
