using Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitory.User
{
    public class UserReponsitory : IUserReponsitory
    {
        private readonly MvcContext mvcContext;
        public UserReponsitory(MvcContext mvcContext)
        {
            this.mvcContext = mvcContext;
        }
        public List<Domain.Enities.User> getAllaccount()
        {
            try
            {
                List<Domain.Enities.User> listUser = (
                    from a in this.mvcContext.Users
                    orderby a.Id
                    select a
                    ).ToList();
                return listUser;
            }
            catch (Exception ex)
            {
                throw new Exception("Add listUser not successfully!");
            }
        }
    }
}
