using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Data.Repo;
using WebAPI.Models;
//using WebAPI.Models;

namespace WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CityController : ControllerBase
  {
    private readonly ICityRepository repo;
    public CityController( ICityRepository repo)
    {
      this.repo = repo;
    }


    [HttpGet("")]
    // http://localhost:5000/api/city
    public async Task<IActionResult> GetCities()
    {
      var cities = await repo.GetCitiesAsync();
      return Ok(cities);
    }


    [HttpPost("post")]

    //http://localhost:5000/api/city/post
    public async Task<IActionResult> AddCity(City city)
    {
      repo.AddCity(city);
      await repo.SaveAsync();
      return StatusCode(201);

    }

    [HttpDelete("delete/{id}")]

    //http://localhost:5000/api/city/delete/id
    public async Task<IActionResult> DeleteCity(int id)
    {


      repo.DeleteCity(id);
      await repo.SaveAsync();
      return Ok(id);
    }




  }
}
