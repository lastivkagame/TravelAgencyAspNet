using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelDAL.Entities
{
    public class Flight
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string DateStart { get; set; } //Date when we flight to country where we relax

        //[Required]
        //public string FlightDateBackBegan { get; set; } //Date when we flight back to home(country)

        //[Required]
        //public string StartTimeHours { get; set; } //Date(HOURS) when we flight to country where we relax

        public string Type { get; set; } //such as bussnes class, standart ...

        public virtual ICollection<Tour> Tours { get; set; }
    }
}
