using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelDAL.Entities
{
    public class Tour
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Hotel { get; set; }

        [Required]
        public string Telephone { get; set; }

        [Required]
        public int? ResortNights { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Valute { get; set; }

        [Required]
        public int? MaxAmountPeople { get; set; }

        public int? MinAmountPeople { get; set; }

        public float Rating { get; set; }

        [Required]
        public string MealType { get; set; } // allinclusive, ultra allinclusive, only breakfast and supper and other ...

        [Required]
        public virtual Flight Flight { get; set; }

        public virtual Location LocationFirstFlight { get; set; } //country, city from we start tour

        public virtual Location LocationResortPlace { get; set; } //country, city where we resort/relax

        public string Description { get; set; }
        public string TypeRoom { get; set; }

        public string Image { get; set; }

        [NotMapped]
        public string FullIdentity => "Element" + this.Id;

        virtual public ICollection<ImageForGallary> ImageForGallaries { get; set; }

        public Tour()
        {
            ImageForGallaries = new List<ImageForGallary>();
        }

    }
}
