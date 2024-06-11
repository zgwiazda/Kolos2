using System.ComponentModel.DataAnnotations;

namespace APBD_kolos.DTOs;

public class NewItemDTO
{
    [Required]
    public int Id { get; set; }
 
    [MaxLength(100)]
    public string? Name { get; set; } = null;
    public int Weight { get; set; }
    
}