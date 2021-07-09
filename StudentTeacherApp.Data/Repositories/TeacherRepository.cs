using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentTeacherApp.Data.Interfaces;
using StudentTeacherApp.Data.Model.Data;
using StudentTeacherApp.Data.Model.Model;

namespace StudentTeacherApp.Data.Repositories
{
	public class TeacherRepository : BaseRepository, ITeacherRepository
	{
		public TeacherRepository(StudentTeacherAppContext context) : base(context)
		{
		}

		public async Task<Teacher> Add(Teacher item)
		{
			if (item == null)
				throw new ArgumentNullException(nameof(item));

			await _context.AddAsync(item);
			await _context.SaveChangesAsync();

			return item;
		}

		public async Task Delete(int itemId)
		{
			var item = await _context.Set<Teacher>().FindAsync(itemId);

			if (item == null)
				throw new ArgumentNullException(nameof(itemId), "Given entity doesn't exist");

			_context.Set<Teacher>().Remove(item);

			await _context.SaveChangesAsync();
		}

		public async Task<Teacher> Get(int itemId)
		{
			return await _context.Set<Teacher>().FindAsync(itemId);
		}

		public async Task<List<Teacher>> GetAll()
		{
			return await _context.Set<Teacher>().ToListAsync();
		}

		public async Task<Teacher> Update(Teacher item)
		{
			_context.Entry(item).State = EntityState.Modified;
			await _context.SaveChangesAsync();

			return item;
		}
	}
}
