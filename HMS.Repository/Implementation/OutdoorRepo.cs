using HMS.DAL.Data;
using HMS.Models;
using HMS.Repository.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Repository.Implementation
{
    public class OutdoorRepo : IOutdoorRepo
    {
        private readonly HospitalDbContext _dbContext;

        public OutdoorRepo(HospitalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Outdoor> GetByIdAsync(int id)
        {
            return await _dbContext
                        .Outdoors
                        .FromSqlRaw("EXEC GetOutdoorById @Id", new SqlParameter("@Id", id))
                        .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Outdoor>> GetAllAsync()
        {
            return await _dbContext
                        .Outdoors
                        .FromSqlRaw("EXEC GetAllOutdoors")
                        .ToListAsync();
        }

        public async Task<IEnumerable<Outdoor>> GetByPatientIdAsync(int patientId)
        {
            return await _dbContext
                        .Outdoors
                        .FromSqlRaw("EXEC GetOutdoorsByPatientId @PatientId", new SqlParameter("@PatientId", patientId))
                        .ToListAsync();
        }

        public async Task<IEnumerable<Outdoor>> GetByTreatmentTypeAsync(TreatmentType treatmentType)
        {
            return await _dbContext
                        .Outdoors
                        .FromSqlRaw("EXEC GetOutdoorsByTreatmentType @TreatmentType", new SqlParameter("@TreatmentType", (int)treatmentType))
                        .ToListAsync();
        }

        public async Task<IEnumerable<Outdoor>> GetByTreatmentDateAsync(DateTime treatmentDate)
        {
            return await _dbContext
                        .Outdoors
                        .FromSqlRaw("EXEC GetOutdoorsByTreatmentDate @TreatmentDate", new SqlParameter("@TreatmentDate", treatmentDate))
                        .ToListAsync();
        }

        public async Task<IEnumerable<Outdoor>> GetByDoctorIdAsync(int doctorId)
        {
            return await _dbContext
                        .Outdoors
                        .FromSqlRaw("EXEC GetOutdoorsByDoctorId @DoctorId", new SqlParameter("@DoctorId", doctorId))
                        .ToListAsync();
        }

        public async Task AddAsync(Outdoor outdoor)
        {
            var parameters = new List<SqlParameter>
        {
            new SqlParameter("@PatientID", outdoor.PatientID),
            new SqlParameter("@TreatmentType", (int)outdoor.TreatmentType),
            new SqlParameter("@TreatmentDate", outdoor.TreatmentDate),
            new SqlParameter("@TicketNumber", outdoor.TicketNumber),
            new SqlParameter("@DoctorID", outdoor.DoctorID),
            new SqlParameter("@Remarks", outdoor.Remarks),
            new SqlParameter("@IsAdmissionRequired", outdoor.IsAdmissionRequired)
        };

            await _dbContext.Database
                .ExecuteSqlRawAsync("EXEC AddOutdoor @PatientID, @TreatmentType, @TreatmentDate, @TicketNumber, @DoctorID, @Remarks, @IsAdmissionRequired", parameters
                .ToArray());
        }

        public async Task UpdateAsync(Outdoor outdoor)
        {
            var parameters = new List<SqlParameter>
        {
            new SqlParameter("@OutdoorID", outdoor.OutdoorID),
            new SqlParameter("@PatientID", outdoor.PatientID),
            new SqlParameter("@TreatmentType", (int)outdoor.TreatmentType),
            new SqlParameter("@TreatmentDate", outdoor.TreatmentDate),
            new SqlParameter("@TicketNumber", outdoor.TicketNumber),
            new SqlParameter("@BillID", outdoor.BillID),
            new SqlParameter("@DoctorID", outdoor.DoctorID),
            new SqlParameter("@Remarks", outdoor.Remarks),
            new SqlParameter("@IsAdmissionRequired", outdoor.IsAdmissionRequired)
        };

            await _dbContext.Database
                .ExecuteSqlRawAsync("EXEC UpdateOutdoor @OutdoorID, @PatientID, @TreatmentType, @TreatmentDate, @TicketNumber, @BillID, @DoctorID, @Remarks, @IsAdmissionRequired", parameters
                .ToArray());
        }

        public async Task DeleteAsync(int id)
        {
            await _dbContext.Database
                .ExecuteSqlRawAsync("EXEC DeleteOutdoor @OutdoorID", new SqlParameter("@OutdoorID", id));
        }
    }
}
