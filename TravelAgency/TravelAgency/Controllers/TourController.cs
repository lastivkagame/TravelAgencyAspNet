using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TravelAgency.Models;
using TravelAgency.Utils.Helpers;
using TravelBLL.Filters;
using TravelBLL.Interfaces;
using TravelDAL.Entities;

namespace TravelAgency.Controllers
{
    public class TourController : Controller
    {
        private readonly ITourService _tourService;
        private readonly IMapper _mapper;

        //from DI
        public TourController(ITourService tourService, IMapper mapper)
        {
            _tourService = tourService;
            _mapper = mapper;
        }

        // GET: Tour
        //public ActionResult Index()
        //{
        //    return View();
        //}


        public ActionResult Index(string search)
        {
            ViewBag.Title = "TourStore";
            #region Manual mapping
            //var games = new List<GameViewModel>();
            //foreach (var item in _gameService.GetAllGames())
            //{
            //    games.Add(new GameViewModel
            //    {
            //        Id = item.Id,
            //        Name = item.Name,
            //        Description = item.Description,
            //        Price = item.Price,
            //        Year = item.Year//,
            //        //Developer = item.De
            //    });
            //} 
            #endregion

            var tour = _mapper.Map<List<TourViewModel>>(_tourService.GetAllTour(null));
            SetViewBag();
            if (String.IsNullOrEmpty(search))
            {
                return View(tour);
            }


            return View(tour.Where(x => x.Hotel.Contains(search)).ToList());

            // var developers = new[] { "Bethesda", "Rockstar", "Ubisoft" };
            // ViewBag.Developers = developers;

        }

        public ActionResult GetLocations()
        {
            return View();
        }

        public ActionResult Create()
        {
            //ViewBag.Locactions = GetLocationsString(_tourService.GetAllLocation());
            //ViewBag.Locactions = _tourService.GetAllLocation();
            //ViewBag.Flights = _tourService.GetAllFlight();
            SetViewBag();
            return View();
        }

        public ActionResult CreateLocation()
        {
            //ViewBag.Locactions = GetLocationsString(_tourService.GetAllLocation());
            //ViewBag.Locactions = _tourService.GetAllLocation();
            //ViewBag.Flights = _tourService.GetAllFlight();
            SetViewBag();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateLocation(LocationViewModel model)
        {
            // 1) якщо картинка:
            //    2) зберегти картинку на сервер
            // 2.1) конвертувати картинку
            //    3) записати шлях в модель
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _tourService.AddLocationAsync(new Location
            {
                City = model.City,
                Country = model.Country
            });

            ViewBag.SuccessLocationCreated = "succes";
            SetViewBag();

            return RedirectToAction("ToursPage");
        }

        public ActionResult CreateFlight()
        {
            //ViewBag.Locactions = GetLocationsString(_tourService.GetAllLocation());
            //ViewBag.Locactions = _tourService.GetAllLocation();
            //ViewBag.Flights = _tourService.GetAllFlight();
            SetViewBag();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateFlight(FlightViewModel model)
        {
            // 1) якщо картинка:
            //    2) зберегти картинку на сервер
            // 2.1) конвертувати картинку
            //    3) записати шлях в модель
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _tourService.AddFlightAsync(new Flight
            {
                DateStart = model.DateStart,
                Type = model.Type
            });

            SetViewBag();

            return RedirectToAction("ToursPage");
        }

        public List<string> GetLocationsString(IEnumerable<Location> list)
        {
            List<string> loc = new List<string>();

            foreach (var item in list)
            {
                loc.Add(item.City + ", " + item.Country);
            }

            return loc;
        }

        public ActionResult ToursPage()
        {
            SetViewBag();

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(TourViewModel model, HttpPostedFileBase image)
        {
            // 1) якщо картинка:
            //    2) зберегти картинку на сервер
            // 2.1) конвертувати картинку
            //    3) записати шлях в модель
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (image != null)
            {
                var fileName = Guid.NewGuid().ToString() + ".jpg";

                var bitmap = BitmapConvertor.Convert(image.InputStream, 200, 200);
                var serverPath = Server.MapPath($"~/Images/{fileName}");

                bitmap.Save(serverPath);
                model.Image = $"/Images/{fileName}";
                model.ImageForGallaries = new List<string>();
                model.ImageForGallaries.Add($"/Images/{fileName}");
            }

            await _tourService.AddTourAsync(_mapper.Map<Tour>(model));

            ViewBag.SuccessTourCreated = "succes";

            return RedirectToAction("ToursPage");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id)
        {
            var tour = _tourService.GetTour(id);

            await _tourService.EditTourAsync(tour);

            return View("ToursTage");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int key = (int)id;

            var tour = _tourService.GetTour(key);
            SetViewBag();
            //return View();
            return View(_mapper.Map<TourViewModel>(tour));
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = _tourService.GetAllTour(null).FirstOrDefault((x) => x.Id == id);
            if (tour == null)
            {
                return HttpNotFound();
            }

            int key = (int)id;

            await _tourService.DeleteTourAsync(key); 
            //_tourService.DeleteTourAsync(key);

            SetViewBag();

            return View("ToursPage");
        }

        public ActionResult OrderTour(int? id)
        {
            SetViewBag();
            return View();
        }


        //[HttpPost]
        //public async Task<ActionResult> OrderTour(int? id)
        //{
        //    SetViewBag();

        //    return View("ToursPage");
        //}


            public ActionResult Filter(string type, string value)
        {

            var filter = new TourFilter()
            {
                Name = value,
                Type = type
            };

            // predicate: x => x.Developer == Bogdan
            // predicate: x => x.Genre == RPG

            if (type == "location")
            {
                filter.Predicate = (x => x.Hotel == value);
            }
            else if (type == "flight_date")
            {
                filter.Predicate = (x => x.Flight.DateStart == value);
            }
            else if (type == "flight_type")
            {
                filter.Predicate = (x => x.Flight.Type == value);
            }

            var filters = new List<TourFilter>();
            if (Session["TourFilter"] != null)
            {
                filters = Session["TourFilter"] as List<TourFilter>;
            }

            //var results = filters.GroupBy(
            // p => p.Name,
            // p => p.Type,
            // (key, g) => new { PersonId = key, Cars = g.ToList() });

            var found = filters.FirstOrDefault(f => f.Name == value && f.Type == type);
            if (found != null)
            {
                filters.Remove(found);
            }
            else
            {
                filters.Add(filter);
            }

            Session["TourFilter"] = filters;

            var tours = _tourService.GetAllTour(filters);
            SetViewBag();

            return PartialView("ToursPartial", _mapper.Map<List<TourViewModel>>(tours));
        }

        private void SetViewBag()
        {
            ViewBag.Tours = _mapper.Map<List<TourViewModel>>(_tourService.GetAllTour(null));//_tourService.GetAllTour(null);



            var tours = _mapper.Map<List<TourViewModel>>(_tourService.GetAllTour(null));

            for (int i = tours.Count - 1; i >= 6; i--)
            {
                tours.RemoveAt(i);
            }

            //int temp = 0;

            //foreach (var item in _tourService.GetAllTour(null))
            //{
            //    if (temp < 6)
            //    {
            //        tours.Add(item);
            //    }

            //    temp++;
            //}

            ViewBag.SomeDemoTours = tours;

            List<string> temptry = new List<string>() { "h", "e", "l", "p" };
            ViewBag.Locactions = _tourService.GetAllLocation().Select(x => x.City + ", " + x.Country);
            ViewBag.Flights = _tourService.GetAllFlight().Select(x => x.DateStart);
            ViewBag.FlightType = _tourService.GetAllFlight().Select(x => x.Type);

            //var distinctItems = _tourService.GetAllFlight().GroupBy(x => x.Type).Select(y => y.First());
            //var query = _tourService.GetAllFlight().GroupBy(x => x.Type);

            List<string> type_fligh = CreateListWithoutDublicate(_tourService.GetAllFlight().Select(x => x.Type));
            List<string> fligh_date = CreateListWithoutDublicate(_tourService.GetAllFlight().Select(x => x.DateStart));

            ViewBag.FlightTypeFilter = type_fligh;
            ViewBag.FlightDateFilter = fligh_date;

            var gall = _tourService.GetImageForGallaries();//new List<ICollection<ImageForGallary>>();

            //foreach (var item in tours)
            //{
            //    gall.Add(item.ImageForGallaries);
            //}

            ViewBag.Gallaries = gall;

            // ViewBag.FlightForChoose = _tourService.GetAllFlight().Select(x => x.Type + " (from " + x..City + ", " + x.LocationFirstFlight.City + " at " + x.LocationResortPlace.City + ", " + x.LocationResortPlace.City+ " )"); ;
        }

        private List<string> CreateListWithoutDublicate(IEnumerable<string> collection)
        {
            var type_fligh = new List<string>();
            bool flag = true;

            if (collection == null)
            {
                return type_fligh;
            }

            foreach (var item in collection)
            {
                if (item != null)
                {
                    for (int i = 0; i < type_fligh.Count(); i++)
                    {
                        if (item.ToString() == type_fligh[i])
                        {
                            flag = false;
                        }
                    }

                    if (flag)
                    {
                        type_fligh.Add(item.ToString());
                        flag = true;
                    }
                }
            }

            return type_fligh;
        }
    }
}