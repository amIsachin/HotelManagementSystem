using Application.Interfaces;
using Domain.Common.ViewModels;
using Domain.SystemEntities;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region DependencyInjection
        private readonly IUserService _userService;
        private readonly IHotelSerivce _hotelService;
        public UserController(IUserService userService, IHotelSerivce hotelService)
        {
            _userService = userService;
            _hotelService = hotelService;
        }
        #endregion

        /// <summary>
        /// This method returns all user which available in the database.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var allUsers = await _userService.GetAllUsersAsync();

            if (allUsers == null)
            {
                return NotFound();
            }

            return Ok(allUsers);
        }

        /// <summary>
        /// This method create new user.
        /// </summary>
        /// <param name="userEntity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> NewUser([FromBody] UserViewModel userViewModel)
        {
            var hotelRecord = await _hotelService.GetHotelByHotelIdAsync(userViewModel.HotelId);

            if (hotelRecord == null)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            UserEntity userEntity = new UserEntity()
            {
                UserId = userViewModel.UserId,
                Name = userViewModel.Name,
                Gender = userViewModel.Gender,
                Age = userViewModel.Age,
                PhoneNumber = userViewModel.PhoneNumber,
                City = userViewModel.City,
                FromDate = userViewModel.FromDate,
                HotelEntity = hotelRecord,
                Created = userViewModel.Created,
            };

            bool isInserted = await _userService.NewUserAsync(userEntity);

            if (isInserted is true)
            {
                return Ok(true);
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }


        /// <summary>
        /// Get user by id with hotel.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserByUserIdWithHotel([FromRoute] int userId)
        {
            var userRecord = await _userService.GetUserByUserIdWithHotel(userId);

            if (userRecord != null)
            {
                return Ok(userRecord);
            }

            return NotFound();
        }

        /// <summary>
        /// Upate user funtionality.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userViewModel"></param>
        /// <returns></returns>
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int userId, [FromBody] UserViewModel userViewModel)
        {
            if (await _userService.IsExistUser(userId))
            {
                var hotelRecord = await _hotelService.GetHotelByHotelIdAsync(userViewModel.HotelId);

                if (hotelRecord != null)
                {
                    if (await _userService.UpdateUserAsync(userId, userViewModel, hotelRecord))
                    {
                        return Ok(true);
                    }
                }
            }

            return NotFound();
        }
    }
}