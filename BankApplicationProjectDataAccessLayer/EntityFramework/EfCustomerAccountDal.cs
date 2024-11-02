using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApplicationProjectDataAccessLayer.Abstract;
using BankApplicationProjectDataAccessLayer.Concrete;
using BankApplicationProjectDataAccessLayer.Repositories;
using BankApplicationProjectEntityLayer.Concrete;

namespace BankApplicationProjectDataAccessLayer.EntityFramework
{
    public class EfCustomerAccountDal : GenericRepository<CustomerAccount>, ICustomerAccountDal
    {
        public List<CustomerAccount> GetCustomerAccountsList(int id)
        {
            using var context = new Context();
            var values = context.CustomerAccounts.Where(x => x.AppUserID == id).ToList();
            return values;
        }
    }
}
