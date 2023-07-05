using MediatR;

namespace Application.People.Commands
{
    public class CreatePersonCommand : IRequest
    {
        public CreatePersonCommand(string firstName, string lastName, string testField)
        {
            Id = Guid.NewGuid().ToString();
            FirstName = firstName;
            LastName = lastName;
            TestField = testField;
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TestField { get; set; }

        public class Handler : IRequestHandler<CreatePersonCommand>
        {
            public Task<Unit> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
            {
                // Perform the operations to add the person to the person table in the database
                return Task.FromResult(Unit.Value);
            }
        }
    }
}
