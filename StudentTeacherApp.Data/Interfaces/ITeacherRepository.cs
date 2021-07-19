using System.Threading.Tasks;
using StudentTeacherApp.Data.Model.Model;

namespace StudentTeacherApp.Data.Interfaces
{
	internal interface ITeacherRepository
	{
		Task<Teacher> GetWithStudents(int itemId);
	}
}
