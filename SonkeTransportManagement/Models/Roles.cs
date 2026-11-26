using System.ComponentModel.DataAnnotations.Schema;

namespace SonkeTransportManagement.Models
{

    [Table("Roles", Schema = "dbo")]
    public class Roles
    {      
            public int Id { get; set; }           
            public string? Descpription { get; set; }
            public string? CreateDate { get; set; }
            public string? CreatedBy { get; set; }
          
        
    }
}
