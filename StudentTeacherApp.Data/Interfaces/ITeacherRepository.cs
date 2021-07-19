using System.Collections.Generic;
using System.Threading.Tasks;
using StudentTeacherApp.Data.Model.Model;

namespace StudentTeacherApp.Data.Interfaces
{
	public interface ITeacherRepository
	{
		Task<Teacher> Add(Teacher item);

		Task<List<Teacher>> GetAll();

		Task<Teacher> Get(int itemId);

		Task<Teacher> GetWithStudents(int itemId);

		Task<Teacher> Update(Teacher item);

		Task Delete(int itemId);
	}
}
