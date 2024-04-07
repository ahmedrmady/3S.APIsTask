using AutoMapper;
using MediatR;
using Models;
using Task.Domain.Interfaces;
using Task.Domain.Shared;


namespace Task.Application.Features
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResponseModel>
	{
		private readonly IGenericRepository<User> _repository;
		private readonly IMapper _mapper;

		public CreateUserCommandHandler(IGenericRepository<User> repository, IMapper mapper)
		{
			this._repository = repository;
			this._mapper = mapper;
		}
		public async Task<ResponseModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
		{
			var user = _mapper.Map<User>(request);

			_repository.Add(user);
			var isSuccess = await _repository.SaveChangesAsync();

			if (!isSuccess)

				return ResponseModel.Failure("Internal Server Error!");

			return ResponseModel.Success();

		}
	}
}
