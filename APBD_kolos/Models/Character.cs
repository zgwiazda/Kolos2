using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APBD_kolos.Models;

public class Character
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(120)]
    public string LasttName { get; set; } = string.Empty;
    
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }

    
    public ICollection<Backpack> Backpacks { get; set; } = new HashSet<Backpack>();
    public ICollection<Character_title> CharacterTitles { get; set; } = new HashSet<Character_title>();

}