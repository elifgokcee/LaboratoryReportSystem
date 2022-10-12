using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaboratoryReportProject.Entities;
using System.Data.Common;
using System.Collections.ObjectModel;
using LaboratoryReportProject.DataAccess.Abstracts;

namespace LaboratoryReportProject.DataAccess.Concretes
{
    public class AdonetPatientDal : IPatientDal
    {
        public List<Patient> Get()
        {

           
            using (var connection = Database.GetConnection())
            {
                DbControl(connection);
                SqlCommand sc = new SqlCommand("Select * FROM Patients", connection);
                SqlDataReader reader = sc.ExecuteReader();
                List<Patient> patients = new List<Patient>();
                while (reader.Read())
                {
                    Patient p = new Patient
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["PatientName"].ToString(),
                        SurName = reader["PatientSurname"].ToString(),
                        BirthDate = Convert.ToDateTime(reader["BirthDate"]),
                        IdentityNumber= reader["IdentityNumber"].ToString(),
                    };
                    patients.Add(p);
                }




                reader.Close();
              
                return patients;

            }
        }
        public bool Add(Patient patient){
            bool result = false;
            using (var connection = Database.GetConnection())
            {
                DbControl(connection);
                SqlCommand command = new SqlCommand("INSERT INTO Patients VALUES(@PatientName,@PatientSurname,@IdentityNumber,@BirthDate)", connection);
                command.Parameters.AddWithValue("PatientName", patient.Name);
                command.Parameters.AddWithValue("PatientSurname", patient.SurName);
              command.Parameters.AddWithValue("IdentityNumber", patient.IdentityNumber);
                command.Parameters.AddWithValue("BirthDate", patient.BirthDate);
                int q = command.ExecuteNonQuery(); //sorguyu çalıştırır ve etkilenen kayıt sayısını döndürür
            

                if (q != -1)
                {
                    result = true;
                }
              
            }
            return result;

        }

           

           
            
        public bool Delete(int patientId) {
            bool result = false;
            using (var connection = Database.GetConnection())
            {
                DbControl(connection);
                var command =
                    new SqlCommand(
                        "delete from patients  where Id=@Id",
                        connection);
                command.Parameters.Add(new SqlParameter("Id", patientId));
             

             
                if (command.ExecuteNonQuery() != -1)
                {
                    result = true;
                }
            }
            return result;
        }
        public bool Update(Patient patient) {
            bool result = false;
            using (var connection = Database.GetConnection())
            {
                var command =
                    new SqlCommand(
                        "Update Patients set " +
                        "PatientName=@PatientName," +
                        "PatientSurname=@PatientSurname," +
                        "IdentityNumber=@IdentityNumber," +
                        "BirthDate=@BirthDate where Id=@Id",
                        connection);
                command.Parameters.Add(new SqlParameter("Id",patient.Id));
                command.Parameters.Add(new SqlParameter("PatientName",patient.Name));
                command.Parameters.Add(new SqlParameter("PatientSurname", patient.SurName));
                command.Parameters.Add(new SqlParameter("IdentityNumber", patient.IdentityNumber));
                command.Parameters.Add(new SqlParameter("PatientSurname", patient.BirthDate));

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

        public Patient GetById(int id)
        {
            using (var connection = Database.GetConnection())
            {
                DbControl(connection);
                SqlCommand sc = new SqlCommand("Select * FROM Patients where Id=@id", connection);
                sc.Parameters.Add(new SqlParameter("Id",id));
                SqlDataReader reader = sc.ExecuteReader();
               Patient patient = new Patient();  
                while (reader.Read())
                {
                    Patient p = new Patient
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["PatientName"].ToString(),
                        SurName = reader["PatientSurname"].ToString(),
                        BirthDate = Convert.ToDateTime(reader["BirthDate"]),
                        IdentityNumber = reader["IdentityNumber"].ToString(),
                    };
                    patient = p;


                }

                reader.Close();
                return patient;
            }
    }

        public List<Patient> GetByIdentityNumber(string IdentityNumber)
        {
            using (var connection = Database.GetConnection())
            {
                DbControl(connection);
                SqlCommand sc = new SqlCommand("Select * FROM Patients where IdentityNumber like '%'+@IdentityNumber+'%'", connection);
                sc.Parameters.Add(new SqlParameter("IdentityNumber", IdentityNumber));
                SqlDataReader reader = sc.ExecuteReader();
               List<Patient> patients = new List<Patient>();    
                while (reader.Read())
                {
                    Patient p = new Patient
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["PatientName"].ToString(),
                        SurName = reader["PatientSurname"].ToString(),
                        BirthDate = Convert.ToDateTime(reader["BirthDate"]),
                        IdentityNumber = reader["IdentityNumber"].ToString(),
                    };
                    patients.Add(p);    


                }

                reader.Close();
                connection.Close();
                return patients;
            }
        }
    }
}