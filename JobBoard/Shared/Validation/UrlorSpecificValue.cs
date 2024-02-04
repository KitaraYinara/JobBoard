using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JobBoard.Shared.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class UrlOrSpecificValueAttribute : ValidationAttribute
    {
        private readonly string _specificValue;
        private readonly bool _allowEmpty;

        public UrlOrSpecificValueAttribute(string specificValue, bool allowEmpty = false)
        {
            _specificValue = specificValue;
            _allowEmpty = allowEmpty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var stringValue = value as string;

            // Check if the string is empty and whether that's allowed
            if (string.IsNullOrEmpty(stringValue))
            {
                if (_allowEmpty)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult($"The {validationContext.DisplayName} field is required.");
                }
            }

            // Check for the specific value
            if (stringValue.Equals(_specificValue, StringComparison.OrdinalIgnoreCase))
            {
                return ValidationResult.Success;
            }

            // Check for a valid URL
            bool isValidUrl = Uri.TryCreate(stringValue, UriKind.Absolute, out Uri uriResult)
                              && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if (isValidUrl)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, _specificValue);
        }
    }
}
