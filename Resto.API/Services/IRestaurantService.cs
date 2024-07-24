using Microsoft.AspNetCore.Mvc;
using Resto.API.Entities;

namespace Resto.API.Services
{
    public interface IRestaurantService
    {
        List<Restaurant> GetAll();

        public void Update(Restaurant restaurant);

        public void Delete(string id);

        public Restaurant GetById(string id);

        public void Add(Restaurant restaurant);


    }
}
