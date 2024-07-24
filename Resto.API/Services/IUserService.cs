using Resto.API.Entities;

namespace Resto.API.Services
{
    public interface IUserService
    {
        List<User> GetAll();

        public void Update(User user);

        public void Delete(String id);
        public User GetById(string id);
        public void Add(User user);


    }
}
