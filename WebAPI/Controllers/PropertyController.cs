using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.interfaces;

namespace WebAPI.Controllers{


  public class PropertyController : BaseController
  {
    private readonly IUnitOfWork uow;

    public PropertyController(IUnitOfWork uow)
{
      this.uow = uow;
    }
//http://localhost:5000/api/property/type/2
    [HttpGet("type/{sellRent}")]
    [AllowAnonymous]
     public async Task<IActionResult> GetPropertyList(int sellRent){

       var properties = await uow.PropertyRepository.GetPropertiesAsync(sellRent);
       return Ok(properties);
     }



  }
}
