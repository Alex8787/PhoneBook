using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneBook.Models
{
    public class Number
    {
        public int NumberId { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Number must be 10 characters")]
        public string Phone { get; set; }
        public int AbonentId { get; set; }

        public virtual Abonent Abonent { get; set; }
    }
}