using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

using EntityModel;
using DataContract;

namespace ActivityLibrary
{

    public sealed class GetUserByIdCodeActivity : CodeActivity
    {
        private DatabaseEntities1 db = new DatabaseEntities1();

        // Define an activity input argument of type string
        public InArgument<int> UserId { get; set; }
        public OutArgument<UserRequest> UserReq { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            int userId = context.GetValue(this.UserId);
            User user = db.Users.Find(userId);
            UserRequest userReq = new UserRequest();
            userReq.Id = user.Id;
            userReq.FirstName = user.FirstName;
            userReq.LastName = user.LastName;
            userReq.CarId = user.CarId;
            context.SetValue(UserReq, userReq);
        }
    }
}
