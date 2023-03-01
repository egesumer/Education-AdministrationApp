using SchoolManagementKD13.Domain;

namespace SchoolManagementKD13.MVCUI.Models
{
	public class StudentsIndexVM
	{
		public IEnumerable<Student> Students { get; set; } = new List<Student>();
		public string LoggedInUserRole { get; set; }
		public string LoggedInUserEmail { get; set; }
	}
}
