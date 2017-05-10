using System.Globalization;
using System.Windows.Controls;

namespace Validation.ValidationRules
{
    public class MustNotBe10ValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var text = (string)value;

            if(double.TryParse(text, out double zahl))
            {
                if (zahl == 10)
                    return new ValidationResult(false, "Value must not be 10.");

                return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, $"'{text}' could not be converted.");
        }
    }
}