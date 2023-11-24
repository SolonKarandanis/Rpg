using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ILogger<UserController> log;

        public UserController(IUsersService userService,ILogger<UserController> log)
        {
            this.userService=userService;
            this.log = log;
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
                log.LogDebug("User found @{User}",user.Username);
                var result = userService.ConvertToDto(user);
                return Ok(result);
            }
            catch(Exception ex){
                return NotFound();
            }
        }

        // [ResponseCache(Duration = 60)]
        [Authorize]
        [HttpGet("account")]
        public async Task<ActionResult<GetUserDto>> GetLoggedInUser(){
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var currentUsername = currentUser.FindFirst(ClaimTypes.Name).Value;
            log.LogDebug("User found  @{currentUsername}",currentUsername);
            var id = Convert.ToInt32(currentUserID);
            var user =await userService.FindById(id,false);
            var result = userService.ConvertToDto(user);
            return Ok(result);
        }
    }
}