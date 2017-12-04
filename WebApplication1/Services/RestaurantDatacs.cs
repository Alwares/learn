using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;

namespace WebApplication1.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        void Add(Restaurant restaurant);
        void Update(Restaurant restaurant);
    }

    public class SqlRestaurantData : IRestaurantData
    {
        private readonly RestaurantDbContext _dbContext;

        public SqlRestaurantData(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _dbContext.Restaurants;
        }

        public Restaurant Get(int id)
        {
            return _dbContext.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public void Add(Restaurant restaurant)
        {
            _dbContext.Restaurants.Add(restaurant);
            _dbContext.SaveChanges();
        }

        public void Update(Restaurant restaurant)
        {
            _dbContext.Update(restaurant);
            _dbContext.SaveChanges();
        }
    }

    public class InMemoryRestaurantData : IRestaurantData
    {

        static InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>()
            {
                new Restaurant(){ Id = 1, name = "KFC"},
                new Restaurant(){ Id = 2, name =  "Meki"},
                new Restaurant(){ Id = 3, name = "Gyros"}
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public void Add(Restaurant restaurant)
        {
            restaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(restaurant);
        }

        public void Update(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }

        private static List<Restaurant> _restaurants;
    }
}
