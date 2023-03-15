using Application.Interfaces;
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
    }
}