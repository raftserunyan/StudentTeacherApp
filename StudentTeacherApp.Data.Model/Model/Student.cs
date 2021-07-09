using System.ComponentModel.DataAnnotations;

namespace StudentTeacherApp.Data.Model.Model
{
	public class Student
	{
		[Key]
		public int Id { get; set; }

		public string Name { get; set; }

		public int TeacherId { get; set; }

		public Teacher Teacher { get; set; }
	}
}
