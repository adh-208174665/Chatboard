using System.ComponentModel.DataAnnotations.Schema;

namespace SonkeTransportManagement.Models
{
    [Table("RequesterRequest", Schema = "dbo")]
    public class RequesterRequest
    {       
            public int Id { get; set; }
            public int UserId { get; set; }
            public string? RequestType { get; set; }
            public string? RequesterComments { get; set; }
            public string? Position { get; set; }
            public string? Section { get; set; }
            public string? firstname { get; set; }
            public string? lastname { get; set; }
            public string? Reason { get; set; }
            public string? Email { get; set; }        
            public string? EstimatedKilos { get; set; }
            public string? Contact { get; set; }
            public string? NumTravellers { get; set; }        
            public string? ReturnDate { get; set; }
            public string? DepatureDate { get; set; }
            public string? CreateDate { get; set; }
            public string? CreatedBy { get; set; }
            public string? Status { get; set; }
            public string? Destination { get; set; }        
            public string? ApproverComments { get; set; }
    }
}
