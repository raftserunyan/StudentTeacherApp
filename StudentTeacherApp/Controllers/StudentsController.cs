using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentTeacherApp.Data.Interfaces;
using StudentTeacherApp.Data.Model.Model;

namespace StudentTeacherApp.UI.Controllers
{
	public class StudentsController : Controller
	{
		private readonly IStudentRepository _studentRepo;
		public StudentsController(IStudentRepository studentRepo)
		{
			_studentRepo = studentRepo;
		}

		public IActionResult Index()
		{
			return View(_studentRepo.GetAllWithTeachers());
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View(new Student());
		}

	}
}
