using Microsoft.AspNetCore.Mvc;
using StudentManagementKD13.MVCUI.Models;
using System.Diagnostics;

namespace StudentManagementKD13.MVCUI.Controllers
{
	public class HomeController : Controller
	{

		public IActionResult Index()
		{
			return View();
		}

	}
}