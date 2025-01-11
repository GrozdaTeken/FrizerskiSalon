﻿using Application.DTOs.Create;
using Application.DTOs.Extensions;
using Application.DTOs.Returnables;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services.Implementations
{
    public class SmenaService : ISmenaService
    {
        private readonly ISmenaRepository _smenaRepository;

        public SmenaService(ISmenaRepository smenaRepository)
        {
            _smenaRepository = smenaRepository;
        }

        public async Task<SmenaReturnable> AddSmenaAsync(SmenaCreate smenaCreate)
        {
            var smena = smenaCreate.ConvertToEntity();
            await _smenaRepository.AddAsync(smena);
            return smena.ConvertToReturnable();
        }

        public async Task<bool> DeleteSmenaAsync(Guid id)
        {
            return await _smenaRepository.DeleteAsync(id);
        }

        public async Task<SmenaReturnable?> GetSmenaByIdAsync(Guid id)
        {
            var smena = await _smenaRepository.GetByIdAsync(id);
            return smena?.ConvertToReturnable();
        }

        public async Task<IEnumerable<SmenaReturnable>> GetAllSmeneAsync()
        {
            var smene = await _smenaRepository.GetAllAsync();
            return smene.Select(s => s.ConvertToReturnable());
        }

        public async Task<SmenaReturnable> UpdateSmenaAsync(Guid id, SmenaCreate smenaCreate)
        {
            var existingSmena = await _smenaRepository.GetByIdAsync(id);
            if (existingSmena == null)
            {
                throw new Exception("Smena not found.");
            }

            existingSmena.FriId = smenaCreate.FriId;
            existingSmena.Pocetak = smenaCreate.Pocetak;
            existingSmena.Kraj = smenaCreate.Kraj;

            await _smenaRepository.UpdateAsync(existingSmena);

            return existingSmena.ConvertToReturnable();
        }

        public async Task<IEnumerable<SmenaReturnable>> GetSmeneByFriIdAsync(Guid friId)
        {
            var smene = await _smenaRepository.GetByFriIdAsync(friId);
            return smene.Select(s => s.ConvertToReturnable());
        }

        public async Task SetShiftAsync(Guid friId, DateTime dateFrom, DateTime dateTo, TimeSpan shiftFrom, TimeSpan shiftTo)
        {
            if (dateFrom > dateTo)
            {
                throw new ArgumentException("DateFrom cannot be later than DateTo.");
            }

            if (shiftFrom >= shiftTo)
            {
                throw new ArgumentException("ShiftFrom must be earlier than ShiftTo.");
            }

            var shifts = new List<Smena>();

            for (var date = dateFrom.Date; date <= dateTo.Date; date = date.AddDays(1))
            {
                shifts.Add(new Smena
                {
                    Id = Guid.NewGuid(),
                    FriId = friId,
                    Pocetak = date.Add(shiftFrom),
                    Kraj = date.Add(shiftTo)
                });
            }

            await _smenaRepository.SetShiftsAsync(shifts);
        }
    }
}
