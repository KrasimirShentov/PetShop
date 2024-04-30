using PetShop.Petshop.Models;
using PetShop.Petshop.Models.Petshop.Requests;
using PetShop.Petshop.Models.Petshop.Responses;

namespace PetShop.Petshop.services.Interfaces
{
    public interface IPetService
    {
        Task<Pet> GetPetByIDAsync(int PetID);
        Task<IEnumerable<Pet>> GetAllPetsAsync();
        Task<PetResponse> AddPetAsync(PetRequest petRequest);
        Task<Pet> UpdatePetAsync(Pet pet);
        Task DeletePetAsync(int PetID);
    }
}
