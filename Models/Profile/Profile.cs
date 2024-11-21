using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using store.Enum;
using System.ComponentModel;

namespace store.Models;

[Table("profiles")]
public class Profile
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [StringLength(255)]
    [Column("name", TypeName = "varchar(255)")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(255)]
    [Column("lastName", TypeName = "varchar(255)")]
    public string LastName { get; set; } = string.Empty;


    [StringLength(255)]
    [DefaultValue("none")]
    [Column("profilePicture", TypeName = "varchar(255)")]
    public string ProfilePicture { get; set; } = "none";

    [Required]
    [Column("rol", TypeName = "nvarchar(255)")]
    public Role Rol { get; set; } = Role.Employee;

    [DefaultValue(true)]
    public bool Status { get; set; } = true;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
}
