namespace WebApi.ValidationAttributes;

using System.ComponentModel.DataAnnotations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
public class GreaterThanZeroIntegerValidationAttribute : ValidationAttribute
{
	protected override ValidationResult? IsValid(Object? value, ValidationContext validationContext)
	{
		if (value is Int32 id && id > 0)
			return ValidationResult.Success;

		var errorMessage = "Must be greater than 0.";
		return new ValidationResult(errorMessage);
	}
}
