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
using Anastasia_Vinokurova_KT_31_22.Controllers;
using Anastasia_Vinokurova_KT_31_22.Interfaces;
namespace Anastasia_Vinokurova_KT_31_22.Tests.IntegrationTests
{
    public class PrepodIntegrationTests
    {
        private DbContextOptions<PrepodDbContext> _dbContextOptions;

        public PrepodIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<PrepodDbContext>()
                .UseInMemoryDatabase(databaseName: "PrepodTestDb")
                .Options;
        }

        [Fact]
        public async Task AddPrepod_ValidData_PrepodAddedSuccessfully()
        {
            // Arrange
            using (var context = new PrepodDbContext(_dbContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                // Добавляем необходимые связанные данные
                var Academic_degree = new Academic_Academic_degree { Academic_degreeName = "Кандидат наук" };
                var Тitle = new Тitle { ТitleName = "Доцент" };
                var faculty = new faculty { facultyName = "Кафедра информатики", AdminId = 1 };

                await context.Set<Academic_Academic_degree>().AddAsync(Academic_degree);
                await context.Set<Тitle>().AddAsync(Тitle);
                await context.Set<faculty>().AddAsync(faculty);
                await context.SaveChangesAsync();

                var prepod = new Prepod
                {
                    FirstName = "Иван",
                    LastName = "Иванов",
                    MiddleName = "Иванович",
                    Academic_degreeId = Academic_degree.Academic_degreeId,
                    ТitleId = Тitle.ТitleId,
                    facultyId = faculty.facultyId
                };

                // Act
                await context.Set<Prepod>().AddAsync(prepod);
                await context.SaveChangesAsync();

                // Assert
                var savedPrepod = await context.Set<Prepod>().FirstOrDefaultAsync();
                Assert.NotNull(savedPrepod);
                Assert.Equal("Иван", savedPrepod.FirstName);
                Assert.Equal("Иванов", savedPrepod.LastName);
                Assert.Equal(Academic_degree.Academic_degreeId, savedPrepod.Academic_degreeId);
            }
        }

        [Fact]
        public async Task GetPrepodWithRelatedData_ValidId_ReturnsPrepodWithAllData()
        {
            // Arrange
            using (var context = new PrepodDbContext(_dbContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var Academic_degree = new Academic_Academic_degree { Academic_degreeName = "Кандидат наук" };
                var Тitle = new Тitle { ТitleName = "Доцент" };
                var faculty = new faculty { facultyName = "Кафедра информатики", AdminId = 1 };

                await context.Set<Academic_Academic_degree>().AddAsync(Academic_degree);
                await context.Set<Тitle>().AddAsync(Тitle);
                await context.Set<faculty>().AddAsync(faculty);
                await context.SaveChangesAsync();

                var prepod = new Prepod
                {
                    FirstName = "Иван",
                    LastName = "Иванов",
                    MiddleName = "Иванович",
                    Academic_degreeId = Academic_degree.Academic_degreeId,
                    ТitleId = Тitle.ТitleId,
                    facultyId = faculty.facultyId
                };

                await context.Set<Prepod>().AddAsync(prepod);
                await context.SaveChangesAsync();
            }

            // Act
            using (var context = new PrepodDbContext(_dbContextOptions))
            {
                var result = await context.Set<Prepod>()
                    .Include(p => p.Academic_degree)
                    .Include(p => p.Тitle)
                    .Include(p => p.faculty)
                    .FirstOrDefaultAsync();

                // Assert
                Assert.NotNull(result);
                Assert.NotNull(result.Academic_degree);
                Assert.NotNull(result.Тitle);
                Assert.NotNull(result.faculty);
                Assert.Equal("Кандидат наук", result.Academic_degree.Academic_degreeName);
                Assert.Equal("Доцент", result.Тitle.ТitleName);
                Assert.Equal("Кафедра информатики", result.faculty.facultyName);
            }
        }
    }
}