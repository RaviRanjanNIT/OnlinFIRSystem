using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace OnlinFIRSystem.Models
{
    public static class DapperORM
    {
        public static string ConnectionString => ConfigurationManager.ConnectionStrings["constring"].ConnectionString;

        public static void ExecuteWithoutReturn(string prcocedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                sqlCon.Execute(prcocedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }

        }

        //DapperORM.ExecuteReturnScalar<int>(_,_);
        public static T ExecuteReturnScalar<T>(string prcocedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                return (T)Convert.ChangeType(sqlCon.Execute(prcocedureName, param, commandType: System.Data.CommandType.StoredProcedure),typeof(T));
            }

        }

        //DapperORM.ReturnList<modelclass> <=IEnumerable<modelclass>
        public static IEnumerable<T> ReturnList<T>(string prcocedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                return sqlCon.Query<T>(prcocedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }

        }

    }
}