using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebChat.Models
{
    public class OurDBContext :DbContext
    {
        public DbSet<UserAccount> kullaniciHesap { get; set; }
    }
}