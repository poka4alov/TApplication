using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using ItsmCore.Services.Identity;
using Microsoft.AspNet.Identity;
using ITILObjects;

[assembly: OwinStartup(typeof(WebPortal.App_Start.Startup))]

namespace WebPortal.App_Start
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			
			app.CreatePerOwinContext<AppUserService>(CreateUserService);
			app.UseCookieAuthentication(new CookieAuthenticationOptions
			{
				AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
				LoginPath = new PathString("/Account/Login"),
			});
		}

		private AppUserService CreateUserService()
		{
			return new AppUserService();
		}
	}
}