using PetShop.Petshop.Models;
using PetShop.Petshop.Repositories.Interfaces;

namespace PetShop.Petshop.Repositories.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly List<Pet> _pets;
        public async Task<IEnumerable<Pet>> GetAllPetAsync()
        {
            return await Task.FromResult(_pets);
        }

        public async Task<Pet> GetPetByIDAsync(int petID)
        {
            return await Task.FromResult(_pets.FirstOrDefault(x => x.PetID == petID));
        }
        public async Task<Pet> AddPetAsync(Pet pet)
        {
            _pets.Add(pet);
            return pet;
        }

        public async Task DeletePetAsync(int petID)
        {
            var petToDelete = await GetPetByIDAsync(petID);
            if (petToDelete != null)
            {
                _pets.Remove(petToDelete);
                await Task.CompletedTask;
            }
            else
            {
                throw new ArgumentNullException($"Employee with this ID {petID} does not exist");
            }
        }


        public async Task<Pet> UpdatePetAsync(Pet pet)
        {
            if (pet == null)
            {
                throw new ArgumentNullException(nameof(pet));
            }
            else
            {
                var existingPet = await GetPetByIDAsync(pet.PetID);
                if (existingPet != null)
                {
                    existingPet.PetID = pet.PetID;
                    existingPet.Breed = pet.Breed;
                    existingPet.PetType = pet.PetType;
                    existingPet.Age = pet.Age;
                    return pet;
                }
                else
                {
                    throw new ArgumentException($"Pet with ID {pet.PetID} does not exist");
                }
            }
        }
    }
}
