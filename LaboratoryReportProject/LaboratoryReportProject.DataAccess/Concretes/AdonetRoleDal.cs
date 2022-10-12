using LaboratoryReportProject.DataAccess.Abstracts;
using LaboratoryReportProject.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryReportProject.DataAccess.Concretes
{
    public class AdonetRoleDal : IRoleDal
    {
        public bool Add(Role entity)
        {

            bool result = false;
            using (var connection = Database.GetConnection())
            {
                DbControl(connection);
                SqlCommand command = new SqlCommand("INSERT INTO Roles VALUES(@RoleName)", connection);
                command.Parameters.AddWithValue("PatientId",entity.Name);
              
                int q = command.ExecuteNonQuery(); //sorguyu çalıştırır ve etkilenen kayıt sayısını döndürür

                if (q != -1)
                {
                    result = true;
                }
                connection.Close();
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
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Role> Get()
        {
            using (var connection = Database.GetConnection())
            {
                DbControl(connection);
                SqlCommand sc = new SqlCommand("Select * FROM Roles", connection);
                SqlDataReader reader = sc.ExecuteReader();
                List<Role> roles = new List<Role>();
                while (reader.Read())
                {
                    Role role = new Role
                    {
                        Id = Convert.ToInt32(reader["Id"]),

                        Name = reader["RoleName"].ToString(),


                    };
                    roles.Add(role);
                }




                reader.Close();
              
                return roles;
            }
           
        }

        public Role GetById(int id)
        {

            using (var connection = Database.GetConnection())
            {
                DbControl(connection);
                SqlCommand sc = new SqlCommand("Select * FROM Roles where Id=@id", connection);
                sc.Parameters.Add(new SqlParameter("Id", id));
                SqlDataReader reader = sc.ExecuteReader();
                Role _role = new Role();
                while (reader.Read())
                {
                    Role role = new Role
                    {
                        Id = Convert.ToInt32(reader["Id"]),

                        Name =reader["RoleName"].ToString(),

                    };
                    _role = role;


                }

                reader.Close();
                connection.Close();
                return _role;
            }
        }

        public bool Update(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}
