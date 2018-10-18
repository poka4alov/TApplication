using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITILObjects;

namespace WebPortal.Models.Identity
{
	public class LoginModel:AppUser
	{
		public bool IsPersistent { get; set; }
	}
}