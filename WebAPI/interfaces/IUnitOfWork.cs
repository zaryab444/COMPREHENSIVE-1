using System.Threading.Tasks;
using WebAPI.Interfaces;

namespace WebAPI.interfaces
{
    public interface IUnitOfWork
    {
         ICityRepository CityRepository{get;}

         IUserRepository UserRepository {get;}
         Task<bool> SaveAsync();
    }
}
