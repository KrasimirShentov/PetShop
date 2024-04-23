using PetShop.Petshop.Models;

namespace PetShop.Petshop.services.Interfaces
{
    public interface IPetService
    {
        Task<Pet> GetPetByIDAsync(int PetID);
        Task<IEnumerable<Pet>> GetAllPetsAsync();
        Task<Pet> AddPetAsync(Pet pet);
        Task<Pet> UpdatePetAsync(Pet pet);
        Task DeletePetAsync(int PetID);
    }
}
