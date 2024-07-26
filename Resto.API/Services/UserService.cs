using Microsoft.IdentityModel.Tokens;
using Resto.API.Data;
using Resto.API.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;

namespace Resto.API.Services
{
    public class UserService : IUserService
    {
        public SqlServerDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public UserService(SqlServerDbContext sqlServerDbContext, IConfiguration configuration)
        {
            _dbContext = sqlServerDbContext;
            this._configuration = configuration;
        }

        public List<User> GetAll()
        {
            return _dbContext.Users.ToList();//Lamda expression to get data from DB
        }

        public void Update(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }

        public void Delete(String id)
        {
            var restaurant = _dbContext.Users.Find(id);
            if (restaurant != null)
            {
                _dbContext.Users.Remove(restaurant);
                _dbContext.SaveChanges();
            }
        }

        public User GetById(string id)
        {
            return _dbContext.Users.Find(id);
        }

        public void Add(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public User? GetUserByEmailPassword(string email, string password)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
        }

        public string CreateToken(User user)
        {
            // Create claims: JWT claims are the core information that JWTs transmit (kinda like the letter inside a sealed envelope).
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, user.Email));

            //foreach (var role in roles)
            //    claims.Add(new Claim(ClaimTypes.Role, role));

            // Jwt Key stores in the appsettings.json file
            var jwtKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            // Encrypt jwtKey using security algorithm
            var credentials = new SigningCredentials(jwtKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
