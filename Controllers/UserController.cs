using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace rpg.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        // private UserManager<ApplicationUser> _userManager;

        private readonly IUsersService userService;

        public UserController(IUsersService userService)
        {
            this.userService=userService;
        }

        [HttpGet]
        public async Task<PageResponse<GetUserDto>> FindUsers(
            [FromQuery] int page,
            [FromQuery] int size,
            [FromQuery] string? sortField,
            [FromQuery] string? sortOrder
        ){
            Paging paging = new Paging(page,size,sortField,sortOrder);
            return null;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserDto>> FindUserById(int id){
            try{
                var user = await userService.FindById(id,false);
                Log.Debug("User found @{User}",user.Username);
                var result = userService.ConvertToDto(user);
                return Ok(result);
            }
            catch(Exception ex){
                return NotFound();
            }
        }

        [HttpGet("account")]
        public async Task<ActionResult<GetUserDto>> GetLoggedInUser(){
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var id = Convert.ToInt32(currentUserID);
            var user =await userService.FindById(id,false);
            var result = userService.ConvertToDto(user);
            return Ok(result);
        }
    }
}