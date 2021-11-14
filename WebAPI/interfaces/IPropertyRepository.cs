using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.interfaces
{
    public interface IPropertyRepository
    {
       Task<IEnumerable<Property>> GetPropertiesAsync(int sellRent);

       void AddProperty(Property property);

       void DeleteProperty(int id );
    }
}
