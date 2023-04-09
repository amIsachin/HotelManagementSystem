using Application.Interfaces;
using Domain.SystemEntities;
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

        /// <summary>
        /// Get all hotels.
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<IActionResult> GetAllHotels()
        {
            var allHotels = await this._hotelService.GetHotelListAsync();

            if (allHotels == null)
            {
                return NotFound();
            }

            return Ok(allHotels);
        }

        /// <summary>
        /// Add new hotel functionality.
        /// </summary>
        /// <param name="hotelEntity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddNewHotel([FromBody] HotelEntity hotelEntity)
        {
            bool isAdded = await _hotelService.AddNewHotelAsync(hotelEntity);

            if (isAdded is true)
            {
                return Ok(true);
            }

            return BadRequest();

        }

        /// <summary>
        /// Delete hotel functionalityss
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        [HttpDelete("{hotelId}")]
        public async Task<IActionResult> DeleteHotel([FromRoute] int hotelId)
        {
            bool isDeleted = await _hotelService.DeleteHotelAsync(hotelId);

            if (isDeleted is true)
            {
                return Ok(true);
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);

        }


        /// <summary>
        /// Update hotel functionality.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hotelEntity"></param>
        /// <returns></returns>
        [HttpPut("{hotelId}")]
        public async Task<IActionResult> UpdateHotel([FromRoute] int hotelId, [FromBody] HotelEntity hotelEntity)
        {
            bool isUpdated = await _hotelService.UpdateHotelAsync(hotelId, hotelEntity);

            if (isUpdated is true)
            {
                return Ok(true);
            }

            return BadRequest();
        }
    }
}