using CryptoJournal.Core.DTO;
using CryptoJournal.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CryptoJournal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraderController : ControllerBase
    {
        readonly ITraderService traderService;

        public TraderController(ITraderService traderService)
        {
            this.traderService = traderService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(TraderRegisterDTO trader)
        {
            var createdTrader = await traderService.CreateTraderAsync(trader);

            return Ok(createdTrader);   
        }

        [HttpGet]
        [Route("GetTraders")]
        public async Task<IActionResult> GetTraders()
        {

            var traders = await traderService.GetAllTradersAsync();
            return Ok(traders);
        }

        [HttpGet]
        [Route("GetTraderById/{id:int}")]
        public async Task<IActionResult> GetTrader(int id)
        {
            var trader = await traderService.GetTraderByIdAsync(id);

            return Ok(trader);
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> DeleteTrader(int id)
        {
            var deleted = await traderService.DeleteTraderAsync(id);

            return Ok(new { Message = $"Trader with id {id} was deleted succesfully"});
        }

        [HttpPut]
        [Route("Update/{id:int}")]
        public async Task<IActionResult> UpdateTrader(int id, TraderUpdateDTO trader)
        {
            var updatedTrader = await traderService.UpdatePasswordAsync(id, trader);

            return Ok(updatedTrader);
        }

    }
}
