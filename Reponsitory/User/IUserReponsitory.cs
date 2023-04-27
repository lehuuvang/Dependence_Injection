using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitory.User
{
    public interface IUserReponsitory
    {
        public List<Domain.Enities.User> getAllaccount();
    }
}
