using System.Data;
using System.Data.SqlClient;

namespace EmployeeMVC.Models
{
    public class EmployeeData
    {
        string connectionstring = "Server=192.168.1.250\\SQL2019INT; Database=ulka; Trusted_Connection=False; User Id=ulka; Password=ulka; MultipleActiveResultSets=True;";

        public IEnumerable<Employee> GetEmployees()
        {
            List<Employee> lstemployees = new List<Employee>();

            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("GetAllEmployees_SP", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Employee emp = new Employee();
                    emp.ID = Convert.ToInt32(rdr["EmployeeID"]);
                    emp.Name = rdr["Name"].ToString();
                    emp.Gender = rdr["Gender"].ToString();
                    emp.City = rdr["City"].ToString();
                    emp.Country = rdr["Country"].ToString();

                    lstemployees.Add(emp);
                }
                con.Close();
            }
            return lstemployees;
        }



        public IEnumerable<Employee> GetAllEmployees()
        {
            List<Employee> lstemployee = new List<Employee>();

            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("GetAllEmployees_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Employee employee = new Employee();

                    employee.ID = Convert.ToInt32(rdr["EmployeeID"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.City = rdr["City"].ToString();

                    lstemployee.Add(employee);
                }
                con.Close();
            }
            return lstemployee;
        }

        public void AddEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("AddEmployee_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@City", employee.City);
                cmd.Parameters.AddWithValue("@Country", employee.Country);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("UpdateEmployee_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", employee.ID);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@City", employee.City);
                cmd.Parameters.AddWithValue("@Country", employee.Country);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Employee GetEmployeeData(int? id)
        {
            Employee employee = new Employee();

            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                string sqlQuery = "SELECT * FROM EmployeeData WHERE EmployeeID= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    employee.ID = Convert.ToInt32(rdr["EmployeeID"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.City = rdr["City"].ToString();
                    employee.Country = rdr["Country"].ToString();
                }
            }
            return employee;
        }
        public void DeleteEmployee(int? id)
        {

            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("DeleteEmployee_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
    }

}