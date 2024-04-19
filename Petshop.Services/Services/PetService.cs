using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShop.Petshop.services.Interfaces;
using PetShop.Petshop.Models;

namespace PetShop.Petshop.services.Services
{
    public class PetService : IPetService
    {
        private readonly IPetService _IpetService;

        public PetService(IPetService petService)
        {
            _IpetService = petService;
        }

        public async Task<Pet> AddPetAsync(Pet pet)
        {
            try
            {
                return await _IpetService.AddPetAsync(pet);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding pet: {ex.Message}");
                throw;
            }
        }

        public async Task DeletePetAsync(int petId)
        {
            try
            { 
                await _IpetService.DeletePetAsync(petId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting pet: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<Pet>> GetAllPetsAsync(string name)
        {
            try
            {
                return await _IpetService.GetAllPetsAsync(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting all pets: {ex.Message}");
                throw;
            }
        }

        public async Task<Pet> GetPetByIDAsync(int petId)
        {
            try
            {
                return await _IpetService.GetPetByIDAsync(petId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting pet by ID: {ex.Message}");
                throw;
            }
        }

        public async Task<Pet> UpdatePetAsync(Pet pet)
        {
            try
            {
                return await _IpetService.UpdatePetAsync(pet);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating pet: {ex.Message}");
                throw;
            }
        }
    }
}
