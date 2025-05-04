using Microsoft.AspNetCore.Mvc;
using ShipApplication.Models;

namespace ShipApi.Controllers;

[ApiController]
[Route("api/ships")]
public class ShipsController : ControllerBase
{
    private readonly ShipRegistry Registry;

    public ShipsController(ShipRegistry registry)
    {
        Registry = registry;
    }

    [HttpGet]
    public IActionResult GetAllShips()
    {
        var ships = Registry.GetAllShips().Select(s => new
        {
            s.ImoNumber,
            s.Name,
            s.Length,
            s.Width,
            Type = s switch
            {
                PassengerShip => "Passenger",
                TankerShip => "Tanker",
                _ => "Unknown"
            }
        });

        return Ok(ships);
    }

    [HttpGet("{imo}")]
    public IActionResult GetShip(string imo)
    {
        var ship = Registry.GetShip(imo);
        if (ship == null)
            return NotFound();

        return Ok(new
        {
            ship.ImoNumber,
            ship.Name,
            ship.Length,
            ship.Width,
            Type = ship switch
            {
                PassengerShip => "Passenger",
                TankerShip => "Tanker",
                _ => "Unknown"
            }
        });
    }
}
