using System;
using System.Collections.Generic;
using System.Linq;

public class Patient
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Condition { get; private set; }

    public List<string> MedicalHistory { get; private set; }

    public Patient(int id, string name, int age, string condition)
    {
        Id = id;
        Name = name;
        Age = age;
        Condition = condition;
        MedicalHistory = new List<string>();
    }

    public void AddMedicalRecord(string record)
    {
        MedicalHistory.Add(record);
    }
}

public class HospitalManager
{
    private Dictionary<int, Patient> _patients = new();
    private Queue<Patient> _appointmentQueue = new();

    public void RegisterPatient(int id, string name, int age, string condition)
    {
        if (_patients.ContainsKey(id))
            throw new Exception("Patient already exists");

        _patients[id] = new Patient(id, name, age, condition);
    }

    public void ScheduleAppointment(int patientId)
    {
        if (_patients.TryGetValue(patientId, out var patient))
            _appointmentQueue.Enqueue(patient);
        else
            throw new Exception("Patient not found");
    }

    public Patient ProcessNextAppointment()
    {
        if (_appointmentQueue.Count == 0)
            return null;

        return _appointmentQueue.Dequeue();
    }

    public List<Patient> FindPatientsByCondition(string condition)
    {
        return _patients.Values
                        .Where(p => p.Condition.Equals(condition, StringComparison.OrdinalIgnoreCase))
                        .ToList();
    }
}
