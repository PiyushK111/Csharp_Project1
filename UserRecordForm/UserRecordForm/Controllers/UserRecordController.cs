using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
/*using UserRecordForm.Models.UserRecord;*/
using UserRecordForm.DataAccess;
using UserRecordForm.Models;
using System.Text.RegularExpressions;

namespace UserRecordForm.Controllers
{

    public class UserRecordController : Controller
    {

/*        private readonly ILogger<UserRecordController> _logger;
*/
        // GET: UserRecord

       /* public UserRecordController(ILogger<UserRecordController> logger)
        {
            _logger = logger;   
        }*/


        public ActionResult InsertUser(UserRecord model)
        {

            if (String.IsNullOrEmpty(model.firstName))
            {
                ModelState.AddModelError("FirstName", "FirstName is required");
            }
            /*
            if (String.IsNullOrEmpty(model.lastName))
            {
                ModelState.AddModelError("lastName", "lastName is required");
            }
           
            if (string.IsNullOrEmpty(model.email))
            {
                ModelState.AddModelError("Email", "Email is required.");
            }
            else if (!IsValidEmail(model.email))
            {
                ModelState.AddModelError("Email", "Invalid email format.");
            }
            if (String.IsNullOrEmpty(model.username))
            {
                ModelState.AddModelError("username", "username is required");
            }
            if (String.IsNullOrEmpty(model.mnumber))
            {
                ModelState.AddModelError("Mobile Number", "Mobile Number is required");
            }
            if (String.IsNullOrEmpty(model.password))
            {
                ModelState.AddModelError("Password", "Password is required");
            }
            if (String.IsNullOrEmpty(model.address))
            {
                ModelState.AddModelError("Address", "Address is required");
            }
            if (String.IsNullOrEmpty(model.address))
            {
                ModelState.AddModelError("Address", "Address is required");
            }
            if (String.IsNullOrEmpty(model.ssc_total_mark.ToString()))
            {
                ModelState.AddModelError("ssc_total_mark", "Total Marks is required");
            }
            if (String.IsNullOrEmpty(model.ssc_obtained_mark.ToString()))
            {
                ModelState.AddModelError("ssc_obtained_mark", "Obtained Marks is required");
            }

*/

            if (ModelState.IsValid)
            {
                DataAccessLayer objDB = new DataAccessLayer();
                string result = objDB.InsertData(model);
                TempData["result1"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
               
            }

            return View(model);
        }

        private bool IsValidEmail(string email)
        {
          
            return Regex.IsMatch(email, @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,4}\b");
        }

        /*public ActionResult InsertUser()
        {
            return View();
        }*/

        /* [HttpPost]
         public JsonResult InsertUser(UserRecord objuser)

         {
 *//*            _logger.LogInformation("This is an informational log message in index Method.");
 *//*
             DataAccessLayer objDB = new DataAccessLayer();
             string result = objDB.InsertData(objuser);
             TempData["result1"] = result;
             return Json(result, JsonRequestBehavior.AllowGet);

         }*/

        [HttpGet]
      
        public ActionResult ViewAll(string sortBy,int Page, int? pageSize, string searchText = "")
        {

/*            _logger.LogInformation("This is an informational log message in View All Method.");
*/
            UserRecord rec = new UserRecord();
            DataAccessLayer objDB = new DataAccessLayer();

            if (searchText =="" || searchText==null)
            
            {

                int itemsPerPage = pageSize ?? 4 ;
                /*int currentPage = Convert.ToInt32(Page);*/
                int currentPage = Page;
                int skipCount = (currentPage - 1) * itemsPerPage;
                /*rec.showAllRecords = objDB.ViewAllUser();*/
                rec.showAllRecords = objDB.paginationView( itemsPerPage, skipCount);

                ViewBag.UserIdSortParm = String.IsNullOrEmpty(sortBy) ? "userId_desc" : "";
                ViewBag.NameSortParm = sortBy == "name" ? "name_desc" : "name";
                ViewBag.addressSortParm = sortBy == "address" ? "address_desc" : "address";
                ViewBag.markSortParm = sortBy == "ssc_obtained_mark" ? "marks_desc" : "ssc_obtained_mark";
                ViewBag.ageSortParm = sortBy == "age" ? "age_desc" : "age";
                ViewBag.lastNameParm = sortBy == "lastName" ? "lastName_desc" : "lastName";
                ViewBag.PageSize = itemsPerPage;
                switch (sortBy)
                {

                    case "name_desc":
                        rec.sortedList = rec.showAllRecords.OrderByDescending(u => u.firstName).ToList();
                        break;
                    case "name":
                        rec.sortedList = rec.showAllRecords.OrderBy(u => u.firstName).ToList();
                        break;
                    case "lastName_desc":
                        rec.sortedList = rec.showAllRecords.OrderByDescending(u => u.lastName).ToList();
                        break;
                    case "lastName":
                        rec.sortedList = rec.showAllRecords.OrderBy(u => u.lastName).ToList();
                        break;
                    case "age_desc":
                        rec.sortedList = rec.showAllRecords.OrderByDescending(u => u.age).ToList();
                        break;
                    case "age":
                        rec.sortedList = rec.showAllRecords.OrderBy(u => u.age).ToList();
                        break;
                    case "address_desc":
                        rec.sortedList = rec.showAllRecords.OrderByDescending(u => u.address).ToList();
                        break;
                    case "address":
                        rec.sortedList = rec.showAllRecords.OrderBy(u => u.address).ToList();
                        break;
                    case "marks_desc":
                        rec.sortedList = rec.showAllRecords.OrderByDescending(u => u.ssc_obtained_mark).ToList();
                        break;
                    case "ssc_obtained_mark":
                        rec.sortedList = rec.showAllRecords.OrderBy(u => u.ssc_obtained_mark).ToList();
                        break;
                    
                    case "userId_desc":
                        rec.sortedList = rec.showAllRecords.OrderByDescending(u => u.userId).ToList();
                        break;
                    default:
                        rec.sortedList = rec.showAllRecords.OrderBy(u => u.userId).ToList();
                        break;
                }


                Console.WriteLine("after exception");
                ViewBag.currentPage = currentPage;
                ViewBag.itemsPerPage = itemsPerPage;
                ViewBag.skipCount = skipCount;

                int totalRecords = objDB.totalReocordCount();
                int totalPages = (int)Math.Ceiling((double)totalRecords / itemsPerPage);

                ViewBag.totalPages = totalPages;

                return View(rec);

            }
            else  {

                ViewBag.NameSortParm = String.IsNullOrEmpty(sortBy) ? "name_desc" : "";
                ViewBag.addressSortParm = sortBy == "address" ? "address_desc" : "address";
                ViewBag.markSortParm = sortBy == "ssc_obtained_mark" ? "marks_desc" : "ssc_obtained_mark";
                ViewBag.markSortParm = sortBy == "age" ? "age_desc" : "age";
                ViewBag.searchText = searchText;


                rec.showAllRecords = objDB.ViewSearchResult(searchText);

                switch (sortBy)
                {
                    case "name_desc":
                        rec.sortedList = rec.showAllRecords.OrderByDescending(u => u.firstName).ToList();
                        break;
                    case "address_desc":
                        rec.sortedList = rec.showAllRecords.OrderByDescending(u => u.address).ToList();
                        break;
                    case "address":
                        rec.sortedList = rec.showAllRecords.OrderBy(u => u.address).ToList();
                        break;
                    case "marks_desc":
                        rec.sortedList = rec.showAllRecords.OrderByDescending(u => u.ssc_obtained_mark).ToList();
                        break;
                    case "ssc_obtained_mark":
                        rec.sortedList = rec.showAllRecords.OrderBy(u => u.ssc_obtained_mark).ToList();
                        break;
                    default:
                        rec.sortedList = rec.showAllRecords.OrderBy(u => u.firstName).ToList();
                        break;
                }
                return View(rec);
            }

        }

/*
        [HttpPost]
        [ActionName("ViewSearch")]

        public ActionResult ViewAll(string searchText)
        {
            DataAccessLayer objDb = new DataAccessLayer();
            UserRecord rec = new UserRecord();
            rec.showAllRecords = objDb.ViewSearchResult(searchText);
            return View("ViewAll", rec);
        }*/



        [HttpGet]
        public ActionResult DeleteUser(int userId,int Page)
        {
            DataAccessLayer objDb = new DataAccessLayer();
            if (objDb.DeleteUser(userId)) { 
                ViewBag.AlertMsg = "Student deleted Successfully";
               }
            ModelState.Clear();
            return RedirectToAction("ViewAll",new { Page = Page});
        }
        [HttpGet]
        public ActionResult EditUser(int userId)
        {
            DataAccessLayer objDb = new DataAccessLayer();
            
            return View(objDb.ViewAllUser().Find(model => model.userId == userId));
        }

        [HttpPost]
        public ActionResult EditUser(UserRecord umodel)
        {
            try
            {
                DataAccessLayer objDb = new DataAccessLayer();
                objDb.UpdateDetails(umodel);
                return RedirectToAction("InsertUser");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
            
        }
    }
}


/*try
{
    int i = 2;
    int result = i / 0;
}
catch(Exception ex)
{
    Logger logger = LogManager.GetCurrentClassLogger();
    logger.Error("Yoo", ex);

}*/