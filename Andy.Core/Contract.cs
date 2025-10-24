using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Andy.Core
{
    public class Contract
    {
        [Key]
        public int ContractId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Provider { get; set; }
        public string? ContractNumber { get; set; }
        [Required]
        public double? CostPerMonth { get; set; }
        [Required]
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required]
        public string? Status { get; set; }
        [Required]
        public DateTime? CreatedOn { get; set; }
        [Required]
        public DateTime? LastUpdated { get; set; }
        public string? memo { get; set; }

    }
}
