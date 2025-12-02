using AutoMapper;
using CryptoJournal.Core.DTO;
using CryptoJournal.Core.Interfaces.Repositories;
using CryptoJournal.Core.Interfaces.Services;
using CryptoJournal.Core.Models;
using FluentValidation;

namespace CryptoJournal.Infrastructure.Services
{
    public class TraderService : ITraderService
    {
        readonly ITraderRepository _repository;
        readonly IMapper _mapper;
        readonly IPasswordHasher _passwordHasher;
        readonly IValidator<TraderRegisterDTO> registerDTOValidator;
        readonly IValidator<TraderUpdateDTO> updateDTOValidator;

        public TraderService(
            ITraderRepository repository, 
            IMapper mapper, 
            IPasswordHasher passwordHasher, 
            IValidator<TraderRegisterDTO> registerDTOValidator,
            IValidator<TraderUpdateDTO> updateDTOValidator) 
        {
            _repository = repository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            this.registerDTOValidator = registerDTOValidator;
            this.updateDTOValidator = updateDTOValidator;
        }
        public async Task<Trader> CreateTraderAsync(TraderRegisterDTO traderRegisterDTO)
        {
            if (traderRegisterDTO == null)
                throw new ArgumentNullException();

            if (!registerDTOValidator.Validate(traderRegisterDTO).IsValid)
                throw new FormatException();

            if(_repository.ExistsAsync(traderRegisterDTO.Username!).Result)
                throw new Exception();


            var hashedPassword = _passwordHasher.Hash(traderRegisterDTO.Password!);

            traderRegisterDTO.Password = hashedPassword;

            var trader = _mapper.Map<Trader>(traderRegisterDTO); 

            return await _repository.AddAsync(trader);
        }

        public async Task<bool> DeleteTraderAsync(int id)
        {
            if (id <= 0)
                throw new FormatException();

            if(!_repository.ExistsAsync(id).Result)
                throw new FormatException();

            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Trader>> GetAllTradersAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Trader> GetTraderByIdAsync(int id)
        {
            if (id <= 0)
                throw new FormatException();

            if (!_repository.ExistsAsync(id).Result)
                throw new FormatException();

            return await _repository.GetByIdAsync(id);
        }

        public async Task<Trader> UpdatePasswordAsync(int id, TraderUpdateDTO traderUpdateDTO)
        {
            if (id <= 0)
                throw new FormatException();

            if(traderUpdateDTO == null)
                throw new FormatException();

            if (!_repository.ExistsAsync(id).Result)
                throw new FormatException();

            if(!updateDTOValidator.Validate(traderUpdateDTO).IsValid)
                throw new FormatException();

            var trader = await _repository.GetByIdAsync(id);

            if (traderUpdateDTO.Password != null && !_passwordHasher.Verify(traderUpdateDTO.Password, trader.HashPassword))
            {
                traderUpdateDTO.Password = _passwordHasher.Hash(traderUpdateDTO.Password);
                var updatedTrader = _mapper.Map(traderUpdateDTO, trader);
                return await _repository.UpdateAsync(id, updatedTrader);
            }

            return trader;     
        }
    }
}
