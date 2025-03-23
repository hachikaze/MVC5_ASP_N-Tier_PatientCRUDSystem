using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_CRUD_System.DTO
{
    [Table("medication")]
    public class MedicationDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double Dosage { get; set; }
        [Required]
        public string Drug { get; set; }
        [Required]
        public string Patient { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    }
}
