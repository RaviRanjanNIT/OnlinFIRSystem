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
    public class StatusTypeController : Controller
    {
        // GET: StatusType
        //public ActionResult Index()
        //{
        //    string sqlListofStatusType = "Select Id,TypeofStatus,Status,CreatedBy," +
        //                                    "CreatedOn,ModifiedBy,ModifiedOn from T_Status_Type";
        //    var connection = new SqlConnection(AppConnection.ConnectionString);
        //    {
        //        connection.Open();
        //        var ListofStatusType = connection.Query<StatusType>(sqlListofStatusType).ToList();
        //        connection.Close();
        //        return View(ListofStatusType);

        //    }
        //    //return View();
        //}

        public ActionResult Index()
        {
            return View(DapperORM.ReturnList<StatusType>("_usp_T_Status_Type_Details"));
        }
        [HttpGet]
        public ActionResult Create(int id=0)
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Create(StatusType ST)
        //{
        //    string sqlSTInsert = "INSERT INTO T_Status_Type (TypeofStatus,Status,CreatedBy,CreatedOn) " +
        //                               "Values (@TypeofStatus,@Status,@CreatedBy,@CreatedOn);";

        //    var connection = new SqlConnection(AppConnection.ConnectionString);
        //    {
        //        connection.Open();
        //        var affectedRows = connection.Execute(sqlSTInsert,
        //            new
        //            {
        //                TypeofStatus = ST.TypeofStatus,
        //                Status = ST.Status,
        //                CreatedBy = "0",
        //                CreatedOn = DateTime.Now,
        //            });
        //        connection.Close();
        //    }
        //    return RedirectToAction("Index");
        //}
        [HttpPost]
        public ActionResult Create(StatusType ST)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", ST.Id);
            param.Add("@TypeofStatus", ST.TypeofStatus);
            param.Add("@Status",ST.Status);
            param.Add("@CreatedBy",0);
            param.Add("@ModifiedBy", 0);
            DapperORM.ExecuteWithoutReturn("_usp_T_Status_Type_AddOrEdit", param);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int? Id)
        {
            //string sqlSTDetail = "SELECT Id,TypeofStatus,Status FROM T_Status_Type WHERE Id = @ID;";
            //var connection = new SqlConnection(AppConnection.ConnectionString);
            //{
            //    connection.Open();
            //    var STDetail = connection.QueryFirstOrDefault<StatusType>(sqlSTDetail,
            //        new { ID = Id });
            //    connection.Close();
            //    return View(STDetail);

            //}

            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", Id);
            return View(DapperORM.ReturnList<StatusType>("_usp_T_Status_Type_ViewById", param).FirstOrDefault<StatusType>());
        }

        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            //string sqlSTDetail = "SELECT TypeofStatus,Status FROM T_Status_Type WHERE Id = @ID;";
            //var connection = new SqlConnection(AppConnection.ConnectionString);
            //{
            //    connection.Open();
            //    var STDetail = connection.QueryFirstOrDefault<StatusType>(sqlSTDetail,
            //        new { ID = Id });
            //    connection.Close();
            //    return View(STDetail);
            //}
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", Id);
            return View(DapperORM.ReturnList<StatusType>("_usp_T_Status_Type_ViewById", param).FirstOrDefault<StatusType>());
        }

        [HttpPost]
        public ActionResult Edit(StatusType ST)
        {
            //string sqlEmployeeupdate = "Update T_Status_Type set TypeofStatus=@TypeofStatus," +
            //                            "Status=@Status, " +
            //                            "ModifiedBy=@ModifiedBy,ModifiedOn=@ModifiedOn " +
            //                            "where Id=@ID";

            //var connection = new SqlConnection(AppConnection.ConnectionString);
            //{
            //    connection.Open();
            //    var affectedRows = connection.Execute(sqlEmployeeupdate,
            //        new
            //        {
            //            ID = ST.Id,
            //            TypeofStatus = ST.TypeofStatus,
            //            Status = ST.Status,
            //            ModifiedBy = "0",
            //            ModifiedOn = DateTime.Now,
            //        });
            //    connection.Close();
            //}
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", ST.Id);
            param.Add("@TypeofStatus", ST.TypeofStatus);
            param.Add("@Status", ST.Status);
            param.Add("@CreatedBy", 0);
            param.Add("@ModifiedBy", 0);
            DapperORM.ExecuteWithoutReturn("_usp_T_Status_Type_AddOrEdit", param);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? Id)
        {
            //string sqlSTDetail = "SELECT Id,TypeofStatus,Status FROM T_Status_Type WHERE Id = @ID;";
            //var connection = new SqlConnection(AppConnection.ConnectionString);
            //{
            //    connection.Open();
            //    var STDetail = connection.QueryFirstOrDefault<StatusType>(sqlSTDetail,
            //        new { ID = Id });
            //    connection.Close();
            //    return View(STDetail);

            //}
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", Id);
            return View(DapperORM.ReturnList<StatusType>("_usp_T_Status_Type_ViewById", param).FirstOrDefault<StatusType>());
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {

            //string sqlTypeDelete = "Delete from T_Status_Type where Id=@ID";

            //var connection = new SqlConnection(AppConnection.ConnectionString);
            //{
            //    connection.Open();
            //    var affectedRows = connection.Execute(sqlTypeDelete,
            //        new
            //        {
            //            ID = Id
            //        });
            //    connection.Close();
            //}
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", Id);
            DapperORM.ExecuteWithoutReturn("_usp_T_Status_Type_DeleteById", param);
            return RedirectToAction("Index");
        }
    }
}