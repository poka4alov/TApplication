using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using WebPortal.Models.Identity;
using ITILObjects.Model;
using ItsmCore.Services.Identity;

namespace WebPortal.Controllers.Api.Account
{
	public class AccountController : ApiController
	{
		UserProfileService _userProfileService;
		public AccountController()
		{
			_userProfileService = new UserProfileService();
		}
		// GET api/<controller>
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<controller>/5
		public async Task<JsonResult<JsonUserProfileModel>> Get(string id)
		{
			IUserProfile _userProfile = await _userProfileService.GetUserProfileAsync(id);

			return Json(new JsonUserProfileModel { AvatarPathStr = _userProfile.AvatarPathStr, Name =_userProfile.Name, Position =_userProfile.Position,Address=_userProfile.Address });
		}



		// POST api/<controller>
		public void Post([FromBody]string value)
		{
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/<controller>/5
		public void Delete(int id)
		{
		}
	}
}