using FluentValidation;
using TN.Modules.Buildings.Shared.Validator;
using TN.Modules.Identities.API.Requests;

namespace TN.Modules.Identities.API.Validations.Users
{
    public class AddUserRequestValidator : ModelValidator<AddUserRequest>
    {
        public AddUserRequestValidator()
        {
            RuleFor(x => x.IdentificationTypeId).NotEmpty();
            RuleFor(x => x.Identification).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Username).NotEmpty();
            //RuleFor(x => x.Email).EmailAddress();
            //RuleFor(x => x.Phone).Matches(new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"));
            RuleFor(x => x.TypeId).NotEmpty();
            RuleFor(x => x.StatusId).NotEmpty();
        }
    }
}
