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
        private readonly ContractMapper _contractMapper = mapper;
    }
}
