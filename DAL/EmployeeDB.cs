using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Lab1_ASPNetConnectedMode.BLL;

namespace Lab1_ASPNetConnectedMode.DAL
{
    public class EmployeeDB
    {
        public static void SaveRecord(Employee emp)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;

            // cmd.CommandText = "INSERT INTO Employees " +
            // "VALUES (" +  emp.EmployeeId + ",'" +
            //                      emp.FirstName + "','" +
            //                   emp.LastName + "','" +
            //                emp.JobTitle + "')";

            cmd.CommandText = "Insert Into Employees (EmployeeId, FirstName, LastName, JobTitle)" +
                "VALUES(@EmployeeId, @FirstName, @LastName, @JobTitle)";
            cmd.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
            cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmd.Parameters.AddWithValue("@LastName", emp.LastName);
            cmd.Parameters.AddWithValue("@JobTitle", emp.JobTitle);
            cmd.ExecuteNonQuery();
            connDB.Close();
            connDB.Dispose();
        }

        public static void UpdateRecord(Employee emp)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdUpdate = new SqlCommand();

            cmdUpdate.Connection = conn;
            cmdUpdate.CommandText = "UPDATE Employees " +
                "Set FirstName = '" + emp.FirstName + "', LastName = '" + emp.LastName + "', JobTitle = '" + emp.JobTitle + "' " +
                "Where EmployeeId = " + emp.EmployeeId + ";";
            cmdUpdate.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }

        public static void DeleteRecord(Employee emp)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.Connection = conn;
            cmdDelete.CommandText = "DELETE FROM Employees WHERE EmployeeId = " + emp.EmployeeId + ";";
            cmdDelete.ExecuteNonQuery();
            conn.Close();
        }

        public static List<Employee> SelectRecord()
        {
            List<Employee> emp = new List<Employee>();

            
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Employees", conn);
            SqlDataReader reader = cmdSelect.ExecuteReader();
            Employee temp;

            while (reader.Read())
                {
                    temp = new Employee();
                    temp.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                    temp.FirstName = reader["FirstName"].ToString();
                    temp.LastName = reader["LastName"].ToString();
                    temp.JobTitle = reader["JobTitle"].ToString();
                    emp.Add(temp);
                }
            conn.Close();
         // conn.Dispose();

            return emp;
        }

        public static List<Employee> SearchRecord(Employee employee, Int32 index)   
        {
            List<Employee> emp = new List<Employee>();
            Employee temp = new Employee();
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.Connection = conn;
            SqlDataReader reader;

            if(index == 0)
            {
                cmdSelect.CommandText = "SELECT EmployeeId, FirstName, LastName, JobTitle " +
                "FROM Employees " +
                "WHERE EmployeeId = " + employee.EmployeeId + ";";
                reader = cmdSelect.ExecuteReader();

                while (reader.Read())
                {
                    temp.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                    temp.FirstName = reader["FirstName"].ToString();
                    temp.LastName = reader["LastName"].ToString();
                    temp.JobTitle = reader["JobTitle"].ToString();
                    emp.Add(temp);
                }
            }
            if (index == 1)
            {
                cmdSelect.CommandText = "SELECT EmployeeId, FirstName, LastName, JobTitle " +
                "FROM Employees " +
                "WHERE FirstName = '" + employee.FirstName + ";";
                reader = cmdSelect.ExecuteReader();

                while (reader.Read())
                {
                    temp.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                    temp.FirstName = reader["FirstName"].ToString();
                    temp.LastName = reader["LastName"].ToString();
                    temp.JobTitle = reader["JobTitle"].ToString();
                    emp.Add(temp);
                }
            }
            if (index == 2)
            {
                cmdSelect.CommandText = "SELECT EmployeeId, FirstName, LastName, JobTitle " +
                "FROM Employees " +
                "WHERE LastName = '" + employee.LastName + "';";
                reader = cmdSelect.ExecuteReader();

                while (reader.Read())
                {
                    temp.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                    temp.FirstName = reader["FirstName"].ToString();
                    temp.LastName = reader["LastName"].ToString();
                    temp.JobTitle = reader["JobTitle"].ToString();
                    emp.Add(temp);
                }
            }
            if (index == 3)
            {
                cmdSelect.CommandText = "SELECT EmployeeId, FirstName, LastName, JobTitle " +
                "FROM Employees " +
                "WHERE JobTitle = '" + employee.JobTitle + "';";
                reader = cmdSelect.ExecuteReader();

               while (reader.Read())
                {
                    temp.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                    temp.FirstName = reader["FirstName"].ToString();
                    temp.LastName = reader["LastName"].ToString();
                    temp.JobTitle = reader["JobTitle"].ToString();
                    emp.Add(temp);
                }
            }
            conn.Close();
            conn.Dispose();
            return emp;
        }

        public static bool checkRecordExists(Employee emp)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.Connection = conn;

            cmd.CommandText = "SELECT FROM Employees WHERE EmployeeId = " + emp.EmployeeId + ";";
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                return true;
            }
            return false;
        }
    }
}