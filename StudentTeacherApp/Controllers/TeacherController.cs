using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentTeacherApp.Data.Interfaces;

namespace StudentTeacherApp.UI.Controllers
{
	public class TeacherController : Controller
	{
		private readonly ITeacherRepository _teacherRepo;
		public TeacherController(ITeacherRepository teacherRepo)
		{
			_teacherRepo = teacherRepo;
		}

		public IActionResult Index()
		{
			return View(_teacherRepo.GetAll());
		}
	}
}
