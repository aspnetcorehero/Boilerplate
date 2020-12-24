using AspNetCoreHero.Boilerplate.Application.Constants;
using AspNetCoreHero.Boilerplate.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Web.Helpers
{
    public static class ClaimsHelper
    {
        public static void HasRequiredClaims(this ClaimsPrincipal claimsPrincipal, IEnumerable<string> permissions)
        {
            if (!claimsPrincipal.Identity.IsAuthenticated)
            {
                return;
            }
            var allClaims = claimsPrincipal.Claims.Select(a => a.Value).ToList();
            var success = allClaims.Intersect(permissions).Any();
            if (!success)
            {
                throw new Exception();
            }
            return;
        }

        public static void GetPermissions(this List<RoleClaimsViewModel> allPermissions, Type policy, string roleId)
        {
            FieldInfo[] fields = policy.GetFields(BindingFlags.Static | BindingFlags.Public);

            foreach (FieldInfo fi in fields)
            {
                allPermissions.Add(new RoleClaimsViewModel { Value = fi.GetValue(null).ToString(), Type = "Permissions" });
            }
        }

        public static async Task AddPermissionClaim(this RoleManager<IdentityRole> roleManager, IdentityRole role, string permission)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            if (!allClaims.Any(a => a.Type == "Permission" && a.Value == permission))
            {
                await roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, permission));
            }
        }
    }
}