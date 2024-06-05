﻿using Models;
using Services;

namespace Controllers
{
    public class CarController
    {
        private CarService _carService;

        public CarController() { _carService = new(); }


        public bool InsertAll(List<Car> list) => _carService.InsertAll(list);
    }
}
