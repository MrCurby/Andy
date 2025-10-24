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
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? Name { get; set; }
        public double? Amount { get; set; }
        public string? Provider { get; set; }
        public DateTime? PaymentDate { get; set; }
        public PaymentCycle PaymentCycle { get; set; }
        public string? Memo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
