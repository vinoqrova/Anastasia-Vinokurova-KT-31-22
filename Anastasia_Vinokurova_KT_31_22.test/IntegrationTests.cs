using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anastasia_Vinokurova_KT_31_22.Databases;
using Moq;
using Anastasia_Vinokurova_KT_31_22.Models;
namespace Anastasia_Vinokurova_KT_31_22.Tests.IntegrationTests
{
    public class ScheduleIntegrationTests
    {
        private DbContextOptions<PrepodDbContext> _dbContextOptions;

        public ScheduleIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<PrepodDbContext>()
                .UseInMemoryDatabase(databaseName: "ScheduleTestDb")
                .Options;
        }

        [Fact]
        public async Task AddScheduleEntry_ValidData_EntryAddedSuccessfully()
        {
            // Arrange
            using (var context = new PrepodDbContext(_dbContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                // Добавляем необходимые связанные данные
                var subject = new Subject { SubjectName = "Программирование" };
                var Academic_degree = new Academic_Academic_degree { Academic_degreeName = "Кандидат наук" };
                var Тitle = new Тitle { ТitleName = "Доцент" };
                var faculty = new faculty { facultyName = "Кафедра информатики", AdminId = 1 };
                var prepod = new Prepod
                {
                    FirstName = "Иван",
                    LastName = "Иванов",
                    MiddleName = "Иванович",
                    Academic_degreeId = Academic_degree.Academic_degreeId,
                    ТitleId = Тitle.ТitleId,
                    facultyId = faculty.facultyId
                };

                await context.Set<Subject>().AddAsync(subject);
                await context.Set<Academic_Academic_degree>().AddAsync(Academic_degree);
                await context.Set<Тitle>().AddAsync(Тitle);
                await context.Set<faculty>().AddAsync(faculty);
                await context.Set<Prepod>().AddAsync(prepod);
                await context.SaveChangesAsync();

                var schedule = new Schedule
                {
                    SubjectId = subject.SubjectId,
                    PrepodId = prepod.PrepodId,
                };

                // Act
                await context.Set<Schedule>().AddAsync(schedule);
                await context.SaveChangesAsync();

                // Assert
                var savedSchedule = await context.Set<Schedule>()
                    .Include(s => s.Subject)
                    .Include(s => s.Prepod)
                    .FirstOrDefaultAsync();

                Assert.NotNull(savedSchedule);
                Assert.Equal("Программирование", savedSchedule.Subject.SubjectName);
                Assert.Equal("Иванов", savedSchedule.Prepod.LastName);
                Assert.Equal(1, (double)savedSchedule.DayOfWeek);
                Assert.Equal(1, (double)savedSchedule.OrderInDay);
            }
        }
    }
}