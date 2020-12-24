using AspNetCoreHero.Boilerplate.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Web.Areas.Identity.Pages
{
    public class ProfileModel : PageModel
    {
        public string Username { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] ProfilePicture { get; set; }
        public bool IsActive { get; set; }
        public int ImageHeight { get; set; }
        public int ImageWidth { get; set; }
        public List<string> Roles { get; set; }

        public bool IsSuperAdmin { get; set; }

        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task OnGetAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                UserId = userId;
                Username = user.UserName;
                ProfilePicture = user.ProfilePicture;
                FirstName = user.FirstName;
                LastName = user.LastName;
                IsActive = user.IsActive;
                IsSuperAdmin = roles.Contains("SuperAdmin");
                Roles = roles.ToList();
            }
        }

        public async Task<IActionResult> OnPostActivateUserAsync(string userId)
        {
            if (User.IsInRole("SuperAdmin"))
            {
                var currentUser = await _userManager.FindByIdAsync(userId);
                currentUser.IsActive = true;
                //currentUser.ActivatedBy = _userManager.GetUserAsync(HttpContext.User).Result.Id;
                await _userManager.UpdateAsync(currentUser);
                await OnGetAsync(userId);
                return RedirectToPage("Profile", new { area = "Identity", userId = userId });
            }
            else return default;
        }

        public async Task<IActionResult> OnPostDeActivateUserAsync(string userId)
        {
            if (User.IsInRole("SuperAdmin"))
            {
                var currentUser = await _userManager.FindByIdAsync(userId);
                currentUser.IsActive = false;
                await _userManager.UpdateAsync(currentUser);
                return RedirectToPage("Profile", new { area = "Identity", userId = userId });
            }
            else return default;
        }
    }
}