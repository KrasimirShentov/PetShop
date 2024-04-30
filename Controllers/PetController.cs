using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetShop.Petshop.Models;
using PetShop.Petshop.Models.Petshop.Requests;
using PetShop.Petshop.Models.Petshop.Responses;
using PetShop.Petshop.services.Interfaces;
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
                var petByID = await _petService.GetPetByIDAsync(petID);
                if (petByID == null)
                {
                    _logger.LogError($"Pet with ID: {petID} does not exist!");
                    return NotFound();
                }
                else
                {
                    return Ok(new PetResponse { Pet = petByID });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving pet with ID: {petID}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("/pets")]

        public async Task<IActionResult> GetAllPets()
        {
            try
            {
                var pets = await _petService.GetAllPetsAsync();
                var petResponse = new List<PetResponse>();
                foreach (var pet in pets)
                {
                    petResponse.Add(new PetResponse { Pet = pet });
                }
                return Ok(petResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all pets!");
                return StatusCode(500, $"Internal server error: {ex.Message}!");
            }
        }

        [HttpPost("/pet")]
        public async Task<IActionResult> AddPet(PetRequest petRequest)
        {
            try
            {
                var pet = new Pet
                {
                    PetID = petRequest.PetID,
                    Breed = petRequest.Breed,
                    Name = petRequest.Name,
                    Age = petRequest.Age,
                    PetType = petRequest.PetType,
                };

                var createPet = await _petService.AddPetAsync(pet);
                var response = new PetResponse { Pet = createPet };
                return Created("", createPet);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating pet!");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("/pet")]

        public async Task<IActionResult> UpdatePet(int petID, PetRequest petRequest)
        {
            try
            {
                var petToUpdate = await _petService.GetPetByIDAsync(petID);

                if (petToUpdate == null)
                {
                    _logger.LogInformation($"Pet with ID: {petID} does not exist");
                    return StatusCode(500, "Internal server error");
                }
                else
                {
                    petToUpdate = new Pet
                    {
                        PetID = petRequest.PetID,
                        Breed = petRequest.Breed,
                        Name = petRequest.Name,
                        Age = petRequest.Age,
                        PetType = petRequest.PetType
                    };
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating pet with ID {petID}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("/pet")]

        public async Task<IActionResult> DeletePet(int petID)
        {
            var pet = await _petService.GetPetByIDAsync(petID);

            if (pet == null)
            {
                _logger.LogInformation($"Pet with ID {petID} not found");
                return NotFound($"Pet with ID {petID} not found");
            }
            else
            {
                await _petService.DeletePetAsync(petID);
            }

            return NoContent();
        }
    }
}
