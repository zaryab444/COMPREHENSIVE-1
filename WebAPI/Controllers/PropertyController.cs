using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;
using WebAPI.interfaces;

namespace WebAPI.Controllers{


  public class PropertyController : BaseController
  {
    private readonly IUnitOfWork uow;
    private readonly IMapper mapper;

    public PropertyController(IUnitOfWork uow , IMapper mapper)
{
      this.uow = uow;
      this.mapper = mapper;
    }
//http://localhost:5000/api/property/list/2
    [HttpGet("list/{sellRent}")]
    [AllowAnonymous]
     public async Task<IActionResult> GetPropertyList(int sellRent){

       var properties = await uow.PropertyRepository.GetPropertiesAsync(sellRent);
       var propertyListDTO = mapper.Map<IEnumerable<PropertyListDto>>(properties);

       return Ok(propertyListDTO);
     }



  }
}
