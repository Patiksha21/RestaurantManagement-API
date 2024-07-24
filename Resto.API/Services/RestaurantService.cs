using Resto.API.Data;
using Resto.API.Entities;

namespace Resto.API.Services
{
    public class RestaurantService : IRestaurantService
    {
        public SqlServerDbContext _dbContext;
        public RestaurantService(SqlServerDbContext sqlServerDbContext)
        {
            _dbContext = sqlServerDbContext;
        }

        public List<Restaurant> GetAll()
        {
            return _dbContext.Restaurants.ToList(); //Lamda expression (same like SQL query)
        }


        public void Update(Restaurant restaurant)
        {
            _dbContext.Restaurants.Update(restaurant);
            _dbContext.SaveChanges();
        }

        public void Delete(String id)
        {
            var restaurant = _dbContext.Restaurants.Find(id);
            if (restaurant != null)
            {
                _dbContext.Restaurants.Remove(restaurant);
                _dbContext.SaveChanges();
            }
        }

        public Restaurant GetById(string id)
        {
            return _dbContext.Restaurants.Find(id);
        }

        public void Add(Restaurant restaurant)
        {
            _dbContext.Restaurants.Add(restaurant);
            _dbContext.SaveChanges();
        }


    }
}
