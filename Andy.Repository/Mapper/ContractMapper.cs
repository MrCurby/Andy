using Andy.Core;
using Andy.Core.DTOs;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andy.Persistent.Mapper
{
    [Mapper]
    public partial class ContractMapper
    {
        /// <summary>
        /// Converts a Contract domain model instance to its corresponding ContractDto data transfer object.
        /// </summary>
        /// <param name="Contract">The Contract instance to convert. Cannot be null.</param>
        /// <returns>A ContractDto object that represents the data from the specified Contract instance.</returns>
        public partial ContractDto MapToDto(Contract Contract);

        /// <summary>
        /// Maps a collection of Contract domain entities to their corresponding ContractDto data transfer
        /// objects.
        /// </summary>
        /// <param name="Contracts">The collection of Contract entities to be mapped. Cannot be null.</param>
        /// <returns>An enumerable collection of ContractDto objects representing the mapped data from the input
        /// Contracts. The collection will be empty if the input contains no elements.</returns>
        public partial IEnumerable<ContractDto> MapToDtoList(IEnumerable<Contract> Contracts);

        /// <summary>
        /// Converts a ContractDto object to its corresponding Contract entity.
        /// </summary>
        /// <param name="ContractDto">The data transfer object containing Contract information to be mapped. Cannot be null.</param>
        /// <returns>A Contract entity populated with values from the specified ContractDto.</returns>
        public partial Contract MapToEntity(ContractDto ContractDto);

        /// <summary>
        /// Maps a collection of Contract data transfer objects to a collection of Contract entities.
        /// </summary>
        /// <param name="ContractsDtos">The collection of Contract data transfer objects to convert. Cannot be null.</param>
        /// <returns>An enumerable collection of Contract entities mapped from the provided data transfer objects.</returns>
        public partial IEnumerable<Contract> MapToEntityList(IEnumerable<ContractDto> ContractsDtos);
    }
}
