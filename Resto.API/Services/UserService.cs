using Resto.API.Data;
using Resto.API.Entities;
using System.Reflection.Metadata.Ecma335;

namespace Resto.API.Services
{
    public class UserService : IUserService
    {
        public SqlServerDbContext _dbContext;
        public UserService(SqlServerDbContext sqlServerDbContext)
        {
            _dbContext = sqlServerDbContext;
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
    }
}
