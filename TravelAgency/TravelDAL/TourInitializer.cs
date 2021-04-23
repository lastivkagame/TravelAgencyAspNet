using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelDAL.Entities;

namespace TravelDAL
{
    public class TourInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var locations = new List<Location>()
            {
                new Location(){City = "Kiev", Country = "Ukraine"},
                new Location(){City = "Lviv", Country = "Ukraine"},
                new Location(){City = "Odessa", Country = "Ukraine"},
                new Location(){City = "Charkiv", Country = "Ukraine"},
                new Location(){City = "Rivne", Country = "Ukraine"},

                new Location(){City = "Antalya", Country = "Turkey"},
                new Location(){City = "Durres", Country = "Albania"},
                new Location(){City = "Charm-El-Sheikh", Country = "Egypt"},
                new Location(){City = "Cairo", Country = "Egypt"},
                new Location(){City = "Istanbul", Country = "Turkey"},
                new Location(){City = "Kvariati", Country = "Georgia"},
                new Location(){City = "island Euboea", Country = "Greece"},
                new Location(){City = "Dubai", Country = "UAE"},
                new Location(){City = "Spain", Country = "Costa Brava"},
                new Location(){City = "Kemer", Country = "Turkey"}
            };


            var flights = new List<Flight>()
            {
                new Flight(){ FlightDateToBegan = Convert.ToDateTime("05/01/2021").ToString(), FlightDateBackBegan = Convert.ToDateTime("05/10/2021").ToString(), StartTimeHours = "7:30 AM", Type = "Bussnes Class"  },
                new Flight(){ FlightDateToBegan = new DateTime(2021, 06, 02).ToString(), FlightDateBackBegan = new DateTime(2021,06,09).ToString(), StartTimeHours = "10:30 PM", Type = "Standart"  },
                new Flight(){ FlightDateToBegan = new DateTime(2021,06,20).ToString(), FlightDateBackBegan = new DateTime(2021,06,25).ToString(), StartTimeHours = "5:25 PM", Type = "Bussnes Class"  },
                new Flight(){ FlightDateToBegan = new DateTime(2021/07/01).ToString(), FlightDateBackBegan = new DateTime(2021/07/10).ToString(), StartTimeHours = "1:20 AM", Type = "Standart"  },
                new Flight(){ FlightDateToBegan = new DateTime(2021/07/15).ToString(), FlightDateBackBegan = new DateTime(2021/07/21).ToString(), StartTimeHours = "12:40 AM", Type = "Bussnes Class"  },
                new Flight(){ FlightDateToBegan = new DateTime(2021/07/23).ToString(), FlightDateBackBegan = new DateTime(2021/07/27).ToString(), StartTimeHours = "4:10 PM", Type = "Bussnes Class"  },
                new Flight(){ FlightDateToBegan = new DateTime(2021/07/01).ToString(), FlightDateBackBegan = new DateTime(2021/07/10).ToString(), StartTimeHours = "8:15 PM", Type = "Standart"  },
                new Flight(){ FlightDateToBegan = new DateTime(2021/07/15).ToString(), FlightDateBackBegan = new DateTime(2021/07/21).ToString(), StartTimeHours = "2:40 AM", Type = "Standart"  },
                new Flight(){ FlightDateToBegan =  new DateTime(2021/08/30).ToString(), FlightDateBackBegan = new DateTime(2021/08/07).ToString(), StartTimeHours = "4:05 AM", Type = "Standart"  },
                new Flight(){ FlightDateToBegan =  new DateTime(2021/06/02).ToString(), FlightDateBackBegan = new DateTime(2021/06/09).ToString(), StartTimeHours = "10:30 PM", Type = "Bussnes Class"  },
            };

            var tours = new List<Tour>()
            {
                new Tour(){ Hotel = "Fortuna (Sharm)",
                    Description = "Fortuna is the name of a group of hotels of the same category, with the same type of food, located in the same resort or in a region with one airport of arrival and departure. Confirmation comes to Fortuna indicating the selected stardom and power. The tourist receives a voucher, where in the column 'Name of the hotel' the name Fortuna, the selected star rating and food are indicated. The name of the hotel where the tourist will stay, he learns only at the airport at the counter with a guide",
                    Flight = flights[1],
                    Valute = "USD",
                    Price = 631,
                    ResortNights = 7,
                    Rating = (float)9,
                    MinAmountPeople = 2,
                    MaxAmountPeople = 4,
                    MealType = "All inclusive",
                    LocationFirstFlight = locations[2],
                    LocationResortPlace = locations[8],
                    Image = "https://hotels.sletat.ru/i/f/62006_2.jpg",
                    TypeRoom = "Standard Room",
                    Telephone = " +20 653461001"
                },

                 new Tour(){ Hotel = "Pharaoh Azur Resort",
                    Description = "The hotel opened its doors in 1997 and was remodeled in 2019. It consists of a main 3-storey building, 50 one-storey bungalows and 3-storey detached 2 buildings (2 elevators in the main building and 2 elevators in detached buildings). Located in the southern part of Hurghada, a 20-minute drive from the airport. The hotel has a large, green area with an artificial lake and a beautiful beach. Suitable for a quiet family vacation",
                    Flight = flights[8],
                    Valute = "USD",
                    Price = 655,
                    ResortNights = 5,
                    Rating = (float)8.2,
                    MinAmountPeople = 1,
                    MaxAmountPeople = 5,
                    MealType = "Only breakfast and supper",
                    LocationFirstFlight = locations[1],
                     LocationResortPlace = locations[7],
                    Image = "https://img.poehalisnami.md/static/hotels/egipet/sharm-el-shejjkh/h2187/orig/booking2187_25.jpg",
                    TypeRoom = "Standard Room",
                    Telephone = " +25 653461001"
                },

                  new Tour(){ Hotel = "Elite House ",
                    Description = "A small hotel with cozy rooms. Located 500 meters from the Old Town of Batumi, 200 meters from the beach. The commercial area of ​​the city is nearby. The hotel is suitable for both beach holidays and sightseeing. The hotel is located 500 m from the Old Town, 1 km from Batumi Railway Station, 7 km from Batumi Airport, 125 km from Kutaisi Airport.",
                    Flight = flights[0],
                    Valute = "USD",
                    Price = 458,
                    ResortNights = 6,
                    Rating = (float)8,
                    MinAmountPeople = 2,
                    MaxAmountPeople = 3,
                    MealType = "Only dinner",
                    LocationFirstFlight = locations[0],
                     LocationResortPlace = locations[5],
                    Image = "https://cdn-prod.travelfuse.ro/images/_top_1e2a4d9e4e8be8e468b2fb819c53c3db.jpg",
                    TypeRoom = "Standard Room",
                    Telephone = " +31 653461001"
                },

                   new Tour(){ Hotel = "Hedef Resort Hotel",
                    Description = "The hotel is located 50 meters from its own beach. Built in 2006, the last renovation was carried out in 2012. Consists of one 5-storey building and two 7-storey buildings (30% of rooms with sea view). The hotel is suitable for a quiet family holiday. 100 km from the airport of Antalya 12 km from the city of Alanya.",
                    Flight = flights[4],
                    Valute = "USD",
                    Price = 469,
                    ResortNights = 7,
                    Rating = (float)7,
                    MinAmountPeople = 4,
                    MaxAmountPeople = 5,
                    MealType = "Only breakfast and supper",
                    LocationFirstFlight = locations[3],
                    LocationResortPlace = locations[9],
                    Image = "https://cf.bstatic.com/images/hotel/max1024x768/854/85430599.jpg",
                    TypeRoom = "Standard Room",
                    Telephone = " +55 653461001"
                },

                    new Tour(){ Hotel = "Andriake Beach Club",
                    Description = "Andriake Beach Club Demre is located in Demre, 4.2 km from St. Nicholas Church. It offers non-smoking rooms, a garden, free Wi-Fi, a bar, a restaurant, a children's playground, an outdoor pool, a fitness center, evening entertainment and a 24-hour front desk.",
                    Flight = flights[5],
                    Valute = "USD",
                    Price = 549,
                    ResortNights = 6,
                    Rating = (float)9.3,
                    MinAmountPeople = 4,
                    MaxAmountPeople = 5,
                    MealType = "All Inclusive",
                    Image = "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/06/c5/82/0a/neilson-andriake-beachclub.jpg?w=900&h=-1&s=1",
                    TypeRoom = "Standard Room",
                    Telephone = " +67 653461001"
                },

                     new Tour(){ Hotel = "Golden Tulip Al Barsha",
                    Description = "Golden Tulip Al Barsha Hotel is conveniently located in the heart of Dubai, on Sheikh Zayed Street, just 25 km from Dubai Airport. The hotel is perfect for business trips and has everything you need for business negotiations, but is also suitable for rest and relaxation. Included in the Golden Tulip Hotels chain. The hotel is the winner of the 'Hotel of the Year 2014' award in the Middle East and North Africa. Guests are offered a good selection of international dishes and drinks in the restaurants, as well as 24-hour room service.",
                    Flight = flights[6],
                    Valute = "USD",
                    Price = 579,
                    ResortNights = 6,
                    Rating = (float)7.2,
                    MinAmountPeople = 4,
                    MaxAmountPeople = 5,
                    MealType = "Only dinner",
                    LocationFirstFlight = locations[4],
                    LocationResortPlace = locations[10],
                    Image = "https://s01.cdn-pegast.net/get/71/e5/13/e15ec0c2bd27a5e08f1cbc6e20d5b1c8e209e154b3b5b156471b699459/5c1f731d52577.jpg",
                    TypeRoom = "Standard Room",
                    Telephone = " +88 653461001"
                },

                      new Tour(){ Hotel = "Pylea Beach 3",
                    Description = "A small quiet hotel near the beach. Built in 2000, the last renovation was carried out in 2010. It consists of three 3-storey buildings without an elevator. Compact green area - 5000 m2. All rooms with sea view. Attentive and hospitable staff. There is a water park for adults and children near the hotel.",
                    Flight = flights[3],
                    Valute = "USD",
                    Price = 937,
                    ResortNights = 7,
                    Rating = (float)9,
                    MinAmountPeople = 2,
                    MaxAmountPeople = 2,
                    MealType = "All Inclusive",
                    LocationFirstFlight = locations[0],
                    LocationResortPlace = locations[11],
                    Image = "https://s01.cdn-pegast.net/get/01/5d/03/0446e746b4d71a1c6137c32920d5400f37abfd422b845ef53605f7db13/5c7d00d419a38.jpg",
                    TypeRoom = "Dbl (Standard Sea View Ground Floor)",
                    Telephone = " +99 653461001"
                },

                        new Tour(){ Hotel = "Belair Beach 4",
                    Description = "A small quiet hotel near the beach. Built in 2000, the last renovation was carried out in 2010. It consists of three 3-storey buildings without an elevator. Compact green area - 5000 m2. All rooms with sea view. Attentive and hospitable staff. There is a water park for adults and children near the hotel.",
                    Flight = flights[2],
                    Valute = "USD",
                    Price = 1109,
                    ResortNights = 7,
                    Rating = (float)8.1,
                    MinAmountPeople = 3,
                    MaxAmountPeople = 9,
                    MealType = "All Inclusive",
                    LocationFirstFlight = locations[4],
                     LocationResortPlace = locations[14],
                    Image = "https://media-cdn.tripadvisor.com/media/photo-s/17/f5/ab/66/belair-beach-hotel.jpg",
                    TypeRoom = "Dbl (Standard Garden View)",
                    Telephone = " +99 653461089"
                },

                            new Tour(){ Hotel = "Senza Hotels",
                    Description = "The hotel is located in Turkler, 15 km from the center of Alanya. Opened in 2013. Consists of one 7-storey building. A variety of food, friendly staff. Various animation programs for children and adults. The distance from the beach is compensated by the large amount of entertainment on site.",
                    Flight = flights[5],
                    Valute = "USD",
                    Price = 312,
                    ResortNights = 6,
                    Rating = (float)8.3,
                    MinAmountPeople = 3,
                    MaxAmountPeople = 5,
                    MealType = "All Inclusive",
                    LocationFirstFlight = locations[0],
                    LocationResortPlace = locations[13],
                    Image = "https://www.bgoperator.ru/pr_img/1240100354/20201124/26675083/24112020140435084.jpg",
                    TypeRoom = "Standard Room",
                    Telephone = " +02 653461089"
                }
            };

            List<string> imgs = new List<string>() { "https://m01.tury.ru/hotel/21/21894/426045_1600.jpg", "https://kidpassage.com/images/publications/sharm-el-sheyh-yanvare-otdyh-pogoda/cover_original.jpg",
                "https://kidpassage.com/images/publications/sharm-oktyabre-otdyh-pogoda/cover_original.jpg",
                "https://lh3.googleusercontent.com/proxy/g0lw6CXX3pPWGDWBskHvMrR731eUJjCP5vOJ4DRdsDdzozn6MboCiJ5QuLGC9jZgVk0Uw2IXwZA0ZJ4KgGWRsP1JBlgK-W7HNFJFtT6PVyAqcgWSgpl2F5c",
            "https://img.poehalisnami.ua/static/hotels/egipet/sharm-el-shejjkh/h232000/orig/hi232000_1389723.jpg",
            "https://ht.kiev.ua/ufiles/hotels/26858/4.jpg", "https://galoptur.com/wp-content/uploads/2020/01/4dba8c534cab9.jpg",
                "https://kidpassage.com/images/hotels/rixos-seagate-sharm/cover_original.jpg"};

            var gallary = new List<ImageForGallary>()
            {
                new ImageForGallary() { Image = "https://hotels.sletat.ru/i/f/70901_2.jpg", Tour = tours[0] },
                new ImageForGallary() { Image = "https://hotels.sletat.ru/i/f/62004_1.jpg", Tour = tours[1] },
                new ImageForGallary() { Image = "https://img.poehalisnami.ua/static/hotels/egipet/sharm-el-shejjkh/h3339/orig/hi3339_1256733.jpg", Tour = tours[2] },
                new ImageForGallary() { Image = "https://5okean.com/admin/uploads/2019/02/hotels/00/03/79/09/3790930.jpg", Tour = tours[3] },
                new ImageForGallary() { Image = "https://intercity.by/upload/resize_cache/iblock/24e/763_481_2/Novotel-Sharm-El-Sheikh-Palm-Wing-_27_.jpg", Tour = tours[4] },
                new ImageForGallary() { Image = "https://rosting.by/upload/iblock/d1a/palm.jpg", Tour = tours[5] },
                new ImageForGallary() { Image = "https://m01.tury.ru/hotel/91/91739/312613_1600.jpg", Tour = tours[6] },
                new ImageForGallary() { Image = "https://www.indochinatour.com/assets/images/luxury-tour/luxury-hotel-bangkok.jpg", Tour = tours[7] },
                new ImageForGallary() { Image = "https://q-xx.bstatic.com/images/hotel/max1024x768/370/37046066.jpg", Tour = tours[8] },
            };

            foreach (var item in imgs)
            {
                for (int i = 0; i < 9; i++)
                {
                    gallary.Add(new ImageForGallary() { Image = item, Tour = tours[i] });
                }
            }

            context.Locations.AddRange(locations);
            context.ImageForGallaries.AddRange(gallary);


            context.Flights.AddRange(flights);
            context.Tours.AddRange(tours);

            //context.SaveChangesAsync();

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
