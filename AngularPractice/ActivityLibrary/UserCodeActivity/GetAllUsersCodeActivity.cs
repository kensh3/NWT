using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

using EntityModel;
using DataContract;

namespace ActivityLibrary
{

    public sealed class GetAllUsersCodeActivity : CodeActivity
    {
        private DatabaseEntities1 db = new DatabaseEntities1();

        public OutArgument<List<UserRequest>> UsersReq { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            var users = (from u in db.Users select u).ToList();
            List<UserRequest> usersReq = new List<UserRequest>();
            foreach (User u in users)
            {
                UserRequest userReq = new UserRequest();
                userReq.Id = u.Id;
                userReq.FirstName = u.FirstName;
                userReq.LastName = u.LastName;
                userReq.CarId = u.CarId;
                usersReq.Add(userReq);
            }
            UsersReq.Set(context, usersReq);
        }
    }
}
