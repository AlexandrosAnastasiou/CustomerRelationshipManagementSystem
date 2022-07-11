using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRelationshipManagementSystem.Models
{
    public class CustomerCalls
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CallId { get; set; }
        [Required]
        public DateTime DateTimeOfCall { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Description { get; set; }
        
        public int CustomerRefId { get; set; }
        [ForeignKey("CustomerRefId")]
        [ValidateNever]
        public virtual CustomerInfo CustomerInfo { get; set; }
    }
}
