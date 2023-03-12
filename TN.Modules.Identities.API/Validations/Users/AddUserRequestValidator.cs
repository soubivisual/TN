using FluentValidation;
using System.Text.RegularExpressions;
using TN.Modules.Buildings.API.Validator;
using TN.Modules.IdentitiesShared.Requests;

namespace TN.Modules.IdentitiesAPI.Validations.Users
{
    public class AddUserRequestValidator : ModelValidator<AddUserRequest>
    {
        public AddUserRequestValidator()
        {
            RuleFor(x => x.IdentificationTypeId).NotEmpty();
            RuleFor(x => x.Identification).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Phone).Matches(new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"));
            RuleFor(x => x.TypeId).NotEmpty();
            RuleFor(x => x.StatusId).NotEmpty();
        }
    }
}
