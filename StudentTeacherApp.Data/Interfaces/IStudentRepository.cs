using System.Collections.Generic;
using System.Threading.Tasks;
using StudentTeacherApp.Data.Model.Model;

namespace StudentTeacherApp.Data.Interfaces
{
	public interface IStudentRepository
	{
		Task<Student> Add(Student item);

		Task<List<Student>> GetAll();

		Task<List<Student>> GetAllWithTeachers();

		Task<Student> Get(int itemId);

		Task<Student> Update(Student item);

		Task Delete(int itemId);

	}
}
