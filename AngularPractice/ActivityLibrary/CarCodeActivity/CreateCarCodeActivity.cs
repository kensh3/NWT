using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

using EntityModel;
using DataContract;

namespace ActivityLibrary.CarCodeActivity
{

    public sealed class CreateCarCodeActivity : CodeActivity
    {
        private DatabaseEntities1 db = new DatabaseEntities1();

        // Define an activity input argument of type string
        public InArgument<CarRequest> CarReq { get; set; }
        public OutArgument<int> CreatedCarId { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            CarRequest carRequest = context.GetValue(this.CarReq);
            Car car = new Car();
            car.Id = carRequest.Id;
            car.Name = carRequest.Name;
            car.Type = carRequest.Type;
            car.Year = carRequest.Year;
            Car createdCar = db.Cars.Add(car);
            db.SaveChanges();
            CreatedCarId.Set(context, createdCar.Id);
        }
    }
}
