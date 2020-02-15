using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopyLibrary.Model
{
  public  class Users
    {
        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string lastName { get; set; }

        public int Gender { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

    }
}
