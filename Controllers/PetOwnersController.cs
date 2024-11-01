using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pet_hotel.Models;

namespace pet_hotel.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PetOwnersController : ControllerBase
{
   private readonly ApplicationContext _context;
   public PetOwnersController(ApplicationContext context)
   {
      _context = context;
   }

   [HttpGet] // GET /api/petowners/
   public IEnumerable<PetOwner> GetPetOwners()
   {
      return _context.PetOwners.ToList();
   }

   [HttpGet("{PetOwnerId}")]
   public IActionResult GetPetOwnerById(int PetOwnerId)
   {
      PetOwner foundPetOwner = _context.PetOwners.SingleOrDefault(p => p.id == PetOwnerId);

      // if baker is not found, return 404 instead!
      return (foundPetOwner == null) ? NotFound() : Ok(foundPetOwner);
   }

   [HttpPost]
   public IActionResult createPetOwner([FromBody] PetOwner newPetOwner)
   {
      // INSERT into the context, save changes to the database
      _context.PetOwners.Add(newPetOwner);
      _context.SaveChanges();

      // We need to specify WHERE this petOwner will be available
      // as part of being a nice HTTP designer
      return Created($"/api/petowner/{newPetOwner.id}", newPetOwner);
   }

   [HttpPut("{petOwnerId}")]
   public IActionResult UpdatePetOwner(int petOwnerId, [FromBody] PetOwner petOwner)
   {
      if (petOwnerId != petOwner.id)
      {
         return BadRequest(); // 400
      }

      bool ExistingPetOwner = _context.PetOwners.Any(b => b.id == petOwnerId);
      if (ExistingPetOwner is false)
      {
         return NotFound(); // 404
      }

      _context.PetOwners.Update(petOwner);
      _context.SaveChanges();

      return Ok(petOwner);
   }
}