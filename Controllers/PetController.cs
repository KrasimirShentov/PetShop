using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetShop.Petshop.Models;
using PetShop.Petshop.Models.Petshop.Requests;
using PetShop.Petshop.Models.Petshop.Responses;
using PetShop.Petshop.services.Interfaces;
using PetShop.Petshop.services.Services;
using System.Diagnostics.Eventing.Reader;

namespace PetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;
        private readonly ILogger<PetController> _logger;
        public PetController(IPetService petService, ILogger<PetController> logger)
        {
            _petService = petService;
            _logger = logger;
        }

        [HttpGet("{ID}")]
        public async Task<IActionResult> GetPetByID(int petID)
        {
            try
            {
                var pet = await _petService.GetPetByIDAsync(petID);
                if (pet == null)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/pets")]

        public async Task<IActionResult> GetAllPets()
        {
            try
            {
                var pet = await _petService.GetAllPetsAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("/pet")]
        public async Task<IActionResult> AddPet(PetRequest petRequest)
        {
            try
            {
                await _petService.AddPetAsync(petRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("/pet")]

        public async Task<IActionResult> UpdatePet(int petID, Pet pet)
        {
            try
            {
                await _petService.UpdatePetAsync(pet);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("/pet")]

        public async Task<IActionResult> DeletePet(int petID)
        {
            try
            {

                await _petService.DeletePetAsync(petID);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
