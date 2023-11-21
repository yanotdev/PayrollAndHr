using Payroll_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Payroll_Application.Controllers
{
    public class HumanResourceController : Controller
    {
        MyDbContext db = new MyDbContext();
        // GET: HumanResource
        public ActionResult Index()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var List = db.Leaves;

            return View(List);

        }


        // GET: HumanResource/Create
        [ActionName("Create")]
        [HttpGet]
        public ActionResult CreateLeave()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: HumanResource/Create
        [ActionName("Create")]
        [HttpPost]
        public ActionResult CreateLeave(LeaveEntity model)
        {
            try
            {
                if (Session["Username"] == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                model.Created = DateTime.Now;
                model.Updated = DateTime.Now;

                db.Leaves.Add(model);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return View();
            }
            return View();
        }

        // GET: HumanResource/Edit/1
        [ActionName("Edit")]
        [HttpGet]
        public ActionResult EditLeave(int? id)
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveEntity leave = db.Leaves.Find(id);
            if (leave == null)
            {
                return HttpNotFound();
            }
            return View(leave);
        }

        // POST: HumanResource/Edit/1
        [ActionName("Edit")]
        [HttpPost]
        public ActionResult EditLeave(LeaveEntity model)
        {
            try
            {
                if (Session["Username"] == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                // TODO:  Edit logic here

                var app = db.Leaves;
                LeaveEntity dba = db.Leaves.FirstOrDefault(d => d.ID == model.ID);
                dba.StaffName = model.StaffName;
                dba.LeaveType = model.LeaveType;
                dba.FromDate = model.FromDate;
                dba.ToDate = model.ToDate;
                dba.NoDays = model.NoDays;
                dba.Recall = model.Recall;
                dba.Balance = model.Balance;
                dba.Reason = model.Reason;
                dba.Remark = model.Remark;
                dba.Reason = model.Reason;
                dba.Created = model.Created;
                dba.Updated = model.Updated;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return View();
        }


        // GET: HumanResource/Delete
        [ActionName("Delete")]
        [HttpGet]
        public ActionResult DeleteLeave(int? id)
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveEntity leave = db.Leaves.Find(id);
            if (leave == null)
            {
                return HttpNotFound();
            }
            return View(leave);
        }

        // POST: HumanResource/Delete/1
        [ActionName("Delete")]
        [HttpPost]
        public ActionResult DeleteLeave(LeaveEntity model)
        {
            try
            {
                if (Session["Username"] == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                var app = db.Leaves;
                LeaveEntity dba = db.Leaves.FirstOrDefault(d => d.ID == model.ID);
                db.Leaves.Remove(model);
                db.SaveChanges();
                //  return View(apps);
                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                return View();
            }
        }

    public ActionResult LeaveMod()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult LoanMod()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        //Approve Leave
        [HttpPost]
        public ActionResult ApproveLeave(int ID)
        {
            bool check = false; string desc = "";
            try
            {
                var data = db.Leaves.Where(d => d.ID == ID).FirstOrDefault();
                if (data != null)
                {
                    check = true;
                }
                var aLeave = db.Leaves.Where(d => d.ID == ID).FirstOrDefault();
                if (aLeave != null)
                {
                    if (check)
                    {
                        aLeave.Status = true;
                        aLeave.IsDeclined = false;
                    }
                    else
                    {
                        db.Leaves.Remove(aLeave);
                    }

                }
            }
            catch (Exception ex)
            {
                desc = ex.Message;
                check = false;
            }
            db.SaveChanges();
            return new JsonResult { Data = new { Status = check, Desc = desc } };
        }

        [HttpPost]
        public ActionResult DeclineLeave(int ID)
        {
            bool check = false; string desc = "";
            try
            {
                var data = db.Leaves.Where(d => d.ID == ID).FirstOrDefault();
                if (data != null)
                {
                    check = true;
                }
                var aLeave = db.Leaves.Where(d => d.ID == ID).FirstOrDefault();
                if (aLeave != null)
                {
                    if (check)
                    {
                        aLeave.Status = false;
                        aLeave.IsDeclined = true;
                    }
                    else
                    {
                        db.Leaves.Remove(aLeave);
                    }

                }
            }
            catch (Exception ex)
            {
                desc = ex.Message;
                check = false;
            }
            db.SaveChanges();
            return new JsonResult { Data = new { Status = check, Desc = desc } };
        }

        //Load Pending Leave
        [HttpGet]
        public ActionResult LoadPendingLea()
        {
            var data = db.Leaves.Where(d => d.Status == false && d.IsDeclined == false).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //Load Approve Leave
        [HttpGet]
        public ActionResult LoadApproveLea()
        {
            var data = db.Leaves.Where(d => d.Status == true && d.IsDeclined == false).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //Load Declined Leave
        [HttpGet]
        public ActionResult LoadDeclineLea()
        {
            var data = db.Leaves.Where(d => d.IsDeclined == true && d.Status == false).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //Delete Leave
        [HttpPost]
        public ActionResult DeleteLeave(int ID)
        {
            bool check = false; string desc = "";
            var emp = db.Leaves.Where(d => d.ID == ID).FirstOrDefault();
            try {
                db.Leaves.Remove(emp);
                check = true;
            }
            catch(Exception ex)
            {
                desc = ex.Message;
                check = false;
            }
            db.SaveChanges();
            return new JsonResult { Data = new { Status = check, Desc = desc } };
        }

        //Loading Loan
        [HttpGet]
        public ActionResult LoadLoan()
        {
            var data = db.Messages.Where(d => d.IsLoan == true).ToList().FirstOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //Delete Leave
        [HttpPost]
        public ActionResult DeleteLoan(int ID)
        {
            bool check = false; string desc = "";
            var emp = db.Messages.Where(d => d.ID == ID && d.IsLoan == true).FirstOrDefault();
            try
            {
                db.Messages.Remove(emp);
                check = true;
            }
            catch (Exception ex)
            {
                desc = ex.Message;
                check = false;
            }
            db.SaveChanges();
            return new JsonResult { Data = new { Status = check, Desc = desc } };
        }
    }
}