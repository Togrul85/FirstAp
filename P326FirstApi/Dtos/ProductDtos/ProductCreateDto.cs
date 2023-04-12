using FluentValidation;

namespace P326FirstApi.Dtos.ProductDtos
{
    public class ProductCreateDto
    {


        public string Name { get; set; }

        public double SalePrice { get; set; }

        public double CostPrice { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateDtoValidator()
        {
            RuleFor(p => p.Name)
                .MaximumLength(50).WithMessage("50 den boyuk ola bilmez")
                .NotNull().WithMessage("Bosh Qoyma");

            RuleFor(p => p.SalePrice)
                .GreaterThanOrEqualTo(0).WithMessage("0 dan boyuk olmalidir ")
                .NotNull().WithMessage("bOSH qoymaq olmaz");


            RuleFor(p => p.CostPrice)
               .GreaterThanOrEqualTo(0).WithMessage("0 dan boyuk olmalidir ")
               .NotNull().WithMessage("bOSH qoymaq olmaz");


            RuleFor(p => p.IsActive)
               .Equal(true).WithMessage("true olmalidir. ")
               .NotNull().WithMessage("bOSH qoymaq olmaz");


            RuleFor(p => p)
                .Custom((p, context) =>
                {
                    if (p.SalePrice<p.CostPrice)
                    {
                        context.AddFailure("SalePrice", "salePrice costPricedan kicik ola bilmez");
                    }
                });

        }
    }
}
