using System;
using StudentTeacherApp.Data.Model.Data;

namespace StudentTeacherApp.Data.Repositories
{
	public class BaseRepository
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
	}
}
