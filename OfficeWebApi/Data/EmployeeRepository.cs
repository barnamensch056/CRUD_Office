using Microsoft.AspNetCore.Mvc;
using OfficeWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace OfficeWebApi.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConfiguration _configuration;
        public EmployeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
       

        public JsonResult GetEmp()
        {
            string query = @"select EmployeId,EmployeeName,Department,convert(varchar(10),DateOfJoining,120) as DateOfJoining from dbo.Employee";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        public JsonResult GetAllEmployees()
        {
            string query = @"select EmployeeName from dbo.Employee";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        public JsonResult PostEmp(Employee emp)
        {
            string query = @"insert into dbo.Employee (EmployeeName,Department,DateofJoining,PhotoFileName) values ('" + emp.EmployeeName + @"'
                                                             ,'" + emp.Department + @"'
                                                              ,'" + emp.DateofJoining + @"'
                                                              ,'" + emp.PhotoFileName + @"'
                                                              )";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }

        public JsonResult PutEmp(Employee emp)
        {
            string query = @"update  dbo.Employee set EmployeeName= '" + emp.EmployeeName + @"', Department= '" + emp.Department + @"'where EmployeId=" + emp.EmployeeId + @" ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Updated Successfully");
        }
        public JsonResult DeleteEmp(int id)
        {
            string query = @"delete from  dbo.Employee  where EMployeId=" + id + @" ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Deleted Successfully");
        }
    }
}
