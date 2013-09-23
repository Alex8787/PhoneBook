using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneBook.Models
{
    public class Abonent
    {
        public int AbonentId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        public virtual ICollection<Number> Numbers { get; set; }
    }
}