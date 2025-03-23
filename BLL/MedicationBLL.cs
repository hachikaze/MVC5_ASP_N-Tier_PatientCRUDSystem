using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patient_CRUD_System.DAL;
using Patient_CRUD_System.DTO;

namespace Patient_CRUD_System.BLL
{
    public class MedicationBLL
    {
        //private readonly MedicationDAL _repository;
        private MedicationDAL dal = new MedicationDAL();

        public string AddMedication(MedicationDTO medication)
        {
            string validationMessage = ValidateMedication(medication);
            if (!string.IsNullOrEmpty(validationMessage))
                return validationMessage;

            dal.AddMedication(medication);
            return "success";
        }

        public string EditMedication(MedicationDTO medication)
        {
            string validationMessage = ValidateMedication(medication);
            if (!string.IsNullOrEmpty(validationMessage))
                return validationMessage;

            dal.UpdateMedication(medication);
            return "success";
        }

        public string RemoveMedication(int id)
        {
            if (id < 0)
                return "Invalid medication ID.";

            dal.DeleteMedication(id);
            return "success";
        }

        public List<MedicationDTO> GetMedications()
        {
            return dal.GetMedications();
        }

        public MedicationDTO GetPatientById(int Id)
        {
            // Create an instance of getting the ID of the patient coming from then _repository (Patient Repository) - DAL
            return dal.GetPatientById(Id);
        }

        private string ValidateMedication(MedicationDTO medication)
        {
            // All possible validation within input fields.
            if (medication == null)
                return "Medication cannot be null.";

            if (medication.Dosage <= 0)
                return "Dosage must be greater than zero.";

            if (string.IsNullOrWhiteSpace(medication.Drug) || medication.Drug.Length > 50)
                return "Drug name is required and should not exceed 50 characters.";

            if (string.IsNullOrWhiteSpace(medication.Patient) || medication.Patient.Length > 50)
                return "Patient name is required and should not exceed 50 characters.";

            return string.Empty;
        }
    }
}
