using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelAgency.Models
{
    public class TourViewModel
    {
        public int Id { get; set; }

        public string Hotel { get; set; }

        public string Telephone { get; set; }

        [Range(1,100)]
        public int? ResortNights { get; set; }

        public double Price { get; set; }

        public string Valute { get; set; }

        [Range(1, 30, ErrorMessage = "Please enter only 1+ number(but to 30, not more)")]
        public int? MaxAmountPeople { get; set; }

        [Range(1, 100, ErrorMessage ="Please enter only 1+ number(but to 100, not more)")]
        public int? MinAmountPeople { get; set; }

        public float Rating { get; set; }

        public string MealType { get; set; } // allinclusive, ultra allinclusive, only breakfast and supper and other ...

        //public virtual FlightViewModel Flight { get; set; }

        public string LocationFirstFlight { get; set; } //country, city from we start tour

        public string LocationResortPlace { get; set; } //country, city where we resort/relax

        public string Flight { get; set; }


        public string Description { get; set; }
        public string TypeRoom { get; set; }

        public string Image { get; set; }

        public string FullIdentity => "Element" + this.Id;

        public int CountImage => ImageForGallaries != null ? ImageForGallaries.Count() : 0;

         public ICollection<string> ImageForGallaries { get; set; }
        public TourViewModel()
        {
            //ImageForGallaries = new List<string>();
        }

        //public int Id { get; set; }

        //[Required(ErrorMessage = "Name can't be null")]
        //[StringLength(200, ErrorMessage = "Max count of symbols are 200")]
        //public string Name { get; set; }

        //[Range(1, 1000)]
        //public int? ResortNights { get; set; }
        //public string Price { get; set; }

        //[Range(1, 200, ErrorMessage = "Please enter a value bigger than {1}")]
        //public int? AmountPeople { get; set; }
        //public string Type { get; set; } // all inclusive or other
        //public string Location { get; set; }
        //public string Flight { get; set; }

        //public string Description { get; set; }

        //public string Image { get; set; }
    }
}