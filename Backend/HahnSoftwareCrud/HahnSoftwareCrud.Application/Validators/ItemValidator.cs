using FluentValidation;
using HahnSoftwareCrud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnSoftwareCrud.Application.Validators
{
    public class ItemValidator : AbstractValidator<Item>
    {
        public ItemValidator()
        {
            RuleFor(item => item.Name).NotEmpty().WithMessage("Last name is required.");
            RuleFor(item => item.Name).Length(3,30).WithMessage("Name Lenght must be between 3 and 30 character");
            RuleFor(item => item.Quantity).InclusiveBetween(1, 99).WithMessage("Quantity must be between 1 and 99.");
        }
    }
}
