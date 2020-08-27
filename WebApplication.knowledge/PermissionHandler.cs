using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication.knowledge
{
    public class PermissionHandler : IAuthorizationHandler
    {
        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            var pendingRequirements = context.PendingRequirements.ToList();

            foreach (var requirement in pendingRequirements)
            {
<<<<<<< HEAD
                //if (requirement is ReadPermission)
                //{
                //    if (IsOwner(context.User, context.Resource) ||
                //        IsSponsor(context.User, context.Resource))
                //    {
                //        context.Succeed(requirement);
                //    }
                //}
                //else if (requirement is EditPermission ||
                //         requirement is DeletePermission)
                //{
                //    if (IsOwner(context.User, context.Resource))
                //    {
                //        context.Succeed(requirement);
                //    }
                //}
=======
                if (requirement is ReadPermission)
                {
                    if (IsOwner(context.User, context.Resource) ||
                        IsSponsor(context.User, context.Resource))
                    {
                        context.Succeed(requirement);
                    }
                }
                else if (requirement is EditPermission ||
                         requirement is DeletePermission)
                {
                    if (IsOwner(context.User, context.Resource))
                    {
                        context.Succeed(requirement);
                    }
                }
>>>>>>> 2fa09d5af5840424aac6a8afa59b809f48c25e9f
            }

            //TODO: Use the following if targeting a version of
            //.NET Framework older than 4.6:
            //      return Task.FromResult(0);
            return Task.CompletedTask;
        }

        private bool IsOwner(ClaimsPrincipal user, object resource)
        {
            // Code omitted for brevity

            return true;
        }

        private bool IsSponsor(ClaimsPrincipal user, object resource)
        {
            // Code omitted for brevity

            return true;
        }
    }
}
