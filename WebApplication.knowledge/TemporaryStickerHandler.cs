using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.knowledge
{
    public class TemporaryStickerHandler : AuthorizationHandler<BuildingEntryRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, BuildingEntryRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Type == "TemporaryBadgeId" &&
                                       c.Issuer == "https://microsoftsecurity"))
            {
                // We'd also check the expiration date on the sticker.
                context.Succeed(requirement);
            }

            //TODO: Use the following if targeting a version of
            //.NET Framework older than 4.6:
            //      return Task.FromResult(0);
            return Task.CompletedTask;
        }
    }
}
