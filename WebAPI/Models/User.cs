using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
  public class User : BaseEnity
  {


    [Required]

    public string Username {get; set;}
    [Required]

    public string Password {get; set;}

  }
}
