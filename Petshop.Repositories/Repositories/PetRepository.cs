using PetShop.Petshop.Models;
using PetShop.Petshop.Repositories.Interfaces;

namespace PetShop.Petshop.Repositories.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly List<Pet> _pets;
        private int _petID = 0;
        public async Task<IEnumerable<Pet>> GetAllPetAsync()
        {
            return await Task.FromResult(_pets);
        }

        public async Task<Pet> GetPetByIDAsync(int petID)
        {
            return await Task.FromResult(_pets.FirstOrDefault(x => x.PetID == petID));
        }
        public async Task AddPetAsync(Pet pet)
        {
            if (pet == null)
            {
                throw new ArgumentNullException(nameof(pet));
            }
            else
            {
                pet.PetID = _petID++;
                _pets.Add(pet);
                await Task.CompletedTask;
            }
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


        public async Task UpdatePetAsync(Pet pet)
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
                    await Task.CompletedTask;
                }
                else
                {
                    throw new ArgumentException($"Pet with ID {pet.PetID} does not exist");
                }
            }
        }
    }
}
