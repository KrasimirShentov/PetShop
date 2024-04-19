using PetShop.Petshop.Models;

namespace PetShop.Petshop.services.Interfaces
{
    public interface IPetService
    {
        Task<Pet> GetPetByIDAsync(int PetID);
        Task<IEnumerable<Pet>> GetAllPetsAsync(string Name);
        Task<Pet> AddPetAsync(Pet pet);
        Task<Pet> UpdatePetAsync(Pet pet);
        Task DeletePetAsync(int PetID);
    }
}
