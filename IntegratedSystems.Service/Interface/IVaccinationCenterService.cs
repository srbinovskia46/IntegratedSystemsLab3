using IntegratedSystems.Domain.Domain_Models;
using IntegratedSystems.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedSystems.Service.Interface
{
    public interface IVaccinationCenterService
    {
        public List<VaccinationCenter> GetVaccinationCenters();
        public VaccinationCenter GetVaccinationCenterById(Guid? id);
        public VaccinationCenter CreateNewVaccinationCenter(VaccinationCenter vaccinationCenter);
        public VaccinationCenter UpdateVaccinationCenter(VaccinationCenter vaccinationCenter);
        public VaccinationCenter DeleteVaccinationCenter(Guid id);
        public void AddVaccinatedPatientToCenter(AddVaccinatedPatientDTO addVaccinatedPatientDTO);
        public AddVaccinatedPatientDTO getVaccinationCenterInfo(Guid Id);
    }
}
