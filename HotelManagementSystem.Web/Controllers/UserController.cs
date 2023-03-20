using Application.Interfaces;
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
        public UserController(IUserService userService)
        {
            _userService = userService;
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
        public async Task<IActionResult> NewUser(UserEntity userEntity)
        {
            bool isInserted = await _userService.NewUserAsync(userEntity);

            if (isInserted is true)
            {
                return Ok(true);
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}