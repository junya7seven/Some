using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AuthModels
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
