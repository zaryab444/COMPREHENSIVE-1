using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.interfaces
{
    public interface IUserRepository
    {

      Task<User> Authenticate(string userName, string password);

    }
}
