using System.ComponentModel.DataAnnotations;
using store.Enums;
using store.Messages;

namespace store.Validators;

public class ValidatorBody : ValidationAttribute
{
    private readonly BodyOptions[] rules;
    
    public ValidatorBody(BodyOptions[] rules)
    {
        this.rules = rules;
    }
    
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        foreach (var rule in rules)
        {
            switch (rule)
            {
                case BodyOptions.Required:
                    if (value == null || (value is string strValue && string.IsNullOrWhiteSpace(strValue)))
                        return new ValidationResult(MessagesClass.RequiredField(validationContext.DisplayName));

                    break;

                case BodyOptions.IsString:
                    if (value != null && value.GetType() != typeof(string))
                        return new ValidationResult(MessagesClass.InvalidFormat(validationContext.DisplayName));

                    break;

                case BodyOptions.IsEmail:
                    if (value != null)
                    {
                        var emailIsValidate = new EmailAddressAttribute();

                        if (value is not string email || string.IsNullOrWhiteSpace(email) || !emailIsValidate.IsValid(value))
                            return new ValidationResult(MessagesClass.InvalidEmailField(validationContext.DisplayName));

                    }
                    break;

                case BodyOptions.IsPassword:
                    if (value != null)
                        if (value is not string password || string.IsNullOrWhiteSpace(password) || password.Length < 6)
                            return new ValidationResult(MessagesClass.InvalidFormat(validationContext.DisplayName));

                    break;
                case BodyOptions.IsRole:
                    if (value != null)
                        if (value is not Role role)
                            return new ValidationResult(MessagesClass.InvalidFormat(validationContext.DisplayName));
                    break;
                default:
                    throw new NotImplementedException($"La regla de validación '{rule}' no está implementada.");
            }
        }
        return ValidationResult.Success;
    }
}
