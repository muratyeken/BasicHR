using FluentValidation;
using HumanResourcesApp.Application.Models.VMs;
using HumanResourcesApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HumanResourcesApp.Application.Extensions
{
    public class PhoneNumberExtension : AbstractValidator<UpdateManagerVM>
    {
        public PhoneNumberExtension()
        {
            RuleFor(x => x.PhoneNumber)
                 .NotEmpty().WithMessage("Phone number is required")
                 .Matches(new Regex(@"\(?[0-9]{3}\)?-?[0-9]{3}-?[0-9]{2}-?[0-9]{2}")).WithMessage("Invalid phone number format");

        }
    }
}
