using PetShop.Petshop.Models;
using PetShop.Petshop.Models.Petshop.Requests;
using PetShop.Petshop.Models.Petshop.Responses;
using PetShop.Petshop.Repositories.Interfaces;
using PetShop.Petshop.services.Interfaces;
using System.Net;

namespace PetShop.Petshop.services.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly PetshopDB _dbContext;

        public PetService(IPetRepository petRepository, PetshopDB dbContext)
        {
            _petRepository = petRepository;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Pet>> GetAllPetsAsync()
        {
            return await _petRepository.GetAllPetAsync();
        }

        public async Task<Pet> GetPetByIDAsync(int petId)
        {
            var result = await _petRepository.GetPetByIDAsync(petId);

            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            return await _petRepository.GetPetByIDAsync(petId);
        }
        public async Task<Pet> AddPetAsync(PetRequest petRequest)
        {
            var pet = await _petRepository.GetPetByIDAsync(petRequest.PetID);

            if (pet != null)
            {
                throw new InvalidOperationException($"Pet with ID: {pet.PetID} already exists!");
            }


            if (petRequest.PetID <= 0)
            {
                throw new ArgumentException("Pet ID must be greater than 0");
            }

            var newPet = MapRequestToPet(petRequest);
            _dbContext.pets.Add(newPet);
            await _dbContext.SaveChangesAsync();


            return newPet;
        }


        public async Task DeletePetAsync(int petID)
        {
            var petToDelete = await GetPetByIDAsync(petID);
            if (petToDelete != null)
            {
                _dbContext.pets.Remove(petToDelete);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException($"Employee with this ID {petID} does not exist");
            }
        }


        public async Task UpdatePetAsync(Pet pet)
        {
            var result = await _petRepository.GetPetByIDAsync(pet.PetID);

            if (result == null)
            {
                throw new ArgumentNullException($"Pet with ID: {pet.PetID} does not exist");
            }

            result.PetID = pet.PetID;
            result.Name = pet.Name;
            result.Age = pet.Age;   
            result.Breed = pet.Breed;
            result.PetType = pet.PetType;

            await _petRepository.UpdatePetAsync(result);
        }
        private Pet MapRequestToPet(PetRequest petRequest)
        {
            return new Pet
            {
                PetID = petRequest.PetID,
                Breed = petRequest.Breed,
                Name = petRequest.Name,
                Age = petRequest.Age,
                PetType = petRequest.PetType
            };
        }

    }
}
