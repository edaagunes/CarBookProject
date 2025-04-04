using CarBook.Application.Interfaces.AuthorInterfaces;
using CarBook.Domain.Entities;
using Infrastructure.CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.AuthorRepositories
{
	public class AuthorRepository : IAuthorRepository
	{
		private readonly CarBookContext _context;

		public AuthorRepository(CarBookContext context)
		{
			_context = context;
		}

		public List<Blog> GetBlogsByAuthorId(int id)
		{
			return _context.Blogs.Include(x=>x.Author).Where(y=>y.AuthorId == id).ToList();
		}
	}
}
