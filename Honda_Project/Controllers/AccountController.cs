using Honda_Project.Areas.Admin.ViewsModels;
using Honda_Project.Enums;
using Honda_Project.Services;
using Honda_Project.ViewsModels.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

[Authorize]
public class AccountController(
    UserManager<IdentityUser> userManager,
    SignInManager<IdentityUser> singInManager) : Controller
{
    #region Register

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register(AccountRegister model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = new IdentityUser()
        {
            Email = model.Email,
            UserName = model.Email
        };

        var result = await userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }


        var admins = await userManager.GetUsersInRoleAsync("Admin");
        string roleToAssign = admins.Count == 0 ? "Admin" : "Customer";



        await userManager.AddToRoleAsync(user, roleToAssign);
        await singInManager.SignInAsync(user, isPersistent: false);

        return RedirectToAction("Index", "Home");
    }

    #endregion

    #region Login

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login(string? returnUrl)
    {
        var model = new AccountLogin() { ReturnUrl = returnUrl };
        return View(model);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(AccountLogin model)
    {

        if (!ModelState.IsValid)
            return View(model);

        var result = await singInManager.PasswordSignInAsync(
            model.Email,
            model.Password,
            model.RememberMe,
            false);

        if (!result.Succeeded)
        {
            ModelState.AddModelError(string.Empty, "Invalid login or password");
            return View(model);
        }

        if (!String.IsNullOrWhiteSpace(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
            return Redirect(model.ReturnUrl);

        return RedirectToAction("Index", "Home");
    }

    #endregion
    #region ChangePassword
    [HttpGet]
    public IActionResult ChangePassword()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ChangePassword(AccountChangePassword model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = await userManager.GetUserAsync(User);
        if (user is null)
            return RedirectToAction("Login");

        
        var result = await userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }

        await singInManager.RefreshSignInAsync(user);

        TempData["Message"] = "Ваш пароль успешно изменен.";
        return RedirectToAction("Index", "Home");
    }

    #endregion
    #region Get
    [HttpGet]
    public async Task<IActionResult> Profile()
    {

        var user = await userManager.GetUserAsync(User);
        if (user is null)
            return Unauthorized();


        var roles = await userManager.GetRolesAsync(user);


        var model = new AccountProfile
        {
            UserId = int.TryParse(user.Id, out int id) ? id : 0,
            Email = user.Email ?? string.Empty,
            Role = roles.FirstOrDefault() ?? "No Role"
        };

        return View(model);
    }
    #endregion

    public async Task<IActionResult> Logout()
    {
        await singInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    public IActionResult AccessDenied()
    {
        return View();
    }
}