using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.interfaces;
using WebAPI.Models;

namespace WebAPI.Data.Repo
{
  public class PropertyRepository : IPropertyRepository
  {
    private readonly DataContext dc;

    public PropertyRepository(DataContext dc)
    {
      this.dc = dc;
    }
    public void AddProperty(Property property)
    {
      throw new System.NotImplementedException();
    }

    public void DeleteProperty(int id)
    {
      throw new System.NotImplementedException();
    }

    public async Task<IEnumerable<Property>> GetPropertiesAsync(int sellRent)
    {
      var properties = await dc.Properties.
      Include(p => p.PropertyType)
      .Include(p => p.city)
      .Include(p => p.FurnishingType)


      .Where(p => p.SellRent == sellRent).ToListAsync();
      return properties;
    }



 public async Task<Property> GetPropertyDetailAsync(int id)
        {
            var properties = await dc.Properties
            .Include(p => p.PropertyType)
            .Include(p => p.city)
            .Include(p => p.FurnishingType)
            .Where(p => p.Id == id)
            .FirstAsync();

            return properties;
        }
}
}
