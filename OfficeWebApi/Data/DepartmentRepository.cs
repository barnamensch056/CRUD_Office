using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OfficeWebApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace OfficeWebApi.Data
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IConfiguration _configuration;
        public DepartmentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        public JsonResult GetDept()
        {
            string query = @"select DepartmentId,DepartmentName from dbo.Department";
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

        public JsonResult PostDept(Department dept)
        {
            string query = @"insert into dbo.Department values ('" + dept.DepartmentName + @"')";
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

        public JsonResult PutDept(Department dept)
        {
            string query = @"update  dbo.Department set DepartmentName= '" + dept.DepartmentName + @"' where DepartmentId=" + dept.DepartmentId + @" ";
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
        public JsonResult DeleteDept(int id)
        {
            string query = @"delete from  dbo.Department  where DepartmentId=" + id + @" ";
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
