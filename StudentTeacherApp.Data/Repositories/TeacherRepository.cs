using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentTeacherApp.Data.Interfaces;
using StudentTeacherApp.Data.Model.Data;
using StudentTeacherApp.Data.Model.Model;

namespace StudentTeacherApp.Data.Repositories
{
	internal class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
	{
		public TeacherRepository(StudentTeacherAppContext context) : base(context)
		{
		}

		public async Task<Teacher> GetWithStudents(int itemId)
		{
			return await _context.Set<Teacher>().Include(i => i.Students).FirstOrDefaultAsync(i => i.Id == itemId);
		}
	}
}
