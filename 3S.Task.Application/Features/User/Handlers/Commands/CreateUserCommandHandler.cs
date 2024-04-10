using AutoMapper;
using FluentValidation;
using MediatR;
using Models;
using Task.Application.Features.User.Validations;
using Task.Domain.Interfaces;
using Task.Domain.Shared;


namespace Task.Application.Features
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResponseModel>
	{
		private readonly IGenericRepository<Models.User> _repository;
		private readonly IMapper _mapper;
		private readonly IValidator<CreateUserCommand> _validator;

		public CreateUserCommandHandler(IGenericRepository<Models.User> repository, IMapper mapper,IValidator<CreateUserCommand> validator)
		{
			this._repository = repository;
			this._mapper = mapper;
			this._validator = validator;
		}
		public async Task<ResponseModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
		{

			
			var validationResult = await new CreateUserVaildation().ValidateAsync(request);

			
			if (!validationResult.IsValid)
			{
				
				return ResponseModel.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
			}

			var user = _mapper.Map<Models.User>(request);

			_repository.Add(user);
			var isSuccess = await _repository.SaveChangesAsync();

			if (!isSuccess)

				return ResponseModel.Failure("Internal Server Error!");

			return ResponseModel.Success();

		}
	}
}
