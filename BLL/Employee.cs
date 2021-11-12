using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab1_ASPNetConnectedMode.DAL;

namespace Lab1_ASPNetConnectedMode.BLL
{
    public class Employee
    {
        private int employeeId;
        private string firstName;
        private string lastName;
        private string jobTitle;

        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string JobTitle { get => jobTitle; set => jobTitle = value; }

        public static void SaveEmployee(Employee emp)
        {
            EmployeeDB.SaveRecord(emp);
        }   

        public static void UpdateEmployee(Employee emp)
        {
            EmployeeDB.UpdateRecord(emp);
        }

        public static void DeleteEmployee(Employee emp)
        {
            EmployeeDB.DeleteRecord(emp);
        }

        public static List<Employee> SelectEmployee(Int32 index, Employee employee)
        {
            return EmployeeDB.SearchRecord(employee, index);
        }

        public List<Employee> ListAll()
        {
            return EmployeeDB.SelectRecord();
        }

        public static bool CheckEmployee(Employee emp)
        {
            bool checker = true;

            checker = EmployeeDB.checkRecordExists(emp);

            return checker;
        }
    }
}