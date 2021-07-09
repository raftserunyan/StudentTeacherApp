using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentTeacherApp.Data.Model.Model
{
	public class Teacher
	{
		[Key]
		public int Id { get; set; }

		public string Name { get; set; }

		public List<Student> Students { get; set; }
	}
}
