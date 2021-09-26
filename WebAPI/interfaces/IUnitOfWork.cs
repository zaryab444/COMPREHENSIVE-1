using System.Threading.Tasks;
using WebAPI.Interfaces;

namespace WebAPI.interfaces
{
    public interface IUnitOfWork
    {
         ICityRepository CityRepository{get;}

         Task<bool> SaveAsync();
    }
}
