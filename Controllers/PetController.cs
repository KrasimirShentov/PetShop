using Microsoft.AspNetCore.Mvc;
using PetShop.Petshop.Models;
using PetShop.Petshop.Models.Petshop.Responses;
using PetShop.Petshop.services.Interfaces;

namespace PetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {

        [HttpGet("{petID}")]
        public async Task<IActionResult> GetPetByID([FromRoute]int petID, [FromServices] IPetService petService)
        {
            try
            {
                var pet = await petService.GetPetByIDAsync(petID);
                if (pet == null)
                {
                    return NotFound();
                }
                return Ok(pet);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]

        public async Task<IActionResult> GetAllPets([FromServices] IPetService petService)
        {
            try
            {
                var pets = await petService.GetAllPetsAsync();
                return Ok(pets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPet(PetRequest petRequest, [FromServices] IPetService petService)
        {
            try
            {
                var pet = await petService.AddPetAsync(petRequest);
                return Ok(pet);
            }
            catch (ArgumentException ex)
            {
                return Forbid(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }   
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]

        public async Task<IActionResult> UpdatePet(int petID, Pet pet, [FromServices] IPetService petService)
        {
            try
            {
                await petService.UpdatePetAsync(pet);
                return Ok(pet);
            }
            catch (Exception ex)
            {
                return Forbid(ex.Message);
            }
        }

        [HttpDelete]

        public async Task<IActionResult> DeletePet(int petID, [FromServices] IPetService petService)
        {
            try
            {

                await petService.DeletePetAsync(petID);
                return Ok();
            }
            catch (Exception ex)
            {
                return Forbid(ex.Message);
            }
        }
    }
}
