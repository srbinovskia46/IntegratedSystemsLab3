using IntegratedSystems.Domain.Domain_Models;
using IntegratedSystems.Repository.Interface;
using IntegratedSystems.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedSystems.Service.Implementation
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<Patient> _repository;

        public PatientService(IRepository<Patient> repository)
        {
            _repository = repository;
        }

        public Patient CreateNewPatient(Patient patient)
        {
            return _repository.Insert(patient);
        }

        public Patient DeletePatient(Guid id)
        {
            var patientToDelete = _repository.Get(id);
            return _repository.Delete(patientToDelete);
        }

        public List<Patient> GetPatients()
        {
            return _repository.GetAll().ToList();
        }

        public Patient GetPatientById(Guid? id)
        {
            return _repository.Get(id);
        }

        public Patient UpdatePatient(Patient patient)
        {
            return _repository.Update(patient);
        }
    }
}
