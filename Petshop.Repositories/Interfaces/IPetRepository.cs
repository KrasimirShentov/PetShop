using PetShop.Petshop.Models;

namespace PetShop.Petshop.Repositories.Interfaces
{
    public interface IPetRepository
    {
        Task<Pet> GetPetByIDAsync(int petID);
        Task<IEnumerable<Pet>> GetAllPetAsync();
        Task AddPetAsync(Pet pet);
        Task UpdatePetAsync(Pet pet);
        Task DeletePetAsync(int id);
    }
}
