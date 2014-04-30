using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestApi.Controllers
{
    public class UserController : ApiController
    {

        public List<UserServiceReference.UserRequest> GetUsers()
        {
            using (UserServiceReference.ServiceClient client = new UserServiceReference.ServiceClient())
            {
                var users = client.GetAllUsers();
                return users.ToList();
            }
        }

        public UserServiceReference.UserRequest GetUser(int id)
        {
            using (UserServiceReference.ServiceClient client = new UserServiceReference.ServiceClient())
            {
                return client.GetUserById(new UserServiceReference.GetUserById() { inputUserId = id});
            }
        }

        public int PostUser(UserServiceReference.UserRequest user)
        {
            using (UserServiceReference.ServiceClient client = new UserServiceReference.ServiceClient())
            {
                int createdId = (int) client.CreateUser(new UserServiceReference.CreateUser() { inputUserRequest = user });
                return createdId;
            }
        }

        public void DeleteUser(int id)
        {
            using (UserServiceReference.ServiceClient client = new UserServiceReference.ServiceClient())
            {
                client.DeleteUser(id);
            }
        }
    }
}
