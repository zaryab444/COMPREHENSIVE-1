using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
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
  [Authorize]
  public class CityController : BaseController
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
    //[AllowAnonymous]
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
      uow.CityRepository.AddCity(city);
      await uow.SaveAsync();
      return StatusCode(201);


    }

 //  http://localhost:5000/api/city/update/id
      [HttpPut("update/{id}")]
     public async Task<IActionResult> UpdateCity(int id , CityDto cityDto)
       {
          try {
 if(id != cityDto.Id)
             return BadRequest("Update not allowed");
            var cityFromDb = await uow.CityRepository.FindCity(id);
            if(cityFromDb == null)
            return BadRequest("Update not allowed");
            cityFromDb.LastUpdatedBy = 1;
            cityFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(cityDto, cityFromDb);


            await uow.SaveAsync();
            return StatusCode(200);
          } catch{
                  return StatusCode(500,"Some unkonwn error occured");
          }


        }


//  http://localhost:5000/api/city/update/id
      [HttpPatch("update/{id}")]
     public async Task<IActionResult> UpdateCityPatch(int id ,JsonPatchDocument< City> cityToPatch)
       {
            var cityFromDb = await uow.CityRepository.FindCity(id);
            cityFromDb.LastUpdatedBy = 1;
            cityFromDb.LastUpdatedOn = DateTime.Now;

           cityToPatch.ApplyTo(cityFromDb,ModelState);
            await uow.SaveAsync();
            return StatusCode(200);
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
