using System.ComponentModel.DataAnnotations;

namespace CustomerRelationshipManagementSystem.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
