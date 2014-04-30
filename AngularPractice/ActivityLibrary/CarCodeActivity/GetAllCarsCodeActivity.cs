using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

using EntityModel;
using DataContract;

namespace ActivityLibrary.CarCodeActivity
{

    public sealed class GetAllCarsCodeActivity : CodeActivity
    {
        private DatabaseEntities1 db = new DatabaseEntities1();

        // Define an activity input argument of type string
        public OutArgument<List<CarRequest>> CarsReq { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            var cars = from c in db.Cars select c;
            List<CarRequest> carsReq = new List<CarRequest>();
            foreach (Car c in cars)
            {
                CarRequest carReq = new CarRequest();
                carReq.Id = c.Id;
                carReq.Name = c.Name;
                carReq.Type = c.Type;
                carReq.Year = (int) c.Year;
                carsReq.Add(carReq);
            }
            CarsReq.Set(context, carsReq.ToList());
        }
    }
}
