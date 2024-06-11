﻿using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APBD_kolos.Models;

[Table("Character_Titles")]
[PrimaryKey(nameof(CharacterId), nameof(TitleId))]
public class Character_title
{
    
    public int CharacterId { get; set; }
    public int TitleId { get; set; }
   
   
    public DateTime AcquiredAt { get; set; }
    
    
    [ForeignKey(nameof(CharacterId))]
    public Character Character { get; set; } = null!;
  
    [ForeignKey(nameof(TitleId))]
    public Title Title { get; set; } = null!;

    
}