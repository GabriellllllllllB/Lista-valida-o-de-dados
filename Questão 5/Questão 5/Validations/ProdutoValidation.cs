using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Questão_5.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class ProdutoValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var codigo = value as string;
            if (string.IsNullOrWhiteSpace(codigo))
                return new ValidationResult("Código do produto obrigatório.");

            if (!Regex.IsMatch(codigo, @"^[A-Z]{3}-\d{4}$"))
                return new ValidationResult("Código inválido. Formato: 'AAA-1234'.");

            if (codigo.Length != 8)
                return new ValidationResult("Código do produto deve ter 8 caracteres.");

            return ValidationResult.Success;
        }
    }
}
