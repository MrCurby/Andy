using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Andy.Core
{
    public class Contract
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Provider { get; set; }
        public string? ContractNumber { get; set; }
        public double? CostPerMonth { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string? Memo { get; set; }
    }
}
