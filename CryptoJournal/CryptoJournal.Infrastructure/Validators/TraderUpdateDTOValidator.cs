using CryptoJournal.Core.DTO;
using FluentValidation;

namespace CryptoJournal.Infrastructure.Validators
{
    public class TraderUpdateDTOValidator : AbstractValidator<TraderUpdateDTO>
    {
        public TraderUpdateDTOValidator()
        {
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Пароль обязателен")
                .MinimumLength(7).WithMessage("Минимальная длина 7")
                .When(x => x.Password != null);            
        }
    }
}
