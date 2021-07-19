using System.Collections.Generic;
using StudentTeacherApp.Data.Interfaces;
using StudentTeacherApp.Data.Model.Data;
using StudentTeacherApp.Data.Model.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace StudentTeacherApp.Data.Repositories
{
	internal class StudentRepository : BaseRepository<Student>, IStudentRepository
	{
		public StudentRepository(StudentTeacherAppContext context) : base(context)
		{
		}

		public Task<List<Student>> GetAllWithTeachers()
		{
			return _context.Set<Student>().Include(i => i.Teacher).ToListAsync();
		}
	}
}
