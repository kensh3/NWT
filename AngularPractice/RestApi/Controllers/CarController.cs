using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace RestApi.Controllers
{
    public class CarController : ApiController
    {
        
        public List<CarServiceReference.CarRequest> GetCars()
        {
            using (CarServiceReference.ServiceClient client = new CarServiceReference.ServiceClient())
            {
                var cars = client.GetAllCars();
                return cars.ToList();
            }
        }

        public CarServiceReference.CarRequest GetCar(int id)
        {
            using (CarServiceReference.ServiceClient client = new CarServiceReference.ServiceClient())
            {
                return client.GetCarById(new CarServiceReference.GetCarById() { inputCarId = id });
            }
        }

        public int PostCar(CarServiceReference.CarRequest car)
        {
            using (CarServiceReference.ServiceClient client = new CarServiceReference.ServiceClient())
            {
                int createdId = (int) client.CreateCar(new CarServiceReference.CreateCar() {inputCarRequest = car});
                return createdId;
            }
        }

        public void DeleteCar(int id)
        {
            using (CarServiceReference.ServiceClient client = new CarServiceReference.ServiceClient())
            {
                client.DeleteCar(id);
            }
        }
    }
}
