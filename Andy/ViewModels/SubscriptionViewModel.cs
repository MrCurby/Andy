using System.ComponentModel.DataAnnotations;

namespace Andy.ViewModels
{
    public class SubscriptionViewModel
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
