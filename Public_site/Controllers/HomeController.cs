using Microsoft.AspNet.Identity;
using Public_site.Models;
using RwaLib.DAL;
using RwaLib.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Public_site.Controllers
{

    public class HomeController : Controller
    {
        private IRepo _repo;
        public HomeController()
        {
            _repo = RepoFactory.GetRepo();
        }

        public ActionResult Index(string sortedBy)
        {
            IList<ApartmentPicture> apartmentPictures = new List<ApartmentPicture>();
            apartmentPictures = _repo.GetApartmentPictures().Where(p => p.IsRepresentative).ToList();

            IList<Apartment> apartments = new List<Apartment>();
            apartments = _repo.GetAllApartments();

            if (sortedBy == "Default")
                apartments = apartments.OrderBy(a => a.Id).ToList();
            else if (sortedBy == "Asc")
                apartments = apartments.OrderBy(a => a.Name).ToList();
            else if (sortedBy == "Desc")
                apartments = apartments.OrderByDescending(a => a.Name).ToList();

            ViewBag.apartmentPictures = apartmentPictures;
            ViewBag.apartments = apartments;
            ViewBag.sort = sortedBy;

            return View();
        }

        [HttpGet]
        public ActionResult ApartmentPage(int apartmentId)
        {
            IList<ApartmentPicture> apartmentPictures = _repo.GetApartmentPicturesByID(apartmentId);
            Apartment apartment = _repo.GetApartmentByID(apartmentId);
            ViewBag.apartmentPictures = apartmentPictures;
            ViewBag.apartmentId = apartmentId;
            ViewBag.apartment = apartment;
            ViewBag.tags = _repo.GetApartmentTags(apartmentId);
            ViewBag.apartmentOwner = _repo.GetApartmentOwnerById(apartment.OwnerId).ToString();

            return View();
        }


        [HttpPost]
        public ActionResult Index(int rooms = 0, int adults = 0, int children = 0)
        {

            IList<Apartment> apartments = new List<Apartment>();
            apartments = _repo.GetAllApartments();

            if (rooms != 0 && adults != 0 && children != 0)
            {
                ViewBag.apartments = apartments.Where(a => a.TotalRooms == rooms && a.MaxAdults == adults && a.MaxChildren == children).ToList();
                ViewBag.apartmentPictures = _repo.GetApartmentPictures();
            }
            else if (rooms != 0 && adults != 0)
            {
                ViewBag.apartments = apartments.Where(a => a.TotalRooms == rooms && a.MaxAdults == adults).ToList();
                ViewBag.apartmentPictures = _repo.GetApartmentPictures();
            }
            else if (rooms != 0 && children != 0)
            {
                ViewBag.apartments = apartments.Where(a => a.MaxChildren == children && a.TotalRooms == rooms).ToList();
                ViewBag.apartmentPictures = _repo.GetApartmentPictures();
            }
            else if (adults != 0 && children != 0)
            {
                ViewBag.apartments = apartments.Where(a => a.MaxAdults == adults && a.MaxChildren == children).ToList();
                ViewBag.apartmentPictures = _repo.GetApartmentPictures();
            }
            else if (children != 0)
            {
                ViewBag.apartments = apartments.Where(a => a.MaxChildren == children).ToList();
                ViewBag.apartmentPictures = _repo.GetApartmentPictures();
            }
            else if (adults != 0)
            {
                ViewBag.apartments = apartments.Where(a => a.MaxAdults == adults).ToList();
                ViewBag.apartmentPictures = _repo.GetApartmentPictures();
            }
            else if (rooms != 0)
            {
                ViewBag.apartments = apartments.Where(a => a.TotalRooms == rooms).ToList();
                ViewBag.apartmentPictures = _repo.GetApartmentPictures();
            }


            return View();
        }


        [HttpPost]
        public ActionResult SendReservation(int aptId, string fname, string lname, string email, string phone ,int adults, int children, DateTime fromDate, DateTime toDate)
        {
            Reservation reservation = new Reservation()
            {
                ApartmentId = aptId,
                FirstName = fname,
                LastName = lname,
                Email = email,
                Phone = phone,
                Adults = adults,
                Children = children,
                DateFrom = fromDate,
                DateTo = toDate
            };
            _repo.CreateNewPublicReservation(reservation);
           
            return RedirectToAction("ApartmentPage", "Home", new { apartmentId = aptId });
        }

        [HttpPost]
        public ActionResult SendReview(int aptId, int stars, string desc, int userId)
        {
            Review review = new Review()
            {
                apartmentId=aptId,
                stars=stars,
                description=desc,
                userId = userId
            };           

            _repo.CreateNewReview(review);

            return RedirectToAction("ApartmentPage", "Home", new { apartmentId = aptId });
        }

    }
}