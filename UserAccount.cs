using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebChat.Models
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage ="Ad alanı boş geçilemez")]
        public String Name { get; set; }
        [Required(ErrorMessage = "Kullanıcı Adı boş geçilemez")]
        public String UserName { get; set; }
        [Required(ErrorMessage = "Şifre Alanı boş geçilemez")]
        public String PassWord { get; set; }

    }
}