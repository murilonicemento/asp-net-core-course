using ContactsManager.Core.Domain.IdentityEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts.DTO;
using ServiceContracts.Enums;

namespace CRUDExample.Controllers;

[Route("[controller]/[action]")]
[AllowAnonymous]
public class AccountController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<ApplicationRole> _roleManager;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
        RoleManager<ApplicationRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    [HttpGet]
    [Authorize("NotAuthorized")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [Authorize("NotAuthorized")]
    // [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterDTO registerDto)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Errors = ModelState.Values.SelectMany(temp => temp.Errors).Select(temp => temp.ErrorMessage);

            return View(registerDto);
        }

        ApplicationUser user = new ApplicationUser
        {
            Email = registerDto.Email,
            PhoneNumber = registerDto.Phone,
            UserName = registerDto.Email,
            PersonName = registerDto.Name
        };

        IdentityResult result = await _userManager.CreateAsync(user, registerDto.Password);

        if (result.Succeeded)
        {
            if (registerDto.UserType == UserTypeOptions.Admin)
            {
                if (await _roleManager.FindByNameAsync(UserTypeOptions.Admin.ToString()) is null)
                {
                    ApplicationRole applicationRole = new() { Name = UserTypeOptions.Admin.ToString() };
                    await _roleManager.CreateAsync(applicationRole);
                }

                await _userManager.AddToRoleAsync(user, UserTypeOptions.Admin.ToString());
            }
            else
            {
                if (await _roleManager.FindByNameAsync(UserTypeOptions.User.ToString()) is null)
                {
                    ApplicationRole applicationRole = new() { Name = UserTypeOptions.User.ToString() };
                    await _roleManager.CreateAsync(applicationRole);
                }

                await _userManager.AddToRoleAsync(user, UserTypeOptions.User.ToString());
            }

            await _signInManager.SignInAsync(user, false);
            return RedirectToAction(nameof(PersonsController.Index), "Persons");
        }

        foreach (IdentityError error in result.Errors)
        {
            ModelState.AddModelError("Register", error.Description);
        }

        return View(registerDto);
    }

    [HttpGet]
    [Authorize("NotAuthorized")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [Authorize("NotAuthorized")]
    public async Task<IActionResult> Login(LoginDTO loginDto, string? ReturnUrl)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Errors = ModelState.Values.SelectMany(temp => temp.Errors).Select(temp => temp.ErrorMessage);

            return View(loginDto);
        }

        var result = await _signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password, false, false);

        if (result.Succeeded)
        {
            ApplicationUser? user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user is not null)
            {
                if (await _userManager.IsInRoleAsync(user, UserTypeOptions.Admin.ToString()))
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
            }

            if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
            {
                return LocalRedirect(ReturnUrl);
            }

            return RedirectToAction(nameof(PersonsController.Index), "Persons");
        }

        ModelState.AddModelError("Login", "Invalid email or password");

        return View();
    }

    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();

        return RedirectToAction(nameof(PersonsController.Index), "Persons");
    }

    [AllowAnonymous]
    public async Task<IActionResult> IsEmailAlreadyRegistered(string email)
    {
        ApplicationUser? user = await _userManager.FindByEmailAsync(email);

        return user == null ? Json(true) : Json(false);
    }
}