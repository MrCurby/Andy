using Andy.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Andy.Core
{
    public class EssentialExpense
    {
        [Key]
        public int ExpenseId { get; set; }

        [Required]
        public string? Type { get; set; }
        public string? Name { get; set; }
        [Required]
        public double? Amount { get; set; }
        [Required]
        public string? Provider { get; set; }
        [Required]
        public DateTime? PaymentDate { get; set; }
        [Required]
        public PaymentCycle PaymentCycle { get; set; }
        public string? memo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
