using Andy.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andy.Core.Interfaces
{
    public interface IContractService
    {
        /// <summary>
        /// Asynchronously retrieves all available Contracts.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of <see
        /// cref="ContractDto"/> objects representing all Contracts. The collection will be empty if no
        /// Contracts are found.</returns>
        Task<IEnumerable<ContractDto>> GetAllContractsAsync();

        /// <summary>
        /// Asynchronously updates the details of an existing Contract.
        /// </summary>
        /// <param name="ContractDto">An object containing the updated Contract information. Cannot be null.</param>
        /// <returns>A task that represents the asynchronous update operation.</returns>
        Task UpdateContractAsync(ContractDto ContractDto);

        /// <summary>
        /// Asynchronously adds a new Contract using the specified Contract details.
        /// </summary>
        /// <param name="ContractDto">An object containing the details of the Contract to add. Cannot be null.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a ContractDto representing
        /// the newly created Contract.</returns>
        Task<ContractDto> AddContractAsync(ContractDto ContractDto);

        /// <summary>
        /// Asynchronously deletes the Contract identified by the specified Contract ID.
        /// </summary>
        /// <param name="ContractId">The unique identifier of the Contract to delete. Must correspond to an existing Contract.</param>
        /// <returns>A task that represents the asynchronous delete operation.</returns>
        Task DeleteContractAsync(int ContractId);
    }
}
