using System.Security.Claims;
using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class LoginController : Controller
    {

        ISecurityHelper _securityHelper;

        public LoginController(ISecurityHelper securityHelper)
        {
                _securityHelper = securityHelper;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserViewModel user)
        {

            if (ModelState.IsValid) 
            {

                var loginAPI = _securityHelper.Login(user.UserName, user.Password);

                if (loginAPI.Token != null) {

                    TokenAPI token = new TokenAPI
                    {
                        Token = loginAPI.Token.Token,
                        Expiration = loginAPI.Token.Expiration,

                    };

                    HttpContext.Session.SetString("Token", token.Token);


                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.NameIdentifier, user.UserName)

                    };
                    var roles = loginAPI.Roles.ToList();

                    foreach (var role in roles) {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    
                    }


                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);  



                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal
                                        , new AuthenticationProperties
                                        {
                                            IsPersistent = false
                                        }
                                );


                }

                return RedirectToAction("Index","Home");
            
            } else
            {
                ModelState.AddModelError("UserName", "Credenciales Inválidas");
                return View(user);
            }



            return View();
        }

        public IActionResult Logout()
        {

            HttpContext.Session.Remove("Token");
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Login");
        }



    }
}
