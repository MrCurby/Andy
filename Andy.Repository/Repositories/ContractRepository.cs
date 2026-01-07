using Andy.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andy.Persistent.Repositories
{
    public class ContractRepository (AndyDbContext dbContext) : IContractRepository
    {
        private readonly AndyDbContext _dbContext = dbContext;
    }
}
