﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BankApplicationProjectEntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string Name{ get; set; }
        public string Surname{ get; set; }
        public string District{ get; set; }
        public string City{ get; set; }
        public string ImageUrl{ get; set; }
        public int ConfirmCode{ get; set; }
        public List<CustomerAccount> CustomerAccounts { get; set; }
    }
}
