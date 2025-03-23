using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Patient_CRUD_System.DTO;

namespace Patient_CRUD_System.DAL
{
    public class MedicationDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        // Insert Medication
        public void AddMedication(MedicationDTO medication)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                //string query = "INSERT INTO Medication (Dosage, Drug, Patient, ModifiedDate) VALUES (@Dosage, @Drug, @Patient, NOW())";

                // Stored Procedure (AddMedication)
                MySqlCommand cmd = new MySqlCommand("AddMedication", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Dosage", medication.Dosage);
                cmd.Parameters.AddWithValue("@Drug", medication.Drug);
                cmd.Parameters.AddWithValue("@Patient", medication.Patient);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateMedication(MedicationDTO medication)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("UpdateMedication", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@medicationId", medication.Id);
                cmd.Parameters.AddWithValue("@NewDosage", medication.Dosage);
                cmd.Parameters.AddWithValue("@NewDrug", medication.Drug);
                cmd.Parameters.AddWithValue("@NewPatient", medication.Patient);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteMedication(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("DeleteMedication", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@medicationId", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Retrieve All Medications
        public List<MedicationDTO> GetMedications()
        {
            List<MedicationDTO> medications = new List<MedicationDTO>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Medication";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        medications.Add(new MedicationDTO
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Dosage = (double)Convert.ToDecimal(reader["Dosage"]),
                            Drug = reader["Drug"].ToString(),
                            Patient = reader["Patient"].ToString(),
                            ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"])
                        });
                    }
                }
            }
            return medications;
        }

        public MedicationDTO GetPatientById(int Id)
        {
            MedicationDTO patient = null;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open(); // Open the connection to the database

                string query = "SELECT Id, Drug, Dosage, Patient FROM Medication WHERE Id = @Id"; // Define the query

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", Id); // Use AddWithValue for MySQL parameters

                    using (MySqlDataReader reader = cmd.ExecuteReader()) // ExecuteReader for MySQL
                    {
                        if (reader.Read())
                        {
                            patient = new MedicationDTO
                            {
                                Id = reader.GetInt32("Id"), // Use column name instead of index for better clarity
                                Drug = reader.GetString("Drug"),
                                Dosage = (double)reader.GetDecimal("Dosage"), // Assuming Dosage is decimal
                                Patient = reader.GetString("Patient")
                            };
                        }
                    }
                }
            }
            return patient; // Return the fetched patient data
        }
    }
}
