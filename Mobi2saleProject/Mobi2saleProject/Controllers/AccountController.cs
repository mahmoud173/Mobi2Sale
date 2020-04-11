using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using Mobi2saleProject.Models;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Identity.UI.Pages.Account.Internal;
using System.Security.Cryptography;

namespace Mobi2saleProject.Controllers
{

    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ILogger<LogoutModel> logger;

        public AccountController(UserManager<IdentityUser> userManager 
                              , SignInManager<IdentityUser> signInManager
                              , ILogger<LogoutModel> logger)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.logger = logger;
        }

        // GET api/Account/UserInfo
        [Route("UserInfo")]
        public UserInfoViewModel GetUserInfo()
        {
            ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

            return new UserInfoViewModel
            {
                Email = User.FindFirstValue(ClaimTypes.Name),
                HasRegistered = externalLogin == null,
                LoginProvider = externalLogin != null ? externalLogin.LoginProvider : null
            };
        }

        [Route("Login")]
        public async Task<IActionResult> Login(LoginBindingModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email,model.Password,model.Remembermy,false);
                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

              ModelState.AddModelError("","Login is Not Valid");               
                return BadRequest(ModelState);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }



        // POST api/Account/Logout
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
           await signInManager.SignOutAsync();
            return Ok();
        }

        

        // POST api/Account/ChangePassword
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userId);

            IdentityResult result = await userManager.ChangePasswordAsync(user, model.OldPassword,
                model.NewPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        // POST api/Account/SetPassword
        [Route("SetPassword")]
        public async Task<IActionResult> SetPassword(SetPasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userId);

            IdentityResult result = await userManager.AddPasswordAsync(user, model.NewPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterBindingModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    model.id = user.Id;
                    var location = new Uri("http://localhost:5000/api/v1/client/" + model.id.ToString());
                    return Created(location, user);
                }
 
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return BadRequest(ModelState);

            }
            else
            {
                return BadRequest(ModelState);

            }

        }

        // POST api/Account/RegisterExternal
        [Route("RegisterExternal")]
        public async Task<IActionResult> RegisterExternal(RegisterExternalBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var info = await signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            var user = new IdentityUser{ UserName = model.Email, Email = model.Email };

            var result = await userManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return BadRequest(ModelState);
            }

            result = await userManager.AddLoginAsync(user, info);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return BadRequest(ModelState);
            }
            return Ok();
        }

        #region Helpers


        private IActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

        private class ExternalLoginData
        {
            public string LoginProvider { get; set; }
            public string ProviderKey { get; set; }
            public string UserName { get; set; }

            public IList<Claim> GetClaims()
            {
                IList<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, ProviderKey, null, LoginProvider));

                if (UserName != null)
                {
                    claims.Add(new Claim(ClaimTypes.Name, UserName, null, LoginProvider));
                }

                return claims;
            }

            public static ExternalLoginData FromIdentity(ClaimsIdentity identity)
            {
                if (identity == null)
                {
                    return null;
                }

                Claim providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);

                if (providerKeyClaim == null || String.IsNullOrEmpty(providerKeyClaim.Issuer)
                    || String.IsNullOrEmpty(providerKeyClaim.Value))
                {
                    return null;
                }

                if (providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
                {
                    return null;
                }

                return new ExternalLoginData
                {
                    LoginProvider = providerKeyClaim.Issuer,
                    ProviderKey = providerKeyClaim.Value,
                };
            }
        }

        private static class RandomOAuthStateGenerator
        {
            private static RandomNumberGenerator _random = new RNGCryptoServiceProvider();

          
        }

        #endregion

    }
}