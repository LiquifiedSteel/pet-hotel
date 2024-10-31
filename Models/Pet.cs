using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace pet_hotel.Models;

public class Pet
{
   // Fields go here.
   // Hint: nullable types are a thing in c#, you will need to google
   // this so that `checkedInAt` can accept `null` as a value
   [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
   [Key]
   public int id { get; set; }

   [Required]
   public string name { get; set; }
   
}