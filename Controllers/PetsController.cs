using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pet_hotel.Models;

namespace pet_hotel.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PetsController : ControllerBase
{
   private readonly ApplicationContext _context;
   public PetsController(ApplicationContext context)
   {
      _context = context;
   }

   [HttpPost]
   public IActionResult createPet([FromBody] Pet newPet)
   {
      // INSERT into the context, save changes to the database
      _context.Pets.Add(newPet);
      _context.SaveChanges();

      Pet pet = _context.Pets.Include(p => p.petOwner).SingleOrDefault(p => p.id == newPet.id);



      // We need to specify WHERE this pet will be available
      // as part of being a nice HTTP designer
      return Created($"/api/pet/{newPet.id}", pet);
   }

   [HttpPut("{petId}")]
   public IActionResult UpdatePet(int petId, [FromBody] Pet pet)
   {
      if (petId != pet.id)
      {
         return BadRequest(); // 400
      }

      bool ExistingPet = _context.Pets.Any(b => b.id == petId);
      if (ExistingPet is false)
      {
         return NotFound(); // 404
      }

      _context.Pets.Update(pet);
      _context.SaveChanges();

      return Ok(pet);
   }

   [HttpPut("{petId}/checkin")]
   public IActionResult CheckInPet(int petId)
   {
      bool ExistingPet = _context.Pets.Any(p => p.id == petId);
      if (ExistingPet is false)
      {
         return NotFound(); // 404
      }
      Pet pet = _context.Pets.SingleOrDefault(p => p.id == petId);

      pet.checkedInAt = DateTime.UtcNow;

      _context.Pets.Update(pet);
      _context.SaveChanges();

      return Ok(pet);
   }

   [HttpPut("{petId}/checkout")]
   public IActionResult CheckOutPet(int petId)
   {
      bool ExistingPet = _context.Pets.Any(p => p.id == petId);
      if (ExistingPet is false)
      {
         return NotFound(); // 404
      }
      Pet pet = _context.Pets.SingleOrDefault(p => p.id == petId);

      pet.checkedInAt = null;

      _context.Pets.Update(pet);
      _context.SaveChanges();

      return Ok(pet);
   }
}