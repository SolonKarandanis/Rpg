using Microsoft.AspNetCore.Mvc;


namespace rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {

        private readonly ICharacterService characterService;

        public CharacterController(ICharacterService characterService)
        {
            this.characterService = characterService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetCharacterDto>>> GetCharacters(){
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCharacterDto>> GetCharacter(int id){
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter){
            return Ok();
        }

         [HttpPut]
        public async Task<ActionResult<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            // var response = await _characterService.UpdateCharacter(updatedCharacter);
            // if (response.Data is null)
            // {
            //     return NotFound(response);
            // }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            // var response = await _characterService.DeleteCharacter(id);
            // if (response.Data is null)
            // {
            //     return NotFound(response);
            // }
            return Ok();
        }
    }
}