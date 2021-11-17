using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;
using WebAPI.interfaces;


namespace WebAPI.Controllers
{
    public class PropertyTypeController: BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public PropertyTypeController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

         // GET http://localhost:5000/api/propertytype/list
        [HttpGet ("list")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPropertyTypes()
        {
            var PropertyTypes = await uow.propertyTypeRepository.GetPropertyTypesAsync();
            var PropertyTypesDto = mapper.Map<IEnumerable<KeyValuePairDto>>(PropertyTypes);
            return Ok(PropertyTypesDto);
        }

    }
}
