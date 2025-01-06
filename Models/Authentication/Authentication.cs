using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace store.Models;

[Table("authentications")]
public class Authentication
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [EmailAddress]
    [Unicode(true)]
    [Column("email", TypeName = "varchar(255)")]
    public required string Email { get; set; }

    [Required]
    [MinLength(6)]
    [StringLength(255)]
    [Column("password", TypeName = "varchar(255)")]
    public required string Password { get; set; }

    [Column("profileId")]
    [ForeignKey("profiles")]
    public Guid ProfileId { get; set; } 
    public Profile Profile { get; set; } = null!;

    [Column("createdAt")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Column("updatedAt")]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
}
