using CryptoJournal.Core.DTO;
using FluentValidation;

namespace CryptoJournal.Infrastructure.Validators
{
    public class TraderRegisterDTOValidator : AbstractValidator<TraderRegisterDTO>
    {
        public TraderRegisterDTOValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Имя обязательно");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Пароль обязателен")
                .MinimumLength(7).WithMessage("Минимальная длина 7");
                
        }
    }
}
