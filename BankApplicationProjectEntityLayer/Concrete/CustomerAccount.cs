﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplicationProjectEntityLayer.Concrete
{
    public class CustomerAccount
    {
        public int CustomerAccountID { get; set; }
        public string CustomerAccountNumber { get; set;}
        public string CustomerAccountCurrency { get; set;}
        public decimal CustomerAccountBalance { get; set;}
        public string BankBranch{ get;}
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
     public   List<CustomerAccountProcess> CustomerSender {  get; set; }
     public   List<CustomerAccountProcess> CustomerReceiver{  get; set; }

    }
}
