using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.Services;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRestaurantData _restaurantData;
        private readonly IGreeting _iGreeting;

        public HomeController(IRestaurantData restaurantData, IGreeting iGreeting)
        {
            _restaurantData = restaurantData;
            _iGreeting = iGreeting;
        }
        public IActionResult Index()
        {
            var model = new HomePageViewModel { Restaurants  = _restaurantData.GetAll(), CurrentGreeting = _iGreeting.GetGreeting() };
            return View(model);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RestaurantEditViewModel restaurant)
        {
            if (ModelState.IsValid)
            {
                var rest = new Restaurant();
                rest.name = restaurant.Name;
                rest.CusineType = restaurant.CusineType;
                _restaurantData.Add(rest);
                return RedirectToAction("Details", new { id = rest.Id });
            }

            return View(restaurant);
            
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var restaurant = _restaurantData.Get(id);
            if (restaurant == null)
            {
                return RedirectToAction("Index");
            }
            var model = new RestaurantEditViewModel
            {
                Name =  restaurant.name,
                CusineType = restaurant.CusineType,
                Url = restaurant.Url
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, RestaurantEditViewModel restaurant)
        {
            if (ModelState.IsValid)
            {
                var rest = _restaurantData.Get(id);
                rest.name = restaurant.Name;
                rest.CusineType = restaurant.CusineType;
                
                _restaurantData.Update(rest);
                return RedirectToAction("Details", new { id = rest.Id });
            }

            return View(restaurant);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
