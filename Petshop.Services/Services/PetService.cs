using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShop.Petshop.services.Interfaces;
using PetShop.Petshop.Models;
using PetShop.Petshop.Repositories.Interfaces;
using System.Diagnostics.CodeAnalysis;
using PetShop.Petshop.Models.Petshop.Responses;
using PetShop.Petshop.Models.Petshop.Requests;
using System.Net;

namespace PetShop.Petshop.services.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
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
        public async Task<PetResponse> AddPetAsync(PetRequest petRequest)
        {
            var pet = await _petRepository.GetPetByIDAsync(petRequest.PetID);

            if (pet != null)
            {
                return new PetResponse
                {
                    Pet = pet,
                    HttpStatusCode = HttpStatusCode.BadRequest,
                    Message = "Pet alreadt exists"
                };
            }

            if (pet.PetID <= 0)
            {
                return new PetResponse
                {
                    HttpStatusCode = HttpStatusCode.BadRequest,
                    Message = "Pet ID must be greater than 0"
                };
            }

            var newPet = new Pet
            {
                PetID = pet.PetID,
                Name = pet.Name,
                Age = pet.Age,
                Breed = pet.Breed,
                PetType = pet.PetType,
            };

            var result = await _petRepository.AddPetAsync(newPet);

            return new PetResponse
            {
                Pet = result,
                HttpStatusCode = HttpStatusCode.OK,
                Message = "Successfully added ne pet"
            };
        }

        public async Task DeletePetAsync(int petId)
        {
            await _petRepository.DeletePetAsync(petId);
        }


        public async Task<Pet> UpdatePetAsync(Pet pet)
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

            return await _petRepository.UpdatePetAsync(pet);
        }
    }
}
