using Microsoft.EntityFrameworkCore;
using StudentTeacherApp.Data.Model.Model;

namespace StudentTeacherApp.Data.Model.Data
{
	public class StudentTeacherAppContext : DbContext
	{
		public StudentTeacherAppContext(DbContextOptions<StudentTeacherAppContext> options) : base(options)
		{
		}

		public DbSet<Student> Students { get; set; }

		public DbSet<Teacher> Teachers { get; set; }

	}
}
