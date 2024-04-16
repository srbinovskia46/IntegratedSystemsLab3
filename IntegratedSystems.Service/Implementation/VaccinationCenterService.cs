using IntegratedSystems.Domain.Domain_Models;
using IntegratedSystems.Domain.DTO;
using IntegratedSystems.Repository.Interface;
using IntegratedSystems.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedSystems.Service.Implementation
{
    public class VaccinationCenterService : IVaccinationCenterService
    {
        private readonly IRepository<VaccinationCenter> _repository;
        private readonly IRepository<Patient> _patientRepository;
        private readonly IRepository<Vaccine> _vaccineRepository;

        public VaccinationCenterService(IRepository<VaccinationCenter> repository, IRepository<Patient> patientRepository, IRepository<Vaccine> vaccineRepository)
        {
            _repository = repository;
            _patientRepository = patientRepository;
            _vaccineRepository = vaccineRepository;
        }



        public void AddVaccinatedPatientToCenter(AddVaccinatedPatientDTO model)
        {
            
            if (model.CenterId != null)
            {
                var center = _repository.Get(model.CenterId);
                var selectedPatient = _patientRepository.Get(model.PatientId);

                if (center != null && selectedPatient != null)
                {
                    var vaccine = _vaccineRepository.Insert(new Vaccine
                    {
                        Manufacturer = model.Manufacturer,
                        Certificate = Guid.NewGuid(),
                        DateTaken = model.Date,
                        PatientId = model.PatientId,
                        PatientFor = selectedPatient,
                        VaccinationCenter = model.CenterId,
                        Center = center
                    });

                    if(center.Vaccines == null) {
                        center.Vaccines = new List<Vaccine>();
                    }
                    center.Vaccines.Add(vaccine);
                    _repository.Update(center);
                }
            }
        }

        public AddVaccinatedPatientDTO getVaccinationCenterInfo(Guid Id)
        {
            var center = _repository.Get(Id);
            if (center != null)
            {
                var model = new AddVaccinatedPatientDTO
                {
                    CenterId = center.Id,
                    Patients = _patientRepository.GetAll().ToList(),
                    Manufacturer = "",
                    Date = DateTime.Now,
                    
                };
                return model;
            }
            return null;
        }


        public VaccinationCenter CreateNewVaccinationCenter(VaccinationCenter vaccinationCenter)
        {
            return _repository.Insert(vaccinationCenter);
        }

        public VaccinationCenter DeleteVaccinationCenter(Guid id)
        {
            var centerToDelete = _repository.Get(id);
            return _repository.Delete(centerToDelete);
        }

        public VaccinationCenter GetVaccinationCenterById(Guid? id)
        {
            var center = _repository.Get(id);
            var vaccines = _vaccineRepository.GetAll().Where(vaccine => vaccine.VaccinationCenter == center.Id).ToList();
            center.Vaccines = vaccines;
            return center;
        }

        public List<VaccinationCenter> GetVaccinationCenters()
        {
            return _repository.GetAll().ToList();
        }

        public VaccinationCenter UpdateVaccinationCenter(VaccinationCenter vaccinationCenter)
        {
            return _repository.Update(vaccinationCenter);
        }
    }
}
