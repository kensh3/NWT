using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

using EntityModel;
using DataContract;

namespace ActivityLibrary
{

    public sealed class CreateUserCodeActivity : CodeActivity
    {
        private DatabaseEntities1 db = new DatabaseEntities1();

        // Define an activity input argument of type string
        public InArgument<UserRequest> UserReq { get; set; }
        public OutArgument<int> CreatedUserId { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            UserRequest userReq = context.GetValue(this.UserReq);
            User user = new User();
            user.FirstName = userReq.FirstName;
            user.LastName = userReq.LastName;
            user.CarId = userReq.CarId;
            User createdUser = db.Users.Add(user);
            db.SaveChanges();
            CreatedUserId.Set(context, createdUser.Id);
        }
    }
}
