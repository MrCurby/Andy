using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Andy.Core
{
    public class Subscription
    {
        [Key]
        public int SubscriptionId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public double? Amount { get; set; }
        [Required]
        public bool? IsActive { get; set;  }
        [Required]
        public DateTime? NextPaymentDate { get; set; }
        [Required]
        public DateTime? LastUpdated { get; set; }
        [Required]
        public DateTime? CreatedOn = DateTime.UtcNow;
        public string? memo { get; set; }
    }
}
