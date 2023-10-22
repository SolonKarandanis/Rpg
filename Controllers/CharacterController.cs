using Microsoft.AspNetCore.Mvc;


namespace rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {

        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            this._characterService = characterService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Character>>> GetCharacters(){
            return Ok(await _characterService.GetAllCharracters());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id){
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> AddCharacter(Character newCharacter){
            return Ok( await _characterService.AddCharacter(newCharacter));
        }
    }
}