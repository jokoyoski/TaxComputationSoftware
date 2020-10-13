using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace TaxComputationAPI.Models.CustomHandler
{
    public class SystemAdminHandler : AuthorizationHandler<SystemAdminRequirment>
    {

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SystemAdminRequirment requirement)
        {
          
            
            IEnumerable<ClaimsIdentity>  identities=context.User.Identities;
            var identity= identities.FirstOrDefault();
            var y=identity.Claims;
             foreach(var j in y){
                 
                if(j.Value=="User"){
                    context.Succeed(requirement);
                }
             }
            return Task.CompletedTask;
        }
    }
}