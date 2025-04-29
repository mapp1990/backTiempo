using arq_micro_pru_tiempo.Models;
using arq_micro_tiempo.Repositories.DTO;
using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly UserContext _context;

    public AuthController(IMapper mapper, UserContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] UserLogin_DTO user)
    {
        User userDB =  _context.Users.Where(x => x.UserName == user.UserName).FirstOrDefault();
        if (user is null)
        {
            return BadRequest("Invalid client request");
        }
        

        if (user.UserName == userDB.UserName && user.Password == userDB.Password)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("EstaEsUnaClaveSuperSeguraDeJWT123456"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: "https://localhost:44320",
                audience: "https://localhost:44320",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return Ok(new AuthenticatedResponse { Token = tokenString, user = userDB });
        }

        return Unauthorized();
    }
}