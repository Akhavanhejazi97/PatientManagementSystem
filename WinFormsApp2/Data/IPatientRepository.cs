using PatientManagementSystem.Models;
using System.Collections.Generic;

namespace PatientManagementSystem.Data
{
    public interface IPatientRepository
    {
        List<Patient> GetAllPatients();

        List<Patient> GetAll();

        Patient GetPatientByNationalCode(string nationalCode);

        Patient GetPatientById(int id);

        bool AddPatient(Patient patient);

        bool Add(Patient patient);

        bool UpdatePatient(Patient patient);

        bool Update(Patient patient);

        bool DeletePatient(int id);

        bool Delete(int id);

        List<Patient> SearchPatients(string keyword);

        List<Patient> Search(string keyword);
    }
}