using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        #region DependencyInjection
        private readonly IHotelSerivce _hotelService;
        public HotelController(IHotelSerivce hotelService)
        {
            _hotelService = hotelService;
        }
        #endregion

        public async Task<IActionResult> GetAllHotels()
        {
            var allHotels = await this._hotelService.GetHotelListAsync();

            if (allHotels == null)
            {
                return NotFound();
            }

            return Ok(allHotels);
        }
    }
}
