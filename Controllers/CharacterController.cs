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
        public async Task<ActionResult<ServiceResponse<List<CharacterDto>>>> GetCharacters(){
            return Ok(await _characterService.GetAllCharracters());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<CharacterDto>>> GetCharacter(int id){
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<CharacterDto>>>> AddCharacter(AddCharacterDto newCharacter){
            return Ok( await _characterService.AddCharacter(newCharacter));
        }

         [HttpPut]
        public async Task<ActionResult<ServiceResponse<CharacterDto>>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var response = await _characterService.UpdateCharacter(updatedCharacter);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<CharacterDto>>>> DeleteCharacter(int id)
        {
            var response = await _characterService.DeleteCharacter(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}