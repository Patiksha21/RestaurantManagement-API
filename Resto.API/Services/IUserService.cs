using Resto.API.Entities;

namespace Resto.API.Services
{
    public interface IUserService
    {
        List<User> GetAll();

        void Update(User user);

        void Delete(String id);
        User GetById(string id);
        void Add(User user);
        User? GetUserByEmailPassword(string email, string password);
        string CreateToken(User user);
    }
}
