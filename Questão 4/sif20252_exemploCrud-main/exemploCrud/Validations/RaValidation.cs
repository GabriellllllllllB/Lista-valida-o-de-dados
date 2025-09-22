using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace exemploCrud.Validators
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class RaValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var str = value as string;
            if (string.IsNullOrWhiteSpace(str))
                return new ValidationResult("RA é obrigatório.");

            var ra = str.Trim().ToUpperInvariant();

            if (!Regex.IsMatch(ra, @"^RA\d{6}$"))
                return new ValidationResult("RA inválido. O RA deve começar com RA e 6 números de 0 a 9");

            return ValidationResult.Success;
        }
    }
}
