using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
  public class FurnishingType : BaseEnity
  {

    [Required]

    public string Name {get; set;}
  }
}
