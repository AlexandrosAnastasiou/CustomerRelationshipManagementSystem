using CustomerRelationshipManagementSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CustomerRelationshipManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomerInfo> Tbl_CustomerInfo { get; set; }
        public virtual DbSet<CustomerCalls> Tbl_CustomerCalls { get; set; }
    }
}