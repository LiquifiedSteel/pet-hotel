using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace pet_hotel.Models;

public enum PetBreed
{
  Shepherd, // 0
  Poodle,   // 1
  Beagle,   // 2
  Bulldog,  // 3
  Terrier,  // 4
  Boxer,    // 5
  Labrador, // 6
  Retriever,// 7
}

public enum PetColor
{
  Black,    // 0
  White,    // 1
  Golden,   // 2
  Tricolor, // 3
  Spotted,  // 4
}

public class Pet
{
   // Fields go here.
   // Hint: nullable types are a thing in c#, you will need to google
   // this so that `checkedInAt` can accept `null` as a value
   [Key]
   public int id { get; set; }

   [Required]
   public string name { get; set; }
   
   [Required]
   [JsonConverter(typeof(JsonStringEnumConverter))]
   public PetBreed petBreed { get; set; }

   [Required]
   [JsonConverter(typeof(JsonStringEnumConverter))]
   public PetColor petColor { get; set; }

   public DateTime? checkedInAt { get; set; }

   [Required]
   public int petOwnerid { get; set; } // petOwnerId

   public PetOwner petOwner { get; set; }
}