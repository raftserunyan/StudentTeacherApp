using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentTeacherApp.Data.Interfaces;
using StudentTeacherApp.Data.Model.Model;

namespace StudentTeacherApp.UI.Controllers
{
	public class StudentsController : Controller
	{
		private readonly IStudentRepository _studentRepo;
		private readonly ITeacherRepository _teacherRepo;
		public StudentsController(IStudentRepository studentRepo, ITeacherRepository teacherRepo)
		{
			_studentRepo = studentRepo;
			_teacherRepo = teacherRepo;
		}

		public async Task<IActionResult> Index()
		{
			ViewBag.Teachers = await _teacherRepo.GetAll();
			return View(await _studentRepo.GetAllWithTeachers());
		}

		[HttpPost]
		public async Task<IActionResult> Add(Student student)
		{
			await _studentRepo.Add(student);

			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int itemId)
		{
			await _studentRepo.Delete(itemId);

			return PartialView(@"~/Views/Students/Partials/_StudentsTable.cshtml", await _studentRepo.GetAllWithTeachers());
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int studentId)
		{
			return PartialView(@"~/Views/Students/Partials/_EditStudent.cshtml", await _studentRepo.Get(studentId));
		}
		[HttpPost]
		public async Task<IActionResult> Edit(Student student)
		{
			await _studentRepo.Update(student);

			return RedirectToAction("index");
		}
	}
}
