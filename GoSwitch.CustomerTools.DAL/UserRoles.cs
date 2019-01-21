using GoSwitch.CustomerTools.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoSwitch.CustomerTools.DAL
{
    public class UserRoles
    {
        public static IEnumerable<AspNetRole> GetAllRoles()
        {
            return DataRepositoryFactory.CurrentRepository.GetAll<AspNetRole>();
        }
    }
}
