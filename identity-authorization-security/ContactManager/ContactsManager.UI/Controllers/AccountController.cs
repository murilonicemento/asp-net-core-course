using ContactsManager.Core.Domain.IdentityEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts.DTO;

namespace CRUDExample.Controllers;

[Route("[controller]/[action]")]
[AllowAnonymous]
public class AccountController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
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
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDTO loginDto)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Errors = ModelState.Values.SelectMany(temp => temp.Errors).Select(temp => temp.ErrorMessage);

            return View(loginDto);
        }

        var result = await _signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password, false, false);

        if (result.Succeeded)
        {
            return RedirectToAction(nameof(PersonsController.Index), "Persons");
        }

        ModelState.AddModelError("Login", "Invalid email or password");

        return View();
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();

        return RedirectToAction(nameof(PersonsController.Index), "Persons");
    }
}