using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CommentsController : ControllerBase
	{
		private readonly IGenericRepository<Comment> _commentRepository;

		public CommentsController(IGenericRepository<Comment> commentRepository)
		{
			_commentRepository = commentRepository;
		}

		[HttpGet]
		public IActionResult CommentList()
		{
			var values = _commentRepository.GetAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateComment(Comment comment)
		{
			
			_commentRepository.Create(comment);
			return Ok();
		}
		[HttpDelete("{id}")]
		public IActionResult RemoveComment(int id)
		{
			var value=_commentRepository.GetById(id);
			_commentRepository.Remove(value);
			return Ok();
		}
		[HttpPut]
		public IActionResult UpdateComment(Comment comment)
		{
			_commentRepository.Update(comment);
			return Ok();
		}
		[HttpGet("{id}")]
		public IActionResult GetComment(int id)
		{
			var value = _commentRepository.GetById(id);
			return Ok(value);
		}
	}
}
