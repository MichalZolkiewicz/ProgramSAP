using FluentValidation;
using ProgramSAP.ApplicationServices.API.Domain.Candidate.Add;

namespace ProgramSAP.ApplicationServices.API.Validators;

public class AddCandidateRequestValidator : AbstractValidator<AddCandidateRequest>
{
    public AddCandidateRequestValidator()
    {
        this.RuleFor(x => x.Name).MaximumLength(250).NotNull().NotEmpty().NotEqual("string");
        this.RuleFor(x => x.Surname).MaximumLength(250).NotNull().NotEmpty().NotEqual("string");
        this.RuleFor(x => x.Email).NotNull().NotEmpty().NotEqual("string");
        this.RuleFor(x => x.Password).NotNull().NotEmpty().MaximumLength(100).NotEqual("string");
    }
}

