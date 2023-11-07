using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace rpg.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
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
    }
}