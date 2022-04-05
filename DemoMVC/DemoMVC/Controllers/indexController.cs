using DemoMVC.commonhelper;
using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class indexController : Controller
    {

        DBUserMaster DUMC = new DBUserMaster();
        // GET: index
        public ActionResult createnewaccount()
        {
            return View();
        }

        public ActionResult UserRecord()
        {
            return View();
        }

        public ActionResult chartview()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateNewAccount1(int Id, string FirstName, string LastName, string ContactNo, string EmailId, string Password, char Gender)
        {
            int flag = 0;
            insertrecord U = new insertrecord();
            {
                U.Id = Id;
                U.FirstName = FirstName;
                U.LastName = LastName;
                U.ContactNo = ContactNo;
                U.EmailId = EmailId;
                U.Password = Password;
                U.Gender = Gender;
                U.Status = 'Y';
            };

            flag = DUMC.InsertUserData(U);

            if (flag == 1)
            {
                var result = new { Success = "Success", Message = "Data Inserted Successfully..!!" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = new { Success = "False", Message = "Error Message" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetUserData(string OrderBy, string WhereClause)
        {
            List<insertrecord> ULst = new List<insertrecord>();
            ULst = DUMC.GetUserData(OrderBy, WhereClause);
            return Json(new { data = ULst }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult UpdateUserStatus(int Id, char Status)
        {
            int flag = 0;
            insertrecord U = new insertrecord();
            {
                U.Id = Id;
                U.Status = Status;
            };

            flag = DUMC.UpdateUserStatus(U);
            if (flag == 1)
            {
                var result = new { Success = "Success", Message = "Status Updated Successfully..!!" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = new { Success = "False", Message = "Error Message" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ChartCall(string SelectAsLabel, string GroupBy)
        {
            List<Chartresponsemodel> UList = new List<Chartresponsemodel>();
            UList = DUMC.GetUserChartData(SelectAsLabel, GroupBy);
            return Json(new { data = UList }, JsonRequestBehavior.AllowGet);
        }

    }

}
