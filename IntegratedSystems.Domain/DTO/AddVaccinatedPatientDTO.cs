using IntegratedSystems.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedSystems.Domain.DTO
{
    public class AddVaccinatedPatientDTO
    {
        public List<Patient> Patients { get; set;}
        public string? Manufacturer { get; set; }
        public DateTime Date { get; set; }
        public Guid PatientId { get; set; }
        public Guid CenterId { get; set; }

    }
}
