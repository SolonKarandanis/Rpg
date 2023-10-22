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
        public ActionResult<List<Character>> GetCharacters(){
            return Ok(this._characterService.GetAllCharracters());
        }

        [HttpGet("{id}")]
        public ActionResult<Character> GetCharacter(int id){
            return Ok(this._characterService.GetCharacterById(id));
        }

        [HttpPost]
        public ActionResult<List<Character>> AddCharacter(Character newCharacter){
            return Ok(this._characterService.AddCharacter(newCharacter));
        }
    }
}