using Microsoft.AspNetCore.Mvc;
using ShipApplication.Models;

namespace ShipApi.Controllers;

[ApiController]
[Route("api/passenger-ships")]
public class PassengerShipsController : ControllerBase
{
    private readonly ShipRegistry Registry;

    public PassengerShipsController(ShipRegistry registry)
    {
        Registry = registry;
    }

    [HttpPost]
    public IActionResult AddPassengerShip([FromBody] PassengerShipDto dto)
    {
        var ship = new PassengerShip(dto.ImoNumber, dto.Name, dto.Length, dto.Width);
        Registry.AddShip(ship);
        return Ok();
    }

    [HttpPut("{imo}/passengers")]
    public IActionResult UpdatePassengers(string imo, [FromBody] List<string> passengers)
    {
        Registry.UpdatePassengerList(imo, passengers);
        return Ok();
    }

    [HttpGet("{imo}/passengers")]
    public IActionResult GetPassengers(string imo)
    {
        var ship = Registry.GetShip(imo) as PassengerShip;
        if (ship == null)
            return NotFound("Ship not found or not a passenger ship.");
        return Ok(ship.Passengers);
    }
}
