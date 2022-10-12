using LaboratoryReportProject.DataAccess.Abstracts;
using LaboratoryReportProject.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryReportProject.DataAccess.Concretes
{
    public class AdonetLaborantDal : ILaborantDal
    {
        public bool Add(Laborant laborant)
        {
            bool result = false;
            using (var connection = Database.GetConnection())
            {
                DbControl(connection);
                SqlCommand command = new SqlCommand("INSERT INTO laborants VALUES(@LaborantName,@LaborantSurname,@IdentityNumber,@BirthDate,@RoleId,@UserName,@Password)", connection);
                 command.Parameters.AddWithValue("IdentityNumber", laborant.IdentityNumber);
                command.Parameters.AddWithValue("LaborantName", laborant.Name);
                command.Parameters.AddWithValue("LaborantSurname", laborant.SurName);
              
                command.Parameters.AddWithValue("BirthDate", laborant.BirthDate);
                command.Parameters.AddWithValue("RoleId", laborant.RoleId);
                command.Parameters.AddWithValue("UserName", laborant.UserName);
                command.Parameters.AddWithValue("Password", laborant.Password);
                int q = command.ExecuteNonQuery(); //sorguyu çalıştırır ve etkilenen kayıt sayısını döndürür
           

                if (q != -1)
                {
                    result = true;
                }
                connection.Close();
            }
            return result;

        }

        public bool Delete(int id)
        {
            bool result = false;
            using (var connection = Database.GetConnection())
            {
                DbControl(connection);
                var command =
                    new SqlCommand(
                        "delete from laborants  where Id=@Id",
                        connection);
                command.Parameters.Add(new SqlParameter("Id", id));



                if (command.ExecuteNonQuery() != -1)
                {
                    result = true;
                }
              
            }
            return result;
        }

        public List<Laborant> Get()
        {
            using (var connection = Database.GetConnection())
            {
                DbControl(connection);
                SqlCommand sc = new SqlCommand("Select * FROM Laborants", connection);
            
                SqlDataReader reader = sc.ExecuteReader();
                List<Laborant> laborants = new List<Laborant>();
           
                    while (reader.Read())
                {
                    Laborant laborant = new Laborant
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["LaborantName"].ToString(),
                        SurName = reader["LaborantSurname"].ToString(),
                        BirthDate = Convert.ToDateTime(reader["BirthDate"]),
                        IdentityNumber = reader["IdentityNumber"].ToString(),
                        RoleId = Convert.ToInt32(reader["RoleId"]),
                        UserName = reader["UserName"].ToString()
                    };
                        laborants.Add(laborant);    


                }

                reader.Close();
         
                return laborants;
            }
        }

        public Laborant GetById(int id)
        {
            using (var connection = Database.GetConnection())
            {
                DbControl(connection);
                SqlCommand sc = new SqlCommand("Select * FROM Laborants where Id=@Id", connection);
                sc.Parameters.Add(new SqlParameter("Id", id));
                SqlDataReader reader = sc.ExecuteReader();
                Laborant _laborant = new Laborant();
                while (reader.Read())
                {
                    Laborant laborant = new Laborant
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["LaborantName"].ToString(),
                        SurName = reader["LaborantSurname"].ToString(),
                        BirthDate = Convert.ToDateTime(reader["BirthDate"]),
                        IdentityNumber = reader["IdentityNumber"].ToString(),
                        RoleId= Convert.ToInt32(reader["RoleId"]),
                        UserName = reader["UserName"].ToString()
                    };
                    _laborant = laborant;


                }

                reader.Close();
                connection.Close();
                return _laborant;
            }
        }

        public bool Update(Laborant laborant)
        {
            bool result = false;
            using (var connection = Database.GetConnection())
            {
                var command =
                    new SqlCommand(
                        "Update Laborants set " +
                        "LaborantName=@PatientName," +
                        "LaborantSurname=@PatientSurname," +
                        "IdentityNumber=@IdentityNumber," +
                        "BirthDate=@BirthDate,UserName=@UserName,Password=@Password where Id=@Id",
                        connection);
                command.Parameters.Add(new SqlParameter("Id", laborant.Id));
                command.Parameters.Add(new SqlParameter("LaborantName", laborant.Name));
                command.Parameters.Add(new SqlParameter("LaborantSurname", laborant.SurName));
                command.Parameters.Add(new SqlParameter("IdentityNumber", laborant.IdentityNumber));
                command.Parameters.Add(new SqlParameter("Birthdate", laborant.BirthDate));
                command.Parameters.Add(new SqlParameter("UserName", laborant.UserName));
                command.Parameters.Add(new SqlParameter("Password", laborant.Password));

                if (command.ExecuteNonQuery() != -1)
                {
                    result = true;
                }
               
            }
            return result;
        }
      
        public static void DbControl(SqlConnection _db)
        {

            if (_db.State == ConnectionState.Closed)
            {
                _db.Open();
            }
        }

        public Laborant GetLaborantByUserName(string UserName)
        {
            using (var connection = Database.GetConnection())
            {
                DbControl(connection);
                SqlCommand sc = new SqlCommand("Select * FROM Laborants where UserName=@UserName", connection);
                sc.Parameters.Add(new SqlParameter("UserName", UserName));
                SqlDataReader reader = sc.ExecuteReader();
                Laborant _laborant = new Laborant();
                while (reader.Read())
                {
                    Laborant laborant = new Laborant
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["LaborantName"].ToString(),
                        SurName = reader["LaborantSurname"].ToString(),
                        BirthDate = Convert.ToDateTime(reader["BirthDate"]),
                        IdentityNumber = reader["IdentityNumber"].ToString(),
                        RoleId = Convert.ToInt32(reader["RoleId"]),
                        UserName = reader["UserName"].ToString(),
                        Password=reader["Password"].ToString(),
                    };
                    _laborant = laborant;


                }

                reader.Close();
                connection.Close();
                return _laborant;
            }

        }

       
    }
}
