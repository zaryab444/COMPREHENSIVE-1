using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Dtos;
using WebAPI.Error;
using WebAPI.interfaces;
using WebAPI.Models;

namespace WebAPI.Controllers
{



  public class AccountController : BaseController
  {
    private readonly IUnitOfWork uow;
    private readonly IConfiguration configuration;
    public AccountController(IUnitOfWork uow, IConfiguration configuration)
    {
      this.configuration = configuration;
      this.uow = uow;

    }

   // http://localhost:5000/api/account/login

//    {
//     "UserName":"zay",
//     "Password": "1233"
// }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginReqDto loginReq)
    {

      var user = await uow.UserRepository.Authenticate(loginReq.UserName, loginReq.Password);


      ApiError apiError = new ApiError();

      if (user == null)
      {
        apiError.ErrorCode=Unauthorized().StatusCode;
        apiError.ErrorMessage="Invalid user name or password";
        apiError.ErrorDetails="This error appear when provided user id or password does not exists";
        return Unauthorized(apiError);
      }

      var loginRes = new LoginResDto();
      loginRes.UserName = user.Username;
      loginRes.Token = CreateJWT(user);

      return Ok(loginRes);

    }

 [HttpPost("register")]
    public async Task<IActionResult> Register(LoginReqDto loginReq)

{


      ApiError apiError = new ApiError();
  if(await uow.UserRepository.UserAlreadyExistss(loginReq.UserName, loginReq.Password))
{     apiError.ErrorCode=BadRequest().StatusCode;
      apiError.ErrorMessage="UserName already exist , please try different one";
      return BadRequest(apiError);

}
  uow.UserRepository.Register(loginReq.UserName, loginReq.Password);
  await uow.SaveAsync();
  return StatusCode(201);

}






    private string CreateJWT(User user)
    {



            var secretKey = configuration.GetSection("AppSettings:Key").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));


      var claims = new Claim[]{
    new Claim(ClaimTypes.Name,user.Username),
    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
  };

      var signingCredentials = new SigningCredentials(
        key, SecurityAlgorithms.HmacSha256Signature);

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.UtcNow.AddDays(10),
        SigningCredentials = signingCredentials
      };

      var tokenHandler = new JwtSecurityTokenHandler();
      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);

    }


  }
}

