using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApplicationProjectDataAccessLayer.Abstract;
using BankApplicationProjectDataAccessLayer.Concrete;
using BankApplicationProjectDataAccessLayer.Repositories;
using BankApplicationProjectEntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BankApplicationProjectDataAccessLayer.EntityFramework
{
    public class EfCustomerAccountProcessDal : GenericRepository<CustomerAccountProcess>, ICustomerAccountProcessDal
    {
        public List<CustomerAccountProcess> MyLastProcess(int id)
        {
            using var context = new Context();
            var values = context.CustomerAccountProcesses.Include(y => y.SenderCustomer).ThenInclude(z => z.AppUser).Include(w=>w.ReceiverCustomer).Where(x => x.ReceiverID == id || x.SenderID == id).ToList();
            return values;
        }
    }
}
