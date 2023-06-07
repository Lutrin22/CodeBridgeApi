using CodeBridgeApi.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.Security.Cryptography;

namespace CodeBridgeApi.Validators
{
    public class DogsValidator : AbstractValidator<DogCreateModel>
    {
        public DogsValidator()
        {
            
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("The dog name cannot be empty.");
            RuleFor(s => s.Tail_Length)
                .Custom((s, context) =>
                {
                    if ((!(int.TryParse(s, out int value)) || value <= 0))
                    {
                        context.AddFailure("Tail length is not a valid number or not a positive number");
                    }
                });
            RuleFor(s => s.Weight)
                .Custom((s, context) =>
                {
                    if ((!(int.TryParse(s, out int value)) || value <= 0))
                    {
                        context.AddFailure("Weight is not a valid number or not a positive number");
                    }
                });

        }
       
    }

}

