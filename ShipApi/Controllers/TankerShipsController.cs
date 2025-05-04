using Microsoft.AspNetCore.Mvc;
using ShipApplication.Models;

namespace ShipApi.Controllers;

[ApiController]
[Route("api/tanker-ships")]
public class TankerShipsController : ControllerBase
{
    private readonly ShipRegistry Registry;

    public TankerShipsController(ShipRegistry registry)
    {
        Registry = registry;
    }

    [HttpPost]
    public IActionResult AddTankerShip([FromBody] TankerShipDto dto)
    {
        var tanks = dto.Tanks.Select(cap => new Tank(cap)).ToList();
        var ship = new TankerShip(dto.ImoNumber, dto.Name, dto.Length, dto.Width, tanks);
        Registry.AddShip(ship);
        return Ok();
    }

    [HttpPut("{imo}/refuel")]
    public IActionResult Refuel(string imo, [FromBody] RefuelDto dto)
    {
        Registry.RefuelTank(imo, dto.TankIndex, dto.FuelType, dto.Amount);
        return Ok();
    }

    [HttpPut("{imo}/empty/{tankIndex}")]
    public IActionResult EmptyTank(string imo, int tankIndex)
    {
        Registry.EmptyTank(imo, tankIndex);
        return Ok();
    }

    [HttpGet("{imo}/tanks")]
    public IActionResult GetTanks(string imo)
    {
        var ship = Registry.GetShip(imo) as TankerShip;
        if (ship == null)
            return NotFound("Ship not found or not a tanker.");
        var result = ship.Tanks.Select(t => new { t.Capacity, t.CurrentLevel, t.Type });
        return Ok(result);
    }
}
