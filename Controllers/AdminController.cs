using Dapper;
using OnlinFIRSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlinFIRSystem.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        //[Authorize]
        public ActionResult Index()
        {
            string sqlListofPolicestation = "Select Id,PIN,PoliceStationName,Status,CreatedBy," +
                                            "CreatedOn,ModifiedBy,ModifiedOn from T_PinPS";
            var connection = new SqlConnection(AppConnection.ConnectionString);
            {
                connection.Open();
                var ListofPolicestation = connection.Query<PoliceStation>(sqlListofPolicestation).ToList();
                connection.Close();
                return View(ListofPolicestation);

            }
            //return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PoliceStation PS)
        {
            string sqlPSInsert = "INSERT INTO T_PinPS (PIN,PoliceStationName,Status,CreatedBy,CreatedOn) " +
                                       "Values (@PIN,@PoliceStationName,@Status,@CreatedBy,@CreatedOn)";

            var connection = new SqlConnection(AppConnection.ConnectionString);
            {
                connection.Open();
                var affectedRows = connection.Execute(sqlPSInsert,
                    new
                    {
                        PIN = PS.PIN,
                        PoliceStationName = PS.PoliceStationName,
                        Status = PS.Status,
                        CreatedBy = "0",
                        CreatedOn = DateTime.Now,
                    });
                connection.Close();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int? Id)
        {
            string sqlPSDetail = "SELECT Id,PIN,PoliceStationName,Status FROM T_PinPS WHERE Id = @ID";
            var connection = new SqlConnection(AppConnection.ConnectionString);
            {
                connection.Open();
                var PSDetails = connection.QueryFirstOrDefault<PoliceStation>(sqlPSDetail,
                    new { ID = Id });
                connection.Close();
                return View(PSDetails);

            }
        }

        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            string sqlPSDetail = "SELECT PIN,PoliceStationName,Status FROM T_PinPS WHERE Id = @ID";
            var connection = new SqlConnection(AppConnection.ConnectionString);
            {
                connection.Open();
                var PSDetail = connection.QueryFirstOrDefault<PoliceStation>(sqlPSDetail,
                    new { ID = Id });
                connection.Close();
                return View(PSDetail);
            }
        }

        [HttpPost]
        public ActionResult Edit(PoliceStation PS)
        {
            string sqlEmployeeupdate = "Update T_PinPS set PIN=@PIN," +
                                        "PoliceStationName=@PoliceStationName," +
                                        "Status=@Status, " +
                                        "ModifiedBy=@ModifiedBy,ModifiedOn=@ModifiedOn " +
                                        "where Id=@ID";

            var connection = new SqlConnection(AppConnection.ConnectionString);
            {
                connection.Open();
                var affectedRows = connection.Execute(sqlEmployeeupdate,
                    new
                    {
                        ID=PS.Id,
                        PIN = PS.PIN,
                        PoliceStationName = PS.PoliceStationName,
                        Status = PS.Status,
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
            string sqlPSDetail = "SELECT Id,PIN,PoliceStationName,Status FROM T_PinPS WHERE Id = @ID;";
            var connection = new SqlConnection(AppConnection.ConnectionString);
            {
                connection.Open();
                var PSDetail = connection.QueryFirstOrDefault<PoliceStation>(sqlPSDetail,
                    new { ID = Id });
                connection.Close();
                return View(PSDetail);

            }
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {

            string sqlEmployeeDelete = "Delete from T_PinPS where Id=@ID";

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
    }
}