using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentTeacherApp.Data.Model.Data;

namespace StudentTeacherApp.Data.Repositories
{
	internal class BaseRepository<T> where T: class
	{
		protected readonly StudentTeacherAppContext _context;

		public BaseRepository(StudentTeacherAppContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			_context = context;
		}

		public async Task<T> Add(T item)
		{
			if (item == null)
				throw new ArgumentNullException(nameof(item));

			await _context.AddAsync(item);
			await _context.SaveChangesAsync();

			return item;
		}

		public async Task<T> Get(int itemId)
		{
			return await _context.Set<T>().FindAsync(itemId);
		}

		public async Task<List<T>> GetAll()
		{
			return await _context.Set<T>().ToListAsync();
		}

		public async Task<T> Update(T item)
		{
			_context.Entry(item).State = EntityState.Modified;

			await _context.SaveChangesAsync();

			return item;
		}

		public async Task Delete(int itemId)
		{
			var item = await _context.Set<T>().FindAsync(itemId);

			if (item == null)
				throw new ArgumentNullException(nameof(itemId), "Given entity doesn't exist");

			_context.Set<T>().Remove(item);

			await _context.SaveChangesAsync();
		}

		
	}
}
