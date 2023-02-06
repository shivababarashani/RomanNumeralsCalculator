using Calculator.Web.Models.Calculator;
using FluentValidation;

namespace Calculator.Web.Validations
{
    public class CalculatorViewModelValidator : AbstractValidator<CalculatorViewModel>
    {
        public CalculatorViewModelValidator()
        {
            RuleFor(x => x.FirstNumber).NotEmpty().WithMessage("The First Number field is required.");
            RuleFor(x => x.SecoundNumber).NotEmpty().WithMessage("The Secound Number field is required.");
           
        }
    }
}

