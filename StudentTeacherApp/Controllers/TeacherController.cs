using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentTeacherApp.Data.Interfaces;
using StudentTeacherApp.Data.Model.Model;

namespace StudentTeacherApp.UI.Controllers
{
	public class TeacherController : Controller
	{
		private readonly ITeacherRepository _teacherRepo;
		public TeacherController(ITeacherRepository teacherRepo)
		{
			_teacherRepo = teacherRepo;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _teacherRepo.GetAll());
		}

		[HttpPost]
		public async Task<IActionResult> Add(Teacher teacher)
		{
			var t = await _teacherRepo.Add(teacher);

			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int itemId)
		{
			await _teacherRepo.Delete(itemId);

			return PartialView("_TeachersTable", await _teacherRepo.GetAll());
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int teacherId)
		{
			var teacher = await _teacherRepo.Get(teacherId);
			return PartialView("~/Views/Shared/Partials/_EditTeacher.cshtml", teacher);
		}

	}
}
