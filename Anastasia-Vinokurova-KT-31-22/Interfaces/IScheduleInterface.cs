using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Anastasia_Vinokurova_KT_31_22.Databases;
using Anastasia_Vinokurova_KT_31_22.Filters;
using Anastasia_Vinokurova_KT_31_22.Models;

namespace Anastasia_Vinokurova_KT_31_22.Interfaces
{
    public interface IScheduleService
    {
        public Task<Schedule> GetScheduleAsync(int scheduleId, CancellationToken cancellationToken);

        public Task<List<Schedule>> GetFilteredSchedules(ScheduleFilter scheduleFilter, CancellationToken cancellationToken);
    }

    public class ScheduleService : IScheduleService
    {
        private readonly PrepodDbContext _dbContext;

        public ScheduleService(PrepodDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Schedule> GetScheduleAsync(int scheduleId, CancellationToken cancellationToken)
        {
            var schedule = _dbContext.Set<Schedule>().FirstOrDefaultAsync<Schedule>( e => (e.Id == scheduleId), cancellationToken);

            return schedule;
        }

        public Task<List<Schedule>> GetFilteredSchedules(ScheduleFilter scheduleFilter, CancellationToken cancellationToken)
        {  
            var schedule = _dbContext.Set<Schedule>().ToList();

            if (scheduleFilter.SubjectId != default)
            {
                schedule = schedule.Where(p => p.SubjectId == scheduleFilter.SubjectId).ToList();
            }

            if (scheduleFilter.PrepodId != default)
            {
                schedule = schedule.Where(p => p.PrepodId == scheduleFilter.PrepodId).ToList();
            }

            if (scheduleFilter.facultyId != default)
            {
                schedule = schedule.Where(p => p.Prepod.facultyId == scheduleFilter.facultyId).ToList();
            }

            return Task.FromResult(schedule);
        }
    }
}
