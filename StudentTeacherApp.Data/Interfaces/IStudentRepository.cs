using System.Collections.Generic;
using System.Threading.Tasks;
using StudentTeacherApp.Data.Model.Model;

namespace StudentTeacherApp.Data.Interfaces
{
	internal interface IStudentRepository
	{
		Task<List<Student>> GetAllWithTeachers();
	}
}
