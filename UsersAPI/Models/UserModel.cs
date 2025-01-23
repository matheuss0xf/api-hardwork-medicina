using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersAPI.Models;

[Table("users")]
public class UserModel
{
    [Key]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("email"), Required]
    public string Email { get; set; }

    [Column("createdAt")]
    public DateTime CreatedAt { get; set; }
}