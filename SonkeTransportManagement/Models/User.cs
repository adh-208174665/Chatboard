using System.ComponentModel.DataAnnotations.Schema;

namespace SonkeTransportManagement.Models
{
    [Table("User", Schema = "dbo")]
    public class User
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Position { get; set; }
        public string? Section { get; set; }
        public string? Contact { get; set; }
        public int? RoleId { get; set; }
        public string? UserPassword { get; set; }
        public string? CreateDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? Email { get; set; }
    }
    
}
