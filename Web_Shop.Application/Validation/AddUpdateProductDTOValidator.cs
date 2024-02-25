using FluentValidation;
using Web_Shop.Application.DTOs;

namespace Web_Shop.Application.Validation
{
    public class AddUpdateProductDTOValidator : AbstractValidator<AddUpdateProductDTO>
    {
        public AddUpdateProductDTOValidator()
        {
            // rules for add update sku
            // at least 8 char, letters, number and - like separator are allowed
            //RuleFor(request => request.Sku).MinimumLength(8).WithMessage("sku muis mieć co najmiej 8 znaków").
            //Matches("[A-Z]|[a-z]|[0-9]|[-]").WithMessage("sku moze byc złożone z małych lub dużych liter i cyfr oraz znaku - jako separatora").
            //Matches("^[^\"!@$%^&*(){}:;<>,.?/+_=|'~\\£# “”]").WithMessage("Oprócz - nie może być zadnych innych znakó specjalnych").
            //When(request => request.IsSkuUpdate);

        }

    }
}
