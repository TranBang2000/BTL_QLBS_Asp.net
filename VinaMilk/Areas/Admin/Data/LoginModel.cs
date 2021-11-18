using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VinaMilk.Areas.Admin.Data
{
    public class LoginModel
    {
        internal readonly string userName;
        internal string Password;

        [Required(ErrorMessage = "Mời nhập username")]
        public string UserName { set; get; }
        [Required(ErrorMessage = "Mời nhập PassWord")]
        public string PassWord { set; get; }
        public bool Remember { set; get; }
        public string PhoneNumbers { get; internal set; }
        public string Name { get; internal set; }
        public string Adress { get; internal set; }
        public string Email { get; internal set; }
    }
}