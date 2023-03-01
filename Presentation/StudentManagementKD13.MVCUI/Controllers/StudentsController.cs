using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagementKD13.Application.DTOs;
using SchoolManagementKD13.MVCUI.Models;

namespace SchoolManagementKD13.MVCUI.Controllers
{
	public class StudentsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult GetStudentsListPartial(StudentsIndexVM studentsIndexVM)
		{
			HttpContext.Session.SetString("email", studentsIndexVM.LoggedInUserEmail);
			return PartialView("_StudentsListPartial", studentsIndexVM);
		}
		[HttpPost]
		public IActionResult GetStudentCreatePartial(SchoolIndexVM schoolIndexVM)
		{
			ViewData["SchoolId"] = new SelectList(schoolIndexVM.Schools, "Id", "Name");
			return PartialView("_CreateStudentPartial");
		}
	}
}
