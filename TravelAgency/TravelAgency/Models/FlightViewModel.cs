using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAgency.Models
{
    public class FlightViewModel
    {
        public int Id { get; set; }

        public string DateStart { get; set; } //Date when we flight to country where we relax

        public string Type { get; set; } //such as bussnes class, standart ...
    }
}