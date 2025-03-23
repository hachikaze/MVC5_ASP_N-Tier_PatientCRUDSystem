using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Patient_CRUD_System.DTO; 

namespace Patient_CRUD_System.DAL
{
    class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("MySqlConnection") { }

        public DbSet<MedicationDTO> Medications { get; set; }
    }
}
