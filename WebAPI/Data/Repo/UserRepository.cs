using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.interfaces;
using WebAPI.Models;

namespace WebAPI.Data.Repo
{

  public class UserRepository : IUserRepository
  {
    private readonly DataContext dc;
    public UserRepository(DataContext dc)
    {
      this.dc = dc;

    }
    public async Task<User> Authenticate(string userName, string password)
    {
   return await  dc.Users.FirstOrDefaultAsync(x=> x.Username == userName && x.Password == password);

    }

    public void Register(string userName, string password)
    {
      User user = new User();
      user.Username = userName;
      user.Password = password;
      dc.Users.Add(user);
    }

    public async Task<bool> UserAlreadyExistss(string userName, string password)
    {
     return await dc.Users.AnyAsync(x=>x.Username == userName);
    }
  }
}
