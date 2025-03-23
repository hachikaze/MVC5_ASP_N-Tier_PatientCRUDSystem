using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using Patient_CRUD_System.BLL;
using Patient_CRUD_System.DAL;
using Patient_CRUD_System.DTO;

namespace Patient_CRUD_System.Areas.Admin.Controllers
{
    public class PatientController : Controller
    {
        //private readonly MedicationBLL _service;

        private MedicationBLL bll = new MedicationBLL();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDrug(MedicationDTO medication)
        {
            if (ModelState.IsValid) 
            {
                string result = (medication.Id > 0)
                    ? bll.EditMedication(medication)
                    : bll.AddMedication(medication);

                if (result == "success")
                {
                    // Add success message to TempData for displaying in the view
                    TempData["SuccessMessage"] = medication.Id > 0 ? "Medication updated successfully!" : "Medication added successfully!";
                    return RedirectToAction("Index", "Patient", new { area = "Admin" });
                }
                else
                {
                    TempData["ErrorMessage"] = result;
                }
                ModelState.AddModelError("", result); // Add validation message for every input fields
            }

            return View(medication);
        }

        [HttpGet]
        public ActionResult AddDrug(int? id)
        {
            MedicationDTO model = id.HasValue
                ? bll.GetPatientById(id.Value) // Fetch existing record  
                : new MedicationDTO(); // Otherwise, create a new one  

            if (id.HasValue && model == null)
                return HttpNotFound(); // Ensure record exists  

            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteDrug(int? id)
        {
            string result = bll.RemoveMedication(id.Value);

            if (result == "success")
            {
                TempData["DeletedMessage"] = "Medication deleted successfully.";
            }
            else
            {
                TempData["DeletedErrorMessage"] = result;
            }

            // Redirect to Index after the POST to avoid resubmission on refresh
            return RedirectToAction("Index", "Patient", new { area = "Admin" });
        }

        // GET: Admin/Patient
        public ActionResult Index()
        {
            var medications = bll.GetMedications();
            return View(medications);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}