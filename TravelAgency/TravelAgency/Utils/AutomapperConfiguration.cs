using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelAgency.Models;
using TravelDAL.Entities;

namespace TravelAgency.Utils
{
    public class AutomapperConfiguration : Profile
    {
        public AutomapperConfiguration()
        {
            //CreateMap<Flight, FlightViewModel>()
            //   .ForMember(x => x.LocationFirstFlight, s => s.MapFrom(z => z.LocationFirstFlight.City + ", " + z.LocationFirstFlight.Country))
            //   .ForMember(x => x.LocationResortPlace, s => s.MapFrom(z => z.LocationResortPlace.City + ", " + z.LocationFirstFlight.Country));

            //CreateMap<FlightViewModel, Flight>()
            //    .ForMember(x => x.LocationFirstFlight, s => s.MapFrom((z) => CreateLocationFromString(z.LocationFirstFlight)
            //    ))
            //      .ForMember(x => x.LocationResortPlace, s => s.MapFrom((z) => CreateLocationFromString(z.LocationResortPlace)
            //    ));


            CreateMap<Tour, TourViewModel>()
                .ForMember(x => x.Flight, s => s.MapFrom(z => z.Flight.FlightDateToBegan))
                .ForMember(x => x.LocationFirstFlight, s => s.MapFrom(z => z.LocationFirstFlight.City + ", " + z.LocationFirstFlight.Country))
                .ForMember(x => x.LocationResortPlace, s => s.MapFrom(z => z.LocationResortPlace.City + ", " + z.LocationResortPlace.Country))
                .ForMember(x => x.ImageForGallaries, s => s.MapFrom(z => z.Image));

            CreateMap<TourViewModel, Tour>()
                .ForMember(x => x.Flight, s => s.MapFrom(z => CreateFlightFromString(z.Flight)))
                .ForMember(x => x.LocationFirstFlight, s => s.MapFrom(z => CreateLocationFromString(z.LocationFirstFlight)))
                .ForMember(x => x.LocationResortPlace, s => s.MapFrom(z => CreateLocationFromString(z.LocationResortPlace)))
                .ForMember(x => x.ImageForGallaries, s => s.MapFrom(z => CreateGallaryFromString(z.Image)));
        }

        public ICollection<ImageForGallary> CreateGallaryFromString(string img)
        {
            var col = new List<ImageForGallary>()
            {
                new ImageForGallary(){Image = img}
            };

            return col;
        }

        public Location CreateLocationFromString(string data)
        {
            string city = "", country = "";
            bool flag = true;
            foreach (var item in data)
            {
                if (item == ',')
                {
                    flag = false;
                }
                else if (flag)
                {
                    city += item;
                }
                else
                {
                    country += item;
                }

            }

            return new Location() { City = city, Country = country };
        }

        public Flight CreateFlightFromString(string data)
        {
            string date = "", time = "";
            bool flag = true;
            foreach (var item in data)
            {
                if (item == ' ' || item == 'a' || item == 't')
                {
                    flag = false;
                }
                else if (flag)
                {
                    date += item;
                }
                else
                {
                    time += item;
                }

            }

            return new Flight() { FlightDateToBegan = time, StartTimeHours = date };
        }
    }
}