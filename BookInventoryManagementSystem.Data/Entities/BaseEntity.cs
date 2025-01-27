using System.ComponentModel.DataAnnotations.Schema;

namespace BookInventoryManagementSystem.Data.Entities;

public abstract class BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
}
