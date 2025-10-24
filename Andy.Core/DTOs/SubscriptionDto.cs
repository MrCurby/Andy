using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Andy.Core.DTOs
{
    public class SubscriptionDto
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public double? Amount { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? NextPaymentDate { get; set; }
        public DateTime? LastUpdated { get; set; }
        public DateTime? CreatedOn { get; set; } = DateTime.UtcNow;
        public string? Memo { get; set; }
    }
}
