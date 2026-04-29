using System.ComponentModel.DataAnnotations;

namespace HX.MCPServer.Entity
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; } 

        public DateTimeOffset DateCreated { get; set; } 

        public DateTimeOffset? DateDeactivated { get; set; } 
    }
}
