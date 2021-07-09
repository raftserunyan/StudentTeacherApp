using System;
using System.Collections.Generic;
using StudentTeacherApp.Data.Interfaces;
using StudentTeacherApp.Data.Model.Data;
using StudentTeacherApp.Data.Model.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace StudentTeacherApp.Data.Repositories
{
	public class StudentRepository : BaseRepository, IStudentRepository
	{
		public StudentRepository(StudentTeacherAppContext context) : base(context)
		{
		}

		public async Task<Student> Add(Student item)
		{
			if (item == null)
				throw new ArgumentNullException(nameof(item));

			await _context.AddAsync(item);
			await _context.SaveChangesAsync();

			return item;
		}

		public async Task<Student> Get(int itemId)
		{
			return await _context.Set<Student>().FindAsync(itemId);
		}

		public async Task<List<Student>> GetAll()
		{
			return await _context.Set<Student>().ToListAsync();
		}

		public async Task<Student> Update(Student item)
		{
			_context.Entry(item).State = EntityState.Modified;

			await _context.SaveChangesAsync();

			return item;
		}

		public async Task Delete(int itemId)
		{
			var item = await _context.Set<Student>().FindAsync(itemId);

			if (item == null)
				throw new ArgumentNullException(nameof(itemId), "Given entity doesn't exist");

			_context.Set<Student>().Remove(item);

			await _context.SaveChangesAsync();
		}

	}
}
