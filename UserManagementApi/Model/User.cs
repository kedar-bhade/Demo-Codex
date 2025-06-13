namespace UserManagementApi.Model;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    [Column("userid")]
    public int UserId { get; set; }

    [Required]
    [Column("username")]
    public string Username { get; set; } = string.Empty;

    [Required]
    [Column("course")]
    public string Course { get; set; } = string.Empty;

    [Required]
    [Column("purchasedate")]
    public string PurchaseDate { get; set; } = string.Empty;
}

