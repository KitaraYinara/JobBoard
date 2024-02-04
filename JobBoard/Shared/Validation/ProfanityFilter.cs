using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Shared.Validations
{
    public class DisallowCertainWordsAttribute : ValidationAttribute
    {
        // Define a list of disallowed words
        private readonly string[] _disallowedWords;

        public DisallowCertainWordsAttribute() : base("The content contains inappropriate words.")
        {
            // Initialize the list of disallowed words
            _disallowedWords = new string[]
            { "inappropriate",
                "disallowed",
                "unacceptable",
                "stupid",
                "fuck",
                "crap",
                "damn",
                "murder"}; // Add more words here
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string stringValue)
            {
                // Check if the input contains any of the disallowed words
                if (_disallowedWords.Any(word => stringValue.Contains(word, StringComparison.OrdinalIgnoreCase)))
                {
                    // Return a validation error if a disallowed word is found
                    return new ValidationResult(ErrorMessage);
                }
            }

            // Return success if no disallowed words are found
            return ValidationResult.Success;
        }
    }
}
