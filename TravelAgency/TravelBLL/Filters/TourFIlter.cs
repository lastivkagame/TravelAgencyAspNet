using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TravelDAL.Entities;

namespace TravelBLL.Filters
{
    public class TourFilter
    {
        public string Type { get; set; }
        public string Name { get; set; }

        public Expression<Func<Tour, bool>> Predicate { get; set; }
    }
}
