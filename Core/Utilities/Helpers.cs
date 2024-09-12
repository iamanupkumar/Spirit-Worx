using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities;

public sealed class NoSpacesAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string str && str.Contains(" "))
        {
            var propertyName = validationContext.MemberName!;
            var errorMessage = string.IsNullOrEmpty(ErrorMessage)
                ? $"{propertyName.SplitPascalCase()} should not contain spaces."
                : ErrorMessage;

            return new ValidationResult(errorMessage, new[] { propertyName });
        }
        return ValidationResult.Success!;
    }
}

public sealed class ValidEnumAttribute<TEnum> : ValidationAttribute where TEnum : struct, Enum
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        var propertyName = validationContext.MemberName!;
        if (value == null)
        {
            return new ValidationResult($"{propertyName.SplitPascalCase()} is required.", new[] { propertyName });
        }

        if (value is TEnum enumValue)
        {
            if (enumValue.Equals(default(TEnum)))
            {
                var errorMessage = string.IsNullOrEmpty(ErrorMessage)
                    //? $"{propertyName.SplitPascalCase()} cannot be {enumValue}."
                    ? $"{propertyName.SplitPascalCase()} is required."
                    : ErrorMessage;

                return new ValidationResult(errorMessage, new[] { propertyName });
            }

            return ValidationResult.Success!;
        }

        return new ValidationResult($"Invalid {propertyName.SplitPascalCase()} type.", new[] { propertyName });
    }
}

