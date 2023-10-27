using Google.Protobuf.WellKnownTypes;
using Google.Type;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using PatientAPI.Data;
using PatientAPI.Models;
using System;
using System.Diagnostics.Metrics;
using System.Net.Mail;
using System.Reflection.Emit;

namespace PatientAPI.Services
{
    public class PatientService : PatientProto.PatientProtoBase
    {
        private readonly PatientDbContext _dbContext;
        public PatientService(PatientDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<CreatePatientResponse> CreatePatient(CreatePatientRequest request, ServerCallContext context)
        {
            if (request.Name == string.Empty || request.SurName == string.Empty)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "You must provide a valid input"));
            }
            var patient = new Patient
            {
                Name = request.Name,
                SurName = request.SurName,
                EmailAdress = request.EmailAdress,
                PhoneNumber = request.PhoneNumber,
                Country = request.Country,
                City = request.City,
                ZipCode = request.ZipCode,
                Street = request.Street,
                HouseNumber = request.HouseNumber,
                DateOfBirth = request.DateOfBirth.ToDateTime()
            };

            await _dbContext.AddAsync(patient);
            await _dbContext.SaveChangesAsync();

            return await Task.FromResult(new CreatePatientResponse
            {
                Id = patient.Id
            });
        }

        public override async Task<ReadPatientResponse> ReadPatient(ReadPatientRequest request, ServerCallContext context)
        {
            if (request.Id <= 0)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Resource index must be greater than 0"));
            }
            var patient = await _dbContext.Patients.FirstOrDefaultAsync(p => p.Id == request.Id);

            if (patient != null)
            {
                return await Task.FromResult(new ReadPatientResponse
                {
                    Id = patient.Id,
                    Name = patient.Name,
                    SurName = patient.SurName,
                    EmailAdress = patient.EmailAdress,
                    PhoneNumber = patient.PhoneNumber,
                    Country = patient.Country,
                    City = patient.City,
                    ZipCode = patient.ZipCode,
                    Street = patient.Street,
                    HouseNumber = patient.HouseNumber,
                    DateOfBirth = patient.DateOfBirth.ToUniversalTime().ToTimestamp()
                });
            }

            throw new RpcException(new Status(StatusCode.NotFound, $"No patient with id {request.Id}"));
        }

        public override async Task<GetAllPatientResponse> GetAllPatient(GetAllPatientRequest request, ServerCallContext context)
        {
            var response = new GetAllPatientResponse();
            var patients = await _dbContext.Patients.ToListAsync();

            foreach (var patient in patients)
            {
                response.Patient.Add(new ReadPatientResponse
                {
                    Id = patient.Id,
                    Name = patient.Name,
                    SurName = patient.SurName,
                    EmailAdress = patient.EmailAdress,
                    PhoneNumber = patient.PhoneNumber,
                    Country = patient.Country,
                    City = patient.City,
                    ZipCode = patient.ZipCode,
                    Street = patient.Street,
                    HouseNumber = patient.HouseNumber,
                    DateOfBirth = patient.DateOfBirth.ToUniversalTime().ToTimestamp()
                }); ;
            }

            return await Task.FromResult(response);
        }

        public override async Task<UpdatePatientResponse> UpdatePatient(UpdatePatientRequest request, ServerCallContext context)
        {
            if (request.Id <= 0 || request.Name == string.Empty || request.SurName == string.Empty)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "You must provide a valid input"));
            }
            var patient = await _dbContext.Patients.FirstOrDefaultAsync(p => p.Id == request.Id);

            if (patient == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"No patient with id {request.Id}"));
            }

            patient.Id = request.Id;
            patient.Name = request.Name;
            patient.SurName = request.SurName;
            patient.EmailAdress = request.EmailAdress;
            patient.PhoneNumber = request.PhoneNumber;
            patient.Country = request.Country;
            patient.City = request.City;
            patient.ZipCode = request.ZipCode;
            patient.Street = request.Street;
            patient.HouseNumber = request.HouseNumber;
            patient.DateOfBirth = request.DateOfBirth.ToDateTime();

            await _dbContext.SaveChangesAsync();

            return await Task.FromResult(new UpdatePatientResponse
            {
                Id = patient.Id
            });
        }

        public override async Task<DeletePatientResponse> DeletePatient(DeletePatientRequest request, ServerCallContext context)
        {
            if (request.Id <= 0)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "You must provide a valid input"));
            }
            var patient = await _dbContext.Patients.FirstOrDefaultAsync(p => p.Id == request.Id);

            if (patient == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"No patient with id {request.Id}"));
            }

            _dbContext.Patients.Remove(patient);
            await _dbContext.SaveChangesAsync();

            return await Task.FromResult(new DeletePatientResponse
            {
                Id = patient.Id
            });
        }

        public override async Task<DeclareDeceasedPatientResponse> DeclareDeceasedPatient(DeclareDeceasedPatientRequest request, ServerCallContext context)
        {
            if (request.Id <= 0 || request.DateOfDeath == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "You must provide a valid input"));
            }
            var patient = await _dbContext.Patients.FirstOrDefaultAsync(p => p.Id == request.Id);

            if (patient == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"No patient with id {request.Id}"));
            }

            patient.Id = request.Id;
            patient.DateOfDeath = request.DateOfDeath.ToDateTime();

            await _dbContext.SaveChangesAsync();

            return await Task.FromResult(new DeclareDeceasedPatientResponse
            {
                Id = patient.Id
            });
        }
    }
}
