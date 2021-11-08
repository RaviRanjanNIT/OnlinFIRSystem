using Dapper;
using OnlinFIRSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlinFIRSystem.Controllers
{
    public class RAISEFIRController : Controller
    {
        // GET: RAISEFIR
        public ActionResult Index()
        {
            string sqlListofFIR = "Select Id,FIRNUMBER,Name,Address,convert(varchar,DateTimeFIR,0) as DateTimeFIR," +
                                            "Location,PoliceStationId,FIRAgainst," +
                                            "Witnesses,EmailId,FIRSTATUS,PIN,PoliceStationName," +
                                            "TypeofStatus,CreatedBy," +
                                            "CreatedOn from V_FIRCompleteDetails";
            var connection = new SqlConnection(AppConnection.ConnectionString);
            {
                connection.Open();
                var ListofFIR = connection.Query<FIR>(sqlListofFIR).ToList();
                connection.Close();
                return View(ListofFIR);

            }
            //return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            var connection = new SqlConnection(AppConnection.ConnectionString);
            {
                connection.Open();

                string sqlPSList = "Select Id,PIN,PoliceStationName From T_PinPS where Status='Active'";
                var ListofFIR = connection.Query<PoliceStation>(sqlPSList).ToList();
                ViewBag.PSLIST = new SelectList(ListofFIR, "Id", "PIN");

                string sqlSTList = "Select Id,TypeofStatus From T_Status_Type where Status='Active'";
                var ListofStatus = connection.Query<StatusType>(sqlSTList).ToList();
                ViewBag.STLIST = new SelectList(ListofStatus, "Id", "TypeofStatus");

                connection.Close();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(FIR PS)
        {
            string sqlPSInsert = "INSERT INTO T_FIRDetails (FIRNUMBER,Name,Address,DateTimeFIR," +
                                 "Location,PoliceStationId,FIRAgainst,Witnesses,EmailId,FIRSTATUS," +
                                 "CreatedBy,CreatedOn) " +
                                       "Values (@FIRNUMBER,@Name,@Address,@DateTimeFIR," +
                                       "@Location,@PoliceStationId,@FIRAgainst,@Witnesses,@EmailId,@FIRSTATUS," +
                                       "@CreatedBy,@CreatedOn)";

            //var valueddl = Request.Form["PSLIST"].ToString();

            var connection = new SqlConnection(AppConnection.ConnectionString);
            {
                connection.Open();
                var affectedRows = connection.Execute(sqlPSInsert,
                    new
                    {
                        FIRNUMBER=PS.FIRNUMBER,
                        Name=PS.Name,
                        Address=PS.Address,
                        DateTimeFIR=DateTime.Now,
                        Location=PS.Location,
                        PoliceStationId= Request.Form["PSLIST"].ToString(),
                        FIRAgainst=PS.FIRAgainst,
                        Witnesses=PS.Witnesses,
                        EmailId=PS.EmailId,
                        FIRSTATUS= Request.Form["STLIST"].ToString(),
                        CreatedBy = "0",
                        CreatedOn = DateTime.Now
                    });

                //string sqlPSList = "Select Id,PIN,PoliceStationName From T_PinPS";
                //var ListofFIR = connection.Query<FIR>(sqlPSList).ToList();

                connection.Close();
                //return View(ListofFIR);

                //ViewBag.PSLIST = new SelectList(ListofFIR, "Id", "PIN");
                connection.Close();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int? Id)
        {
            string sqlFIRDetail = "Select Id,FIRNUMBER,Name,Address,convert(varchar,DateTimeFIR,0) as DateTimeFIR," +
                                            "Location,PoliceStationId,FIRAgainst," +
                                            "Witnesses,EmailId,FIRSTATUS,PIN,PoliceStationName,CreatedBy," +
                                            "CreatedOn from V_FIRCompleteDetails WHERE Id = @ID;";
            var connection = new SqlConnection(AppConnection.ConnectionString);
            {
                connection.Open();
                var PSDetail = connection.QueryFirstOrDefault<FIR>(sqlFIRDetail,
                    new { ID = Id });
                connection.Close();
                return View(PSDetail);

            }
        }

        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            string sqlPSDetail = "SELECT FIRNUMBER,Name,Address,convert(varchar,DateTimeFIR,0) as DateTimeFIR," +
                                 "Location,PoliceStationId,FIRAgainst,Witnesses,EmailId,FIRSTATUS," +
                                 "CreatedBy,CreatedOn,PoliceStationName,TypeofStatus,PIN " +
                                 "from V_FIRCompleteDetails WHERE Id = @ID";
            var connection = new SqlConnection(AppConnection.ConnectionString);
            {
                connection.Open();

                string sqlPSList = "Select Id,PIN,PoliceStationName From T_PinPS where Status='Active'";
                var ListofPS = connection.Query<PoliceStation>(sqlPSList).ToList();
                //ViewBag.PSLIST = new SelectList(ListofPS, "Id", "PIN");

                

                string sqlSTList = "Select Id,TypeofStatus From T_Status_Type where Status='Active'";
                var ListofStatus = connection.Query<StatusType>(sqlSTList).ToList();
                //ViewBag.STLIST = new SelectList(ListofStatus, "Id", "TypeofStatus");



                var PSDetail = connection.QueryFirstOrDefault<FIR>(sqlPSDetail,
                    new { ID = Id });

                ViewBag.PSLIST = new SelectList(ListofPS, "Id", "PIN", PSDetail.PIN.ToString());

                ViewBag.STLIST = new SelectList(ListofStatus, "Id", "TypeofStatus", PSDetail.TypeofStatus.ToString());


                //ListofFIR = PSDetail.PoliceStationId.ToString();

                connection.Close();

                //List<SelectListItem> selecteditems = new List<SelectListItem>();
                //foreach (PoliceStation PS in ListofPS)
                //{
                //    bool checkvalue = (PS.Id.ToString() == PSDetail.PoliceStationId.ToString());
                //        SelectListItem selecteditem = new SelectListItem
                //        {
                //            Text = PS.PoliceStationName,
                //            Value = PS.Id.ToString(),
                //            Selected = checkvalue
                //        };
                //    //selecteditems.Add(selecteditem);
                //}
                return View(PSDetail);
            }
        }

        [HttpPost]
        public ActionResult Edit(FIR PS)
        {
            string sqlEmployeeupdate = "Update T_FIRDetails set FIRNUMBER=@FIRNUMBER," +
                                        "Name=@Name,Address=@Address,DateTimeFIR=@DateTimeFIR," +
                                         "Location=@Location,PoliceStationId=@PoliceStationId," +
                                         "FIRAgainst=@FIRAgainst,Witnesses=@Witnesses,EmailId=@EmailId," +
                                         "FIRSTATUS=@FIRSTATUS," +
                                         "ModifiedBy=@ModifiedBy,ModifiedOn=@ModifiedOn " +
                                        "where Id=@ID";

            var connection = new SqlConnection(AppConnection.ConnectionString);
            {
                connection.Open();
                var affectedRows = connection.Execute(sqlEmployeeupdate,
                    new
                    {
                        ID=PS.Id,
                        FIRNUMBER = PS.FIRNUMBER,
                        Name = PS.Name,
                        Address = PS.Address,
                        DateTimeFIR = DateTime.Now,
                        Location = PS.Location,
                        PoliceStationId = Request.Form["PSLIST"].ToString(),
                        FIRAgainst = PS.FIRAgainst,
                        Witnesses = PS.Witnesses,
                        EmailId = PS.EmailId,
                        FIRSTATUS = Request.Form["STLIST"].ToString(),
                        ModifiedBy = "0",
                        ModifiedOn = DateTime.Now,
                    });
                connection.Close();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? Id)
        {
            string sqlPSDetail = "SELECT FIRNUMBER,Name,Address,convert(varchar,DateTimeFIR,0) as DateTimeFIR," +
                                 "Location,PoliceStationId,FIRAgainst,Witnesses,EmailId,FIRSTATUS," +
                                 "CreatedBy,CreatedOn from T_FIRDetails WHERE Id = @ID;";
            var connection = new SqlConnection(AppConnection.ConnectionString);
            {
                connection.Open();
                var PSDetail = connection.QueryFirstOrDefault<FIR>(sqlPSDetail,
                    new { ID = Id });
                connection.Close();
                return View(PSDetail);

            }
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {

            string sqlEmployeeDelete = "Delete from T_FIRDetails where Id=@ID";

            var connection = new SqlConnection(AppConnection.ConnectionString);
            {
                connection.Open();
                var affectedRows = connection.Execute(sqlEmployeeDelete,
                    new
                    {
                        ID = Id
                    });
                connection.Close();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult PSEntry()
        {
            string sqlPSList = "Select Id,PIN,PoliceStationName From T_PinPS";

            var connection = new SqlConnection(AppConnection.ConnectionString);
            {

                //SqlDataAdapter _da = new SqlDataAdapter("Select Id,PIN,PoliceStationName From T_PinPS", connection);
                //DataTable _dt = new DataTable();
                //_da.Fill(_dt);

                connection.Open();
                var ListofFIR = connection.Query<FIR>(sqlPSList).ToList();
                connection.Close();
                //return View(ListofFIR);

                ViewBag.PSLIST = new SelectList(ListofFIR, "Id", "PIN");
                return View();
            }

            //return View();
        }
    }
}