using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
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

            await _tourService.AddLocationAsync(_mapper.Map<Location>(model));

            ViewBag.SuccessLocationCreated = "succes";

            return RedirectToAction("Index");
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
            }

            await _tourService.AddTourAsync(_mapper.Map<Tour>(model));

            ViewBag.SuccessTourCreated = "succes";

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var tour = _tourService.GetTour(id);
            return View(_mapper.Map<TourViewModel>(tour));
        }

        [HttpPost]
        public ActionResult Edit()
        {
            return View();
        }

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
            else if (type == "flightcitystart")
            {
                filter.Predicate = (x => x.Flight.FlightDateToBegan == value);
            }
            else if (type == "flighttype")
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

            var games = _tourService.GetAllTour(filters);
            SetViewBag();

            return PartialView("ToursPartial", _mapper.Map<List<TourViewModel>>(games));
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
            ViewBag.Flights = _tourService.GetAllFlight().Select(x => x.FlightDateToBegan);
            ViewBag.FlightType = _tourService.GetAllFlight().Select(x => x.Type);

            var gall = _tourService.GetImageForGallaries();//new List<ICollection<ImageForGallary>>();

            //foreach (var item in tours)
            //{
            //    gall.Add(item.ImageForGallaries);
            //}

            ViewBag.Gallaries = gall;

            // ViewBag.FlightForChoose = _tourService.GetAllFlight().Select(x => x.Type + " (from " + x..City + ", " + x.LocationFirstFlight.City + " at " + x.LocationResortPlace.City + ", " + x.LocationResortPlace.City+ " )"); ;
        }
    }
}