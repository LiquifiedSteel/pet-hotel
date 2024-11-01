using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace pet_hotel.Models;

public class PetOwner
{
   // `id` will automatically get set to the primary key
   [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
   [Key]
   public int id { get; set; }

   [Required]
   public string name { get; set; }

   [Required]
   [EmailAddress]
   public string email { get; set; }

   [JsonIgnore] // do not include this in the JSON API (breaks the infinite loop)
   public ICollection<Pet> pets { get; set; }

   [NotMapped] // lets EF know not to try to make a column for this
   public int petCount { get { return pets == null ? 0 : pets.Count; } }
}