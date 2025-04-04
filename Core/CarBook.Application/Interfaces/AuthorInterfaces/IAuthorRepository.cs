using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.AuthorInterfaces
{
	public interface IAuthorRepository
	{
		List<Blog> GetBlogsByAuthorId(int id);
	}
}
