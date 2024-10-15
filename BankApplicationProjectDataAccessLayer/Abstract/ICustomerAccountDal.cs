﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApplicationProjectEntityLayer.Concrete;

namespace BankApplicationProjectDataAccessLayer.Abstract
{
    public interface ICustomerAccountDal:IGenericDal<CustomerAccount>
    {
    }
}