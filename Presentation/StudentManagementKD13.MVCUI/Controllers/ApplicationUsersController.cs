using Microsoft.AspNetCore.Mvc;

namespace StudentManagementKD13.MVCUI.Controllers
{
	public class ApplicationUsersController : Controller
	{
		public IActionResult Register()
		{
			return View();
		}
		public IActionResult Login()
		{
			return View();
		}

		//public IActionResult Logout()
		//{
		//	//todo Clear session and redirect
		//	//HttpContext.Session.Remove
		//}

	}
}
