using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Public_site.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Insert username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Insert password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}