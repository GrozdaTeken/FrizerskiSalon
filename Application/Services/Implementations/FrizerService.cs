using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Repositories;
using Application.DTOs.Create;
using Application.DTOs.Returnable;
using Application.Extensions;
using System;

namespace Application.Services.Implementations
{
    public class FrizerService : IFrizerService
    {
        private readonly IFrizerRepository _frizerRepository;

        public FrizerService(IFrizerRepository frizerRepository)
        {
            _frizerRepository = frizerRepository;
        }

        public async Task<FrizerReturnable> AddFrizerAsync(FrizerCreate frizerCreate)
        {

            Frizer frizer = frizerCreate.ConvertToEntity();

            try
            {
                await _frizerRepository.AddFrizerAsync(frizer);

                FrizerReturnable frizerReturnable = frizer.ConvertToReturnable();

                return frizerReturnable;

            }
            catch (Exception ex) 
            {
                throw new ApplicationException("Failed to add frizer.", ex);
            }

        }

        public async Task<bool> DeleteFrizerAsync(int id)
        {
            return await _frizerRepository.DeleteFrizerAsync(id);
        }

        public async Task<FrizerReturnable?> GetFrizerByIdAsync(int id)
        {
            var frizer = await _frizerRepository.GetFrizerByIdAsync(id);

            return frizer.ConvertToReturnable() ?? null;
        }

        public async Task<IEnumerable<FrizerReturnable>> GetAllFrizersAsync()
        {
            var frizers = await _frizerRepository.GetAllFrizersAsync();
            return frizers.Select(frizer => frizer.ConvertToReturnable());
        }

        public async Task<FrizerReturnable> UpdateFrizerAsync(int friId, FrizerCreate frizerCreate)
        {

            var existingFrizer = await _frizerRepository.GetFrizerByIdAsync(friId);

            if (existingFrizer == null)
            {
                throw new Exception("Frizer doesn't exist.");
            }

            existingFrizer.Ime = frizerCreate.Ime;
            existingFrizer.Prezime = frizerCreate.Prezime;
            existingFrizer.Telefon = frizerCreate.Telefon;

            await _frizerRepository.UpdateFrizerAsync(existingFrizer);

            return existingFrizer.ConvertToReturnable();
        }
    }
}
