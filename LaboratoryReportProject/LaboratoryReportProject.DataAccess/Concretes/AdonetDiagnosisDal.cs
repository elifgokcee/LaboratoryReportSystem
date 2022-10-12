using LaboratoryReportProject.DataAccess.Abstracts;
using LaboratoryReportProject.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryReportProject.DataAccess.Concretes
{
    public class AdonetDiagnosisDal :IDiagnosisDal
    {
        public bool Add(Diagnosis diagnosis)
        {
            bool result = false;
            using (var connection = Database.GetConnection())
            {
                DbControl(connection);
                SqlCommand command = new SqlCommand("INSERT INTO Diagnosis (Id,DiagnosisName,Title) VALUES(@Id,@DiagnosisName,@Title)", connection);
                command.Parameters.Add(new SqlParameter("Id", diagnosis.Id));
                command.Parameters.Add(new SqlParameter("DiagnosisName", diagnosis.DiagnosisName));
                command.Parameters.Add(new SqlParameter("Title", diagnosis.Title));
              
             

                if (command.ExecuteNonQuery() != -1)
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
            bool result = false;
            using (var connection = Database.GetConnection())
            {
                DbControl(connection);
                var command =
                    new SqlCommand(
                        "delete from Diagnosis  where Id=@Id",
                        connection);
                command.Parameters.Add(new SqlParameter("Id", id));



                if (command.ExecuteNonQuery() != -1)
                {
                    result = true;
                }
                connection.Close();
            }
            return result;
        }

     
        public bool Update(Diagnosis diagnosis)
        {

            bool result = false;
            using (var connection = Database.GetConnection())
            {
                var command =
                    new SqlCommand(
                        "Update Diagnosis set " +
                        "DiagnosisName=@DiagnosisName," +
                        "Title=@Title," +
                        "where Id=@Id",
                        connection);
                command.Parameters.Add(new SqlParameter("Id", diagnosis.Id));
                command.Parameters.Add(new SqlParameter("DiagnosisName", diagnosis.DiagnosisName));
                command.Parameters.Add(new SqlParameter("Title",diagnosis.Title));
              

               
                if (command.ExecuteNonQuery() != -1)
                {
                    result = true;
                }
                connection.Close();
            }
            return result;
        }

        public List<Diagnosis> Get()
        {

            using (var connection = Database.GetConnection())
            {
                DbControl(connection);
                SqlCommand sc = new SqlCommand("Select * FROM Diagnosis", connection);

                SqlDataReader reader = sc.ExecuteReader();
                List<Diagnosis> diagnosis = new List<Diagnosis>();
            
                    while (reader.Read())
                    {
                        Diagnosis diagnosis1 = new Diagnosis
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            DiagnosisName = reader["DiagnosisName"].ToString(),
                            Title = reader["Title"].ToString(),

                        };
                        diagnosis.Add(diagnosis1);


                    }

                reader.Close();
                connection.Close();
                return diagnosis;
            }
        }

        public Diagnosis GetById(int id)
        {
            using (var connection = Database.GetConnection())
            {
                DbControl(connection);
                SqlCommand sc = new SqlCommand("Select * FROM Daignosis where Id=@Id", connection);
                sc.Parameters.Add(new SqlParameter("Id", id));
                SqlDataReader reader = sc.ExecuteReader();
                Diagnosis _diagnosis = new Diagnosis();
                while (reader.Read())
                {
                    Diagnosis diagnosis = new Diagnosis
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        DiagnosisName = reader["DiagnosisName"].ToString(),
                        Title = reader["Title"].ToString(),

                    };
                    _diagnosis = diagnosis;


                }

                reader.Close();
                connection.Close();
                return _diagnosis;
            }
        }
        public int GetLastId()
        {

            using (var connection = Database.GetConnection())
            {
                int _id=0;
                DbControl(connection);
                SqlCommand sc = new SqlCommand("Select max(Id) as x FROM Diagnosis", connection);

                SqlDataReader reader = sc.ExecuteReader();

                while (reader.Read()) {
                    if (reader["x"]!=DBNull.Value)
                    {
                        
                        _id = Convert.ToInt32(reader["x"]);
                    }


                    }

                reader.Close();
                connection.Close();
                return _id;
            }
        }

     
    }
}
