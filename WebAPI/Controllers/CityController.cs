using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
//using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly DataContext dc;
        public CityController(DataContext dc)
        {
            this.dc = dc;
        }


        [HttpGet("")]
        // http://localhost:5000/api/city
        public async Task<IActionResult> GetCities()
        {
          var cities = await dc.Cities.ToListAsync();
          return Ok(cities);
        }


         [HttpPost("add")]
         
          [HttpPost("add/{cityname}")]
         //http://localhost:5000/api/city/add?cityname=karachi
        public async Task<IActionResult> AddCity(string cityName)
        {
         City city = new City();
         city.Name = cityName;
         await dc.Cities.AddAsync(city);
         await dc.SaveChangesAsync();
         return Ok(city);
        }
        
        [HttpDelete("delete/{id}")]

        //http://localhost:5000/api/city/delete/id
        public async Task<IActionResult> DeleteCity(int id)
        {
         var city = await dc.Cities.FindAsync(id);
         dc.Cities.Remove(city);
         await dc.SaveChangesAsync();
         return Ok(id);
        }




    }
}