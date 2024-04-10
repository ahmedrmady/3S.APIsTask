using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Features;

namespace Task.Application.Features.User.Validations
{
	public class CreateUserVaildation : AbstractValidator<CreateUserCommand>
	{
		public CreateUserVaildation()
		{
			RuleFor(u => u.FirstName).NotEmpty()
				  .WithMessage("The First name is required")
				  .MaximumLength(20)
				  .WithMessage("the max length is 20 chars");

			RuleFor(u => u.MiddleName).MaximumLength(40)
				  .WithMessage("the max length is 40 char ");

			RuleFor(u => u.LastName).NotEmpty()
				  .WithMessage("Required")
				  .MaximumLength(20)
				  .WithMessage("the max length is 40");


			RuleFor(u => u.BirthDate).NotEmpty()
			      .WithMessage(" birthdate is Required")
			      .Must(BeAtLeast20YearsOld)
			      .WithMessage("Age must be at least 20 years old.");

			RuleFor(x => x.MobileNumber)
		         .NotEmpty()
				 .WithMessage("Mobile number is required.")
		         .Matches(@"^\+\d{12}$")
				 .WithMessage("Invalid mobile number format. Example: +021006158123");

			RuleFor(x => x.Email)
		         .NotEmpty()
				 .WithMessage("Email is required.")
		         .EmailAddress().WithMessage("Invalid email format.");

			RuleForEach(x => x.Addresses)
			.SetValidator(new AddressDtoValidator());
		}

		private bool BeAtLeast20YearsOld(DateTime birthDate)
		{
			return DateTime.Today.AddYears(-20) >= birthDate.Date;
		}
	}
}
