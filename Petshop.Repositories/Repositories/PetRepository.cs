﻿using Microsoft.EntityFrameworkCore;
using PetShop.Petshop.Models;
using PetShop.Petshop.Repositories.Interfaces;

namespace PetShop.Petshop.Repositories.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly PetshopDB _dbContext;
        public PetRepository(PetshopDB dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Pet>> GetAllPetAsync()
        {
            return await _dbContext.pets.ToListAsync();
        }

        public async Task<Pet> GetPetByIDAsync(int petID)
        {
            return await _dbContext.pets.FindAsync(petID);
        }
        public async Task<Pet> AddPetAsync(Pet pet)
        {
            _dbContext.pets.Add(pet);
            _dbContext.SaveChangesAsync();
            return pet;
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
            _dbContext.Entry(pet).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
