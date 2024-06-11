using APBD_kolos.Models;

namespace APBD_kolos.DTOs;

public class GetCHaracterDTO
{
    public int Id { get; set; }
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }

    public ICollection<Backpack> Items { get; set; } = null!;

}

public class GetItemsFromBackpackDTO
{
    public int Id { get; set; }
    public String Name { get; set; }
    public int Weight { get; set; }
}