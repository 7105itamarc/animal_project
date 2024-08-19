using System.ComponentModel.DataAnnotations;

namespace _1907FirstWebAppAtempt.validations
{
    public class IsPossitiveNumber : ValidationAttribute    
    {
        public override bool IsValid(object? value)
        {
            if (value != null)
                return (int)value > 0;
            return false;
        }

    }
}
