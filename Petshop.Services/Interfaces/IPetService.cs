using PetShop.Petshop.Models;
using PetShop.Petshop.Models.Petshop.Responses;

namespace PetShop.Petshop.services.Interfaces
{
    public interface IPetService
    {
        Task<Pet> GetPetByIDAsync(int PetID);
        Task<IEnumerable<Pet>> GetAllPetsAsync();
        Task<Pet> AddPetAsync(PetRequest petRequest);
        Task UpdatePetAsync(Pet pet);
        Task DeletePetAsync(int PetID);
    }
}
