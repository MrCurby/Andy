using Andy.Core.DTOs;
using Andy.Core.Interfaces;
using Andy.Persistent.Mapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andy.Persistent.Repositories
{
    public class ContractRepository (AndyDbContext dbContext, ContractMapper mapper) : IContractRepository
    {
        private readonly AndyDbContext _dbContext = dbContext;
        private readonly ContractMapper _mapper = mapper;

        public async Task<IEnumerable<ContractDto>> GetAllContractsAsync()
        {
            var contracts = await _dbContext.Contracts.ToListAsync();
            return _mapper.MapToDtoList(contracts);
        }

        public async Task UpdateContractAsync(ContractDto ContractDto)
        {
            var entity = await _dbContext.Contracts.FindAsync(ContractDto.Id);
            if (entity is null)
            {
                return;
            }
            entity.LastUpdated = DateTime.UtcNow;

            var mapped = _mapper.MapToEntity(ContractDto) ?? throw new InvalidOperationException("Mapping returned null for the provided DTO.");
            _dbContext.Entry(entity).CurrentValues.SetValues(mapped);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<ContractDto> AddContractAsync(ContractDto ContractDto)
        {
            ArgumentNullException.ThrowIfNull(ContractDto);

            var entity = _mapper.MapToEntity(ContractDto) ?? throw new InvalidOperationException("Mapping returned null for the provided DTO.");

            if (entity.CreatedOn == null || entity.CreatedOn == default)
            {
                entity.CreatedOn = DateTime.UtcNow;
            }
            entity.LastUpdated = DateTime.UtcNow;

            await _dbContext.Contracts.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return _mapper.MapToDto(entity);
        }

        public async Task DeleteContractAsync(int ContractId)
        {
            var entity = await _dbContext.Contracts.FindAsync(ContractId);
            if (entity is null)
            {
                return;
            }
            _dbContext.Contracts.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
