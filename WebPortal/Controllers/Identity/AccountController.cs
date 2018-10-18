using System.Collections.Generic;
using System.Web;
using System.Web.Http.Owin;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Security.Claims;
using ItsmCore.Services.Identity;
using WebPortal.Models.Identity;
using ITILObjects;
using Microsoft.AspNet.Identity;

namespace WebPortal.Controllers.Identity
{
	public class AccountController : Controller
	{

		private AppUserService UserService
		{
			get
			{
				return HttpContext.GetOwinContext().GetUserManager<AppUserService>();
			}
		}

		private IAuthenticationManager AuthenticationManager
		{
			get
			{
				return HttpContext.GetOwinContext().Authentication;
			}
		}

		[AllowAnonymous]
		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Login(LoginModel model)
		{
			
			if (ModelState.IsValid)
			{
				AppUser appUser = new AppUser { Email = model.Email, Password = model.Password };
				ClaimsIdentity claim = await UserService.Authenticate(appUser, DefaultAuthenticationTypes.ApplicationCookie);
				if (claim == null)
				{
					ModelState.AddModelError("", "Неверный логин или пароль.");
				}
				else
				{
					AuthenticationManager.SignOut();
					AuthenticationManager.SignIn(new AuthenticationProperties
					{
						IsPersistent = model.IsPersistent,
					}, claim);
					return RedirectToAction("Index", "Home");
				}
			}
			return View(model);
		}

		public ActionResult Logout()
		{
			AuthenticationManager.SignOut();
			return RedirectToAction("Login", "Account");
		}

		[Authorize(Roles = "admin")]
		public ActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[Authorize(Roles ="admin")]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Register(RegisterModel model)
		{
			
			if (ModelState.IsValid)
			{
				AppUser appUser = new AppUser
				{
					Email = model.Email,
					Password = model.Password,
					Address = model.Address,
					Name = model.Name,
					Role = "user"
				};
				OperationDetails operationDetails = await UserService.Create(appUser);
				
				if (operationDetails.Succedeed)
					return View("SuccessRegister");
				else
					ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
			}
			return View(model);
		}
    }
}
