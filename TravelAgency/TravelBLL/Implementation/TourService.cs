using Binbin.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TravelBLL.Filters;
using TravelBLL.Interfaces;
using TravelDAL.Entities;
using TravelDAL.Repository.Interface;

namespace TravelBLL.Implementation
{
    public class TourService : ITourService
    {
        private readonly IGenericRepository<Tour> _tourRepository;
        private readonly IGenericRepository<Flight> _frightRepository;
        private readonly IGenericRepository<Location> _locationRepository;
        private readonly IGenericRepository<ImageForGallary> _gallaryRepository;

        public TourService(IGenericRepository<Tour> tourRepository,
            IGenericRepository<Flight> frightRepository,
            IGenericRepository<Location> locationRepository, IGenericRepository<ImageForGallary> gallaryRepository)
        {
            _tourRepository = tourRepository;
            _frightRepository = frightRepository;
            _locationRepository = locationRepository;
            _gallaryRepository = gallaryRepository;
        }

        public async Task AddLocationAsync(Location location)
        {
            await _locationRepository.CreateAsync(location);
        }

        public async Task AddTourAsync(Tour tour)
        {
            await _tourRepository.CreateAsync(tour);
        }

        public IEnumerable<Flight> GetAllFlight()
        {
            return _frightRepository.GetAll();
        }

        public IEnumerable<Location> GetAllLocation()
        {
            return _locationRepository.GetAll();
        }



        public  IEnumerable<Tour> GetAllTour(List<TourFilter> filters)
        {
            if (filters == null)
            {
                return _tourRepository.GetAll();
            }

            // Filters
            // x => x.Developer.Name == "Ubisoft" ||
            // x => x.Developer.Name == "Zaremba"

            var predicates = new List<Expression<Func<Tour, bool>>>();


            //var results = filters.GroupBy(
            // p => p.Name,
            // p => p.Type,
            //(key, g) => new { Type = key, Name = g.ToList() });

            var results2 = filters.GroupBy(x => x.Type);
            foreach (var item in results2)
            {
                var builder = PredicateBuilder.Create(item.FirstOrDefault().Predicate);
                for (int i = 1; i < item.Count(); i++)
                {
                    builder.Or(item.ToArray()[i].Predicate);
                }
                predicates.Add(builder);
            }

            var b = PredicateBuilder.Create(predicates.FirstOrDefault());
            for (int i = 1; i < predicates.Count(); i++)
            {
                b.And(predicates[i]);
            }
            return _tourRepository.GetAll().Where(b.Compile());
        }

        public IEnumerable<string> GetFlight()
        {
            return _frightRepository.GetAll().Select(x => x.FlightDateToBegan.ToString());
        }

        public IEnumerable<string> GetGallaries()
        {
            return _gallaryRepository.GetAll().Select(x => x.Image);
        }

        public IEnumerable<ImageForGallary> GetImageForGallaries()
        {
            return _gallaryRepository.GetAll();
        }

        public IEnumerable<string> GetLocation()
        {
            return _locationRepository.GetAll().Select(x => x.City + ", " + x.Country);
        }

        public Tour GetTour(int id)
        {
            return _tourRepository.Get(id);
        }
    }
}
