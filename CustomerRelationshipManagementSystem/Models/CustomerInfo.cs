using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRelationshipManagementSystem.Models
{
    public class CustomerInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerSurname { get; set; }
        [Required]
        public string CustomerAddress { get; set; }
        [Required]
        public string CustomerCountry { get; set; }
        [Required]
        public DateTime CustomerDoB { get; set; }
        public ICollection<CustomerCalls> Calls { get; set; } = new List<CustomerCalls>();
    }
}
