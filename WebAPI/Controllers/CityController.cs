using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Data.Repo;
using WebAPI.interfaces;
using WebAPI.Interfaces;
using WebAPI.Models;
//using WebAPI.Models;

namespace WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CityController : ControllerBase
  {
    private readonly IUnitOfWork uow;

    public CityController( IUnitOfWork uow)
     {
      this.uow = uow;
    }


    [HttpGet("")]
    // http://localhost:5000/api/city
    public async Task<IActionResult> GetCities()
    {
      var cities = await uow.CityRepository.GetCitiesAsync();
      return Ok(cities);
    }


    [HttpPost("post")]

    //http://localhost:5000/api/city/post
    public async Task<IActionResult> AddCity(City city)
    {
      uow.CityRepository.AddCity(city);
      await uow.SaveAsync();
      return StatusCode(201);

    }

    [HttpDelete("delete/{id}")]

    //http://localhost:5000/api/city/delete/id
    public async Task<IActionResult> DeleteCity(int id)
    {


      uow.CityRepository.DeleteCity(id);
      await uow.SaveAsync();
      return Ok(id);
    }




  }
}
