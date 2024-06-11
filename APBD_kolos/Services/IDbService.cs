using APBD_kolos.Models;

namespace APBD_kolos.Services;

public interface IDbService
{
    //koncowka1
    Task<bool> DoesCharacterExist(int characterId);
    Task<ICollection<Character>> GetCHaracterData(int characterId);
    Task<ICollection<Backpack>> WhatsInCharactersBackpack(int characterId);
    Task<ICollection<Title>> CharactersTitles(int characterId);

    Task AddNewItems(Item items);



}