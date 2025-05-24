using Anastasia_Vinokurova_KT_31_22.Models;
using Xunit;
namespace Anastasia_Vinokurova_KT_31_22.Tests.UnitTests
{
    public class facultyTests
    {
        [Theory]
        [InlineData("Кафедра информатики", 1, true)]    
        [InlineData("", 1, false)]                     
        [InlineData("Кафедра информатики", 0, false)]  
        [InlineData(null, 1, false)]                  
        public void facultyValidation_TestCases_ExpectedResults(
            string facultyName, int adminId, bool expectedResult)
        {
            // Arrange
            var faculty = new faculty
            {
                facultyName = facultyName,
                AdminId = adminId
            };

            // Act
            var isValid = !string.IsNullOrEmpty(faculty.facultyName) &&
                         faculty.AdminId > 0;

            // Assert
            Assert.Equal(expectedResult, isValid);
        }
    }
}