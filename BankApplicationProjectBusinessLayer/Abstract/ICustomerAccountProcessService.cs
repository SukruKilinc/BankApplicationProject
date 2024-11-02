    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApplicationProjectEntityLayer.Concrete;

namespace BankApplicationProjectBusinessLayer.Abstract
{
    public interface ICustomerAccountProcessService:IGenericService<CustomerAccountProcess>
    {
        List<CustomerAccountProcess> TMyLastProcess(int id);
    }
}
