using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient; //Required for ADO.NET object model
using System.Configuration; //Required for Configuration Manager

namespace Lab1_ASPNetConnectedMode.DAL
{
    public class UtilityDB
    {
        public static SqlConnection ConnectDB()
        {
            //Version 1: Working but not secure
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"server=DESKTOP-0QBGSKA\SQLEXPRESS;database=EmployeeDB;user=sa;password=CC55b847";
            conn.Open();
            return conn;

            

        }
        public static SqlConnection ConnectionDB()
        {
            //Version 2:In testing
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectEmployeeDB"].ConnectionString;
            conn.Open();
            return conn;
        }
    }
}