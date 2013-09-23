using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneBook.Models;

namespace PhoneBook.ViewModels
{
    public class AbonentIndexData
    {
        public IEnumerable<Abonent> Abonents { get; set; }
        public IEnumerable<Number> Numbers { get; set; }
    }
}