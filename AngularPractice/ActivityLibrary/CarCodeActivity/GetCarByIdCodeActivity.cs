using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

using DataContract;
using EntityModel;

namespace ActivityLibrary.CarCodeActivity
{

    public sealed class GetCarByIdCodeActivity : CodeActivity
    {
        private DatabaseEntities1 db = new DatabaseEntities1();

        // Define an activity input argument of type string
        public InArgument<int> CarId { get; set; }
        public OutArgument<CarRequest> CarReq { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            int carId = context.GetValue(this.CarId);
            Car car = db.Cars.Find(carId);
            CarRequest carRequest = new CarRequest();
            carRequest.Id = car.Id;
            carRequest.Name = car.Name;
            carRequest.Type = car.Type;
            carRequest.Year = (int) car.Year;
            CarReq.Set(context, carRequest);
        }
    }
}
