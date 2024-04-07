using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task.Application.Features;

namespace Task.Presentation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IMediator _mediator;

		public UserController(IMediator mediator)
		{
			this._mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateUserCommand product)
		{
			var result = await _mediator.Send(product);
			return Ok(result);
		}

	}
}
