﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelDAL.Entities
{
    public class ImageForGallary
    {
        public int Id { get; set; }
        public string Image { get; set; }

        public int? TourId { get; set; }
        public Tour Tour { get; set; }
    }
}
