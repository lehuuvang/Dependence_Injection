using Reponsitory.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.User
{
    public class UserServices:  IUserServices
    {
        public readonly IUserReponsitory userReponsitory;
        public UserServices(IUserReponsitory userReponsitory)
        {
            this.userReponsitory = userReponsitory;
        }
        public List<Domain.Enities.User> getAllaccount()
        {
            return userReponsitory.getAllaccount();
        }
    }
}
