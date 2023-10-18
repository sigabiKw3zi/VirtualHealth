using VB.Data;
using VB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
//using PagedList;
//using System.Web;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using Syncfusion.EJ2.FileManager.Base;
//using X.PagedList;
//using System.Web.Mvc;
//using System.Data.Entity;

namespace VB.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public BookingController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ActionResult Index(int page = 1, int pageSize = 10)
        {

            var totalItems = dbContext.Bookings.Count();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var pagedBookings = dbContext.Bookings
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var viewModel = new PagedViewModel<Bookings>
            {
                Items = pagedBookings,
                CurrentPage = page,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = totalPages
            };

            return View(viewModel);

        }
		
		public IActionResult Create(Bookings bookings)
        {
			if (ModelState.IsValid)
			{
				// Save the new booking to the database
				dbContext.Bookings.Add(bookings);
				dbContext.SaveChanges();

				// Redirect to the index page or any other appropriate page
				return RedirectToAction("Index");
			}

			// If ModelState is not valid, redisplay the Create view with validation errors
			return View("Create", bookings);
		}


        public ActionResult Edit(int id)
        {
            var booking = dbContext.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }

            // Pass the booking to the edit view
            return View("Edit", booking);
        }


        [HttpPost]
        public ActionResult Edit(Bookings booking)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(booking).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            // If the model is not valid, return to the edit view
            return View(booking);
        }

        public ActionResult Delete(int id)
        {
            var booking = dbContext.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }

            // Pass the booking to the delete view
            return View(booking);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            var booking = dbContext.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }

            dbContext.Bookings.Remove(booking);
            dbContext.SaveChanges();
            return RedirectToAction("FrontBar");
        }

        public IActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(string receiver, string subject, string message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("jamilmoughal786@gmail.com", "Jamil");
                    var receiverEmail = new MailAddress(receiver, "Receiver");
                    var password = "Your Email Password here";
                    var sub = subject;
                    var body = message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }
        public IActionResult FrontBar()
        {
            return View();
        }

        public IActionResult CalenderC()
        {
            return View();
        }



    }
        //public ActionResult Index()
        //{
        //    //var pagedItems = _allItems.Skip((page - 1) * pageSize).Take(pageSize);
        //    //var pagingInfo = new PagingInfo
        //    //{
        //    //    PageNumber = page,
        //    //    PageSize = pageSize,
        //    //    TotalItems = _allItems.Count
        //    //};

        //    //var viewModel = new ItemViewModel
        //    //{
        //    //    Bookings = pagedItems,
        //    //    PagingInfo = pagingInfo
        //    //};

        //    //return View(viewModel);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
       
 
}
