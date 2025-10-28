using System.ComponentModel.DataAnnotations;

namespace Andy.ViewModels
{
    public class SubscriptionViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public double? Amount { get; set; }
        public bool? IsActive { get; set; } = true;
        public DateTime? NextPaymentDate { get; set; }
        public DateTime? LastUpdated { get; set; } = DateTime.UtcNow;
        public DateTime? CreatedOn { get; set; } = DateTime.UtcNow;
        public string? Memo { get; set; }
    }
}
