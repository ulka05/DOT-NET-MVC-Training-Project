using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DemoMVC.commonhelper
{
    public class DBUserMaster
    {
        SqlConnection con = null;
        SqlCommand cmd = null;

        public char Status { get; internal set; }
        public int Id { get; internal set; }

        public DBUserMaster()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString);
            con.Open();

        }
        public int InsertUserData(insertrecord U)
        {
            if (U.Id == 0)
            {
                using (con)
                {


                    cmd = new SqlCommand("CreateNewAccount_SP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = U.Id;
                    cmd.Parameters.AddWithValue("@CreatedAt", SqlDbType.VarChar).Value = DateTime.Now.ToString("dd/MM/yyyy | hh:mm:ss tt");
                    cmd.Parameters.AddWithValue("@EditedAt", SqlDbType.VarChar).Value = null;
                    cmd.Parameters.AddWithValue("@DeletedAt", SqlDbType.VarChar).Value = null;
                    cmd.Parameters.AddWithValue("@FirstName", SqlDbType.VarChar).Value = U.FirstName;
                    cmd.Parameters.AddWithValue("@LastName", SqlDbType.VarChar).Value = U.LastName;
                    cmd.Parameters.AddWithValue("@ContactNo", SqlDbType.VarChar).Value = U.ContactNo;
                    cmd.Parameters.AddWithValue("@EmailId", SqlDbType.VarChar).Value = U.EmailId;
                    cmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = U.Password;
                    cmd.Parameters.AddWithValue("@Gender", SqlDbType.Char).Value = U.Gender;
                    cmd.Parameters.AddWithValue("@Status", SqlDbType.Char).Value = U.Status;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            else
            {
                using (con)
                {
                    cmd = new SqlCommand("CreateNewAccount_SP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = U.Id;
                    cmd.Parameters.AddWithValue("@CreatedAt", SqlDbType.VarChar).Value = null;
                    cmd.Parameters.AddWithValue("@EditedAt", SqlDbType.VarChar).Value = DateTime.Now.ToString("dd/MM/yyyy | hh:mm:ss tt"); ;
                    cmd.Parameters.AddWithValue("@DeletedAt", SqlDbType.VarChar).Value = null;
                    cmd.Parameters.AddWithValue("@FirstName", SqlDbType.VarChar).Value = U.FirstName;
                    cmd.Parameters.AddWithValue("@LastName", SqlDbType.VarChar).Value = U.LastName;
                    cmd.Parameters.AddWithValue("@ContactNo", SqlDbType.VarChar).Value = U.ContactNo;
                    cmd.Parameters.AddWithValue("@EmailId", SqlDbType.VarChar).Value = U.EmailId;
                    cmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = U.Password;
                    cmd.Parameters.AddWithValue("@Gender", SqlDbType.Char).Value = U.Gender;
                    cmd.Parameters.AddWithValue("@Status", SqlDbType.Char).Value = 'X';
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }
            return 1;
        }



        public List<insertrecord> GetUserData(string OrderBy, string WhereClause)
        {
            List<insertrecord> UList = new List<insertrecord>();
            using (con)
            {
                cmd = new SqlCommand("GetUserRecord", con);
                cmd.Parameters.AddWithValue("@OrderBy", SqlDbType.VarChar).Value = OrderBy;
                cmd.Parameters.AddWithValue("@WhereClause", SqlDbType.VarChar).Value = WhereClause;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    insertrecord UD = new insertrecord();
                    UD.setId(Convert.ToInt32(reader["ID"]));
                    UD.setFirstName(Convert.ToString(reader["FirstName"]));
                    UD.setLastName(Convert.ToString(reader["LastName"]));
                    UD.setEmailId(Convert.ToString(reader["EmailId"]));
                    UD.setContactNo(Convert.ToString(reader["ContactNo"]));
                    UD.setGender(Convert.ToChar(reader["Gender"]));
                    UD.setStatus(Convert.ToChar(reader["Status"]));
                    UD.setCreatedAt(Convert.ToString(reader["CreatedAt"]));
                    UD.setEditedAt(Convert.ToString(reader["EditedAt"]));
                    UD.setDeletedAt(Convert.ToString(reader["DeletedAt"]));
                    UList.Add(UD);

                }
            }

            return UList;

        }


        public List<Chartresponsemodel> GetUserChartData(string SelectAsLabel, string GroupBy)
        {
            List<Chartresponsemodel> UList = new List<Chartresponsemodel>();
            using (con)
            {
                cmd = new SqlCommand("GetUserRecordsChart", con);
                cmd.Parameters.AddWithValue("@SelectAsLabel", SqlDbType.VarChar).Value = SelectAsLabel;
                cmd.Parameters.AddWithValue("@GroupBy", SqlDbType.VarChar).Value = GroupBy;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Chartresponsemodel U = new Chartresponsemodel();
                    U.setLabel(Convert.ToString(rdr["label"]));
                    U.setValue(Convert.ToInt32(rdr["value"]));
                    UList.Add(U);
                }
            }

            return UList;

        }


        public int UpdateUserStatus(insertrecord U)
        {
            if (U.Id != 0)
            {
                using (con)
                {
                    cmd = new SqlCommand("UpdateUserStatus_SP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = U.Id;
                    cmd.Parameters.AddWithValue("@DeletedAt", SqlDbType.VarChar).Value = DateTime.Now.ToString("dd/MMM/YYYY | hh:mm:ss tt");
                    cmd.Parameters.AddWithValue("@Status", SqlDbType.Char).Value = U.Status;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return 1;
        }

    }
}

