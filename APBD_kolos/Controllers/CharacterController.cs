using System.Transactions;
using APBD_kolos.DTOs;
using APBD_kolos.Models;
using APBD_kolos.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_kolos.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CharacterController : ControllerBase
{
    //aprojektuj końcówkę, która będzie zwracać informacje o postaci o danym id. 
    
        //Końcówka powinna reagować na zapytanie pod adres

    //adres
    //api/characters/{characterId}
    //np.HTTP GET http://localhost:5000/api/characters/1//
    private readonly IDbService _dbService;
    public CharacterController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetOrdersData(int id)
    {
        var orders = await _dbService.GetCHaracterData(id);
        
        return Ok(orders.Select(async e => new GetCHaracterDTO()
        {
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LasttName,
            CurrentWeight = e.CurrentWeight,
            MaxWeight = e.MaxWeight,
            Items = await _dbService.WhatsInCharactersBackpack(id),
            
        }));
    }

    [HttpPost("{characterId}/backpacks")]
    public async Task<IActionResult> AddNewItems(int CharId, NewItemDTO newItemDto)
    {
        if (!await _dbService.DoesCharacterExist(CharId))
            return NotFound($"Client with given ID - {CharId} doesn't exist");
        
        var item = new Item()
        {
            Id = newItemDto.Id,
            Name = newItemDto.Name,
            Weight = newItemDto.Weight
        };
        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            await _dbService.AddNewItems(item);

            scope.Complete();
        }
        return Created("api/orders", item);
    }


}