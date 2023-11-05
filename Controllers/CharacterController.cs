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
        public async Task<ActionResult<PageResponse<GetCharacterDto>>> FindAll(
            [FromQuery] int page,
            [FromQuery] int size,
            [FromQuery] string? sortField,
            [FromQuery] string? sortOrder
        ){
            Paging paging = new Paging(page,size,sortField,sortOrder);
            var results = await characterService.FindAll(paging);
            var charactersDto = results.Content
                .Select(character =>  characterService.ConvertToDto(character,false))
                .ToList();
            var result = new PageResponse<GetCharacterDto>(charactersDto,results.TotalNumber,results.PageCount);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetCharacterDto>> FindById(int id){
            try{
                var character = await characterService.FindById(id,true);
                var result = characterService.ConvertToDto(character,true);
                return Ok(result);
            }catch(Exception ex){
                return NotFound();
            }
            
        }

        [HttpGet("users/{id}")]
        public async Task<ActionResult<List<GetCharacterDto>>> FindByUserId(int userId){
            var characters = await characterService.FindByUserId(userId);
            var result = characters
                .Select(character=> characterService.ConvertToDto(character,true))
                .ToList();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<GetCharacterDto>> AddCharacter([FromBody] AddCharacterDto newCharacter){
            var createdChar = await characterService.CreateCharacter(newCharacter,1);
            var response = characterService.ConvertToDto(createdChar,false);
            return Ok(response);
        }


        [HttpPost("skill")]
        public async Task<ActionResult<GetCharacterDto>> AddSkill([FromBody] AddCharacterSkillDto newCharacterSkill){
            var character = await characterService.AddCharacterSkill(newCharacterSkill);
            var response = characterService.ConvertToDto(character,true);
            return Ok(response);
        }

         [HttpPut]
        public async Task<ActionResult<GetCharacterDto>> UpdateCharacter([FromBody] UpdateCharacterDto updatedCharacter)
        {
            var updatedChar = await characterService.UpdateCharacter(updatedCharacter);
            var result = characterService.ConvertToDto(updatedChar,false);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteCharacter(int id)
        {
            try{
                await characterService.DeleteCharacter(id);
                return Ok();
            }catch(Exception ex){
                return NotFound();
            }
            
        }
    }
}