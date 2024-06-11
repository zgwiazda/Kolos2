using APBD_kolos.Data;
using APBD_kolos.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_kolos.Services;

public class DbService :IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<bool> DoesCharacterExist(int characterId)
    {
        return await _context.Characters.AnyAsync(e => e.Id == characterId);
    }

    public async Task<ICollection<Character>> GetCHaracterData(int characterId)
    {
        return await _context.Characters
            .Include(e => e.Id)
            .Include(e => e.FirstName)
            .Include(e => e.LasttName)
            .Include(e => e.CurrentWeight)
            .Include(e => e.MaxWeight)
            .Where(e => e.Id == characterId)
            .ToListAsync();
    }


    public async Task<ICollection<Backpack>> WhatsInCharactersBackpack(int characterId)
    {
        
      //  return await _context
        //    .Backpacks
          //  .ToListAsync(b => b.CharacterId == characterId)
            //;
            return  await _context.Backpacks
                .Include(e => e.ItemId)
                .Where(e => e.CharacterId == characterId)
                .ToListAsync()
                ;
            
    }

    public Task<ICollection<Title>> CharactersTitles(int characterId)
    {
        throw new NotImplementedException();
    }

 

    public async Task AddNewItems(Item items)
    {
        await _context.AddRangeAsync(items);
        await _context.SaveChangesAsync();
    }

}