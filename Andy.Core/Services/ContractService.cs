using Andy.Core.DTOs;
using Andy.Core.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andy.Core.Services
{
    public class ContractService(IContractRepository ContractRepository,
                                   ILogger<ContractService> logger) : IContractService
    {
        private readonly IContractRepository _ContractRepository = ContractRepository;
        private readonly ILogger<ContractService> _logger = logger;

        public async Task<IEnumerable<ContractDto>> GetAllContractsAsync()
        {
            _logger.LogInformation("Method {MethodName} has been called.", nameof(GetAllContractsAsync));

            try
            {
                var result = await _ContractRepository.GetAllContractsAsync();
                _logger.LogInformation("Method {MethodName} completed successfully.", nameof(GetAllContractsAsync));
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred in {MethodName}.", nameof(GetAllContractsAsync));
                throw;
            }
        }

        public async Task UpdateContractAsync(ContractDto ContractDto)
        {
            _logger.LogInformation("Method {MethodName} has been called.", nameof(UpdateContractAsync));

            try
            {
                await _ContractRepository.UpdateContractAsync(ContractDto);
                _logger.LogInformation("Method {MethodName} completed successfully.", nameof(UpdateContractAsync));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred in {MethodName}.", nameof(UpdateContractAsync));
                throw;
            }
        }

        public async Task<ContractDto> AddContractAsync(ContractDto ContractDto)
        {
            _logger.LogInformation("Method {MethodName} has been called.", nameof(AddContractAsync));

            ArgumentNullException.ThrowIfNull(ContractDto);

            try
            {
                var created = await _ContractRepository.AddContractAsync(ContractDto);
                _logger.LogInformation("Method {MethodName} completed successfully.", nameof(AddContractAsync));
                return created;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred in {MethodName}.", nameof(AddContractAsync));
                throw;
            }
        }

        public async Task DeleteContractAsync(int ContractId)
        {
            _logger.LogInformation("Method {MethodName} has been called.", nameof(DeleteContractAsync));
            try
            {
                await _ContractRepository.DeleteContractAsync(ContractId);
                _logger.LogInformation("Method {MethodName} completed successfully.", nameof(DeleteContractAsync));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred in {MethodName}.", nameof(DeleteContractAsync));
                throw;
            }
        }
    }
}
