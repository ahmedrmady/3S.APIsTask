using FluentValidation;
using Task.Application.Dtos;

namespace Task.Application.Features.User.Validations
{
	public class AddressDtoValidator:AbstractValidator<AddressDto>
	{
        public AddressDtoValidator()
        {
			RuleFor(x => x.GovernateId)
		           .NotEmpty()
		           .WithMessage("Governate is required.");

			RuleFor(x => x.CityId)
				.NotEmpty()
				.WithMessage("City is required.");

			RuleFor(x => x.Street)
				.NotEmpty()
				.WithMessage("Street is required.")
				.MaximumLength(200)
				.WithMessage("Street must be at most 200 characters long.");

			RuleFor(x => x.BuildingNumber)
				.NotEmpty()
				.WithMessage("Building number is required.");

			RuleFor(x => x.FlatNumber)
				.NotEmpty()
				.WithMessage("Flat number is required.");
		}
    }
}
