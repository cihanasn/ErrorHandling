using FluentValidation;

namespace Application.People.Commands
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.FirstName).MaximumLength(50).NotEmpty();
            RuleFor(x => x.LastName).MaximumLength(50).NotEmpty();
            RuleFor(x => x.TestField).MaximumLength(5).NotEmpty();
        }
    }
}
