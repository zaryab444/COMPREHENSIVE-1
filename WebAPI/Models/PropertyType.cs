using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
  public class PropertyType : BaseEnity
  {

[Required]
    public string Name {get; set;}
  }
}
