using System.Collections.Generic;
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
      var properties = await dc.Properties.ToListAsync();
      return properties;
    }
  }
}
