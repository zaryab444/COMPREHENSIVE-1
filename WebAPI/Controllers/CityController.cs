using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Data.Repo;
using WebAPI.Dtos;
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
    private readonly IMapper mapper;

    public CityController( IUnitOfWork uow, IMapper mapper)
     {
      this.uow = uow;
      this.mapper = mapper;
    }


    [HttpGet("")]
    // http://localhost:5000/api/city
    public async Task<IActionResult> GetCities()
    {
      var cities = await uow.CityRepository.GetCitiesAsync();
 var citiesDto = mapper.Map<IEnumerable<CityDto>>(cities);


      return Ok(citiesDto);
    }


    [HttpPost("post")]

    //http://localhost:5000/api/city/post
    public async Task<IActionResult> AddCity(CityDto cityDto)
    {
      var city = mapper.Map<City>(cityDto);
      city.LastUpdatedBy = 1;
      city.LastUpdatedOn = DateTime.Now;

    //   var city = new City{
    //    Name = cityDto.Name,
    //   LastUpdatedBy = 1,
    //   LastUpdatedOn = DateTime.Now
    // };
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
