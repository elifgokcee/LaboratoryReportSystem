using LaboratoryReportProject.DataAccess.Abstracts;
using LaboratoryReportProject.Entities;
using LaboratoryReportProject.Entities.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryReportProject.DataAccess.Concretes
{
    public class AdonetReportDal : IReportDal
    {
        public bool Add(Report report)
        {
            bool result = false;
            using (var connection = Database.GetConnection())
            {
                DbControl(connection);
                SqlCommand command = new SqlCommand("INSERT INTO Reports VALUES(@PatientId,@DiagnosisId,@CreatedDate,@LaborantId)", connection);
                command.Parameters.AddWithValue("PatientId",report.PatientId);
                command.Parameters.AddWithValue("LaborantId", report.LaborantId);
                command.Parameters.AddWithValue("DiagnosisId", report.DiagnosisId);
               SqlParameter pm= command.Parameters.AddWithValue("CreatedDate", report.CreatedDate);
                pm.SqlDbType = SqlDbType.DateTime;
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
                        "delete from reports  where Id=@Id",
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

        public List<Report> Get()
        {
            using (var connection = Database.GetConnection())
            {
                DbControl(connection);
                SqlCommand sc = new SqlCommand("Select * FROM Reports", connection);
                SqlDataReader reader = sc.ExecuteReader();
                List<Report> reports = new List<Report>();
                while (reader.Read())
                {
                    Report report = new Report
                    {
                        Id = Convert.ToInt32(reader["Id"]),

                        DiagnosisId = Convert.ToInt32(reader["DiagnosisId"]),

                        LaborantId = Convert.ToInt32(reader["LaborantId"]),

                        PatientId = Convert.ToInt32(reader["PatientId"]),

                        CreatedDate = Convert.ToDateTime(reader["CreatedDate"])

                    };
                    reports.Add(report);
                }




                reader.Close();
                connection.Close();
                return reports;
            }
        }
        public Report GetById(int id)
        {
            using (var connection = Database.GetConnection())
            {
                DbControl(connection);
                SqlCommand sc = new SqlCommand("Select * FROM Reports where Id=@id", connection);
                sc.Parameters.Add(new SqlParameter("Id", id));
                SqlDataReader reader = sc.ExecuteReader();
                Report _report = new Report();
                while (reader.Read())
                {
                    Report report = new Report
                    {
                        Id = Convert.ToInt32(reader["Id"]),

                        DiagnosisId = Convert.ToInt32(reader["DiagnosisId"]),

                        LaborantId = Convert.ToInt32(reader["LaborantId"]),

                        PatientId = Convert.ToInt32(reader["PatientId"]),

                        CreatedDate = Convert.ToDateTime(reader["CreatedDate"])
                    };
                    _report = report;


                }

                reader.Close();
                connection.Close();
                return _report;
            }
        }

        public bool Update(Report report)
        {
            bool result = false;
            using (var connection = Database.GetConnection())
            {
                var command =
                    new SqlCommand(
                        "Update Reports set " +
                        "DiagnosisId=@DiagnosisId," +
                        "PatientId=@PatientId," +
                        "LaborantId=@LaborantId," +
                        "CreatedDate=@CreatedDate where Id=@Id",
                        connection);
                command.Parameters.Add(new SqlParameter("Id", report.Id));
                command.Parameters.Add(new SqlParameter("DiagnosisId", report.DiagnosisId));
                command.Parameters.Add(new SqlParameter("PatientId", report.PatientId));
                command.Parameters.Add(new SqlParameter("LaborantId", report.LaborantId));
                command.Parameters.Add(new SqlParameter("CreatedDate", report.CreatedDate));

                connection.Open();
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

        public List<ReportDetails> GetReportDetails()
        {
            using (var connection = Database.GetConnection())
            {
                DbControl(connection);
                SqlCommand sc = new SqlCommand("Select R.CreatedDate,R.Id,L.LaborantName,D.Title,D.DiagnosisName,P.PatientName,P.IdentityNumber" +
                    " FROM Reports R " +
                    "inner join Laborants L on L.Id=R.LaborantId " +
                    "inner join Diagnosis D on D.Id=R.DiagnosisId " +
                    "inner join Patients P on P.Id=R.PatientId", 
                    connection);
                SqlDataReader reader = sc.ExecuteReader();
                List<ReportDetails> reportDetails = new List<ReportDetails>();
                while (reader.Read())
                {
                    ReportDetails reportDetail = new ReportDetails
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                        DiagnosisDescription = reader["DiagnosisName"].ToString(),
                        LaborantName = reader["LaborantName"].ToString(),
                        PatientName = reader["PatientName"].ToString(),
                        PatientIdentityNumber = reader["IdentityNumber"].ToString(),
                        DiagnosisTitle = reader["Title"].ToString(),
                        

                    };
                    reportDetails.Add(reportDetail);
                }




                reader.Close();
                connection.Close();
                return reportDetails;
            }
        }

        public List<ReportDetails> GetReportDetailsById(int id)
        {
            using (var connection = Database.GetConnection())
            {
                DbControl(connection);
                SqlCommand sc = new SqlCommand("Select R.CreatedDate,R.Id,L.LaborantName,D.Title,D.DiagnosisName,P.PatientName,P.IdentityNumber" +
                    " FROM Reports R " +
                    "inner join Laborants L on L.Id=R.LaborantId " +
                    "inner join Diagnosis D on D.Id=R.DiagnosisId " +
                    "inner join Patients P on P.Id=R.PatientId " +
                    "where Id=@Id",
                    connection);
                SqlDataReader reader = sc.ExecuteReader();
                sc.Parameters.Add(new SqlParameter("Id",id));
                List<ReportDetails> reportDetails = new List<ReportDetails>();
                while (reader.Read())
                {
                    ReportDetails reportDetail = new ReportDetails
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                        DiagnosisDescription = reader["DiagnosisName"].ToString(),
                        LaborantName = reader["LaborantName"].ToString(),
                        PatientName = reader["PatientName"].ToString(),
                        PatientIdentityNumber = reader["IdentityNumber"].ToString(),
                        DiagnosisTitle = reader["Title"].ToString(),


                    };
                    reportDetails.Add(reportDetail);
                }




                reader.Close();
                connection.Close();
                return reportDetails;
            }
        }

        public List<ReportDetails> GetReportDetailsByPatientName(string PatientName)
        {
            using (var connection = Database.GetConnection())
            {
                DbControl(connection);
                SqlCommand sc = new SqlCommand("Select R.CreatedDate,R.Id,L.LaborantName,D.Title,D.DiagnosisName,P.PatientName,P.IdentityNumber" +
                    " FROM Reports R " +
                    "inner join Laborants L on L.Id=R.LaborantId " +
                    "inner join Diagnosis D on D.Id=R.DiagnosisId " +
                    "inner join Patients P on P.Id=R.PatientId " +
                    "where P.PatientName like '%'+@PatientName+'%' ",

                    connection);
                SqlParameter sp = sc.Parameters.Add(new SqlParameter("PatientName", PatientName));
                SqlDataReader reader = sc.ExecuteReader();
            
                sp.DbType = (DbType)SqlDbType.VarChar;
                List<ReportDetails> reportDetails = new List<ReportDetails>();
                while (reader.Read())
                {
                    ReportDetails reportDetail = new ReportDetails
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                        DiagnosisDescription = reader["DiagnosisName"].ToString(),
                        LaborantName = reader["LaborantName"].ToString(),
                        PatientName = reader["PatientName"].ToString(),
                        PatientIdentityNumber = reader["IdentityNumber"].ToString(),
                        DiagnosisTitle = reader["Title"].ToString(),


                    };
                    reportDetails.Add(reportDetail);
                }




                reader.Close();
                connection.Close();
                return reportDetails;
            }
        }

        public List<ReportDetails> GetReportDetailsByPatientId(int patientId)
        {
            using (var connection = Database.GetConnection())
            {
                DbControl(connection);
                SqlCommand sc = new SqlCommand("Select R.CreatedDate,R.Id,L.LaborantName,D.Title,D.DiagnosisName,P.PatientName,P.IdentityNumber" +
                    " FROM Reports R " +
                    "inner join Laborants L on L.Id=R.LaborantId " +
                    "inner join Diagnosis D on D.Id=R.DiagnosisId " +
                    "inner join Patients P on P.Id=R.PatientId " +
                    "where R.PatientId=@PatientId ",

                    connection);
                SqlParameter sp = sc.Parameters.Add(new SqlParameter("PatientId", patientId));
                SqlDataReader reader = sc.ExecuteReader();

                sp.DbType = (DbType)SqlDbType.VarChar;
                List<ReportDetails> reportDetails = new List<ReportDetails>();
                while (reader.Read())
                {
                    ReportDetails reportDetail = new ReportDetails
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                        DiagnosisDescription = reader["DiagnosisName"].ToString(),
                        LaborantName = reader["LaborantName"].ToString(),
                        PatientName = reader["PatientName"].ToString(),
                        PatientIdentityNumber = reader["IdentityNumber"].ToString(),
                        DiagnosisTitle = reader["Title"].ToString(),


                    };
                    reportDetails.Add(reportDetail);
                }




                reader.Close();
                connection.Close();
                return reportDetails;
            }
        }
    }
}
