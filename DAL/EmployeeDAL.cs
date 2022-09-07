using CRUDUsingAdoDotNet1.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDUsingAdoDotNet1.DAL
{
    public class EmployeeDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public EmployeeDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            string constr = configuration["ConnectionStrings:defaultConnection"];
            con = new SqlConnection(constr);
        }
        public List<Employee> GetAllEmployee()
        {
            List<Employee> employeelist = new List<Employee>();
            string qry = "select * from Employee";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(dr["Id"]); // Id is a col name, should be match
                    employee.Name = dr["Name"].ToString();
                    employee.DepartmentName = dr["DepartmentName"].ToString();
                    employee.Salary = Convert.ToInt32(dr["Salary"]);
                    employeelist.Add(employee);
                }
            }
            con.Close();
            return employeelist;
        }
        public Employee GetEmployeeById(int id)
        {
            Employee employee = new Employee();
            string qry = "select * from Employee where Id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    employee.Id = Convert.ToInt32(dr["Id"]); // Id is a col name, should be match
                    employee.Name = dr["Name"].ToString();
                    employee.DepartmentName = dr["DepartmentName"].ToString();
                    employee.Salary = Convert.ToInt32(dr["Salary"]);
                }
            }
            con.Close();
            return employee;
        }
        public int AddEmployee(Employee emp)
        {
            string qry = "insert into Product values(@name,@comp,@price)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@dept", emp.DepartmentName);
            cmd.Parameters.AddWithValue("@salary", emp.Salary);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
        public int UpdateEmployee(Employee emp)
        {
            string qry = "update Employee set Name=@name,CompanyName=@comp,Price=@price where Id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", emp.Id);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@dept", emp.DepartmentName);
            cmd.Parameters.AddWithValue("@salary", emp.Salary);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int DeleteEmployee(int id)
        {
            string qry = "delete from Employee where Id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
    }

}

