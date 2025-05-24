using Anastasia_Vinokurova_KT_31_22.Models;
using Xunit;
using Anastasia_Vinokurova_KT_31_22.Models;
using Xunit;

namespace Anastasia_Vinokurova_KT_31_22.Tests.UnitTests
{
    public class PrepodTests
    {
        [Theory]
        [InlineData("Иван", "Иванов", "Иванович", 1, 1, 1, true)]  
        [InlineData("", "Иванов", "Иванович", 1, 1, 1, false)]     
        [InlineData("Иван", "", "Иванович", 1, 1, 1, false)]       
        [InlineData("Иван", "Иванов", null, 1, 1, 1, true)]      
        [InlineData("Иван", "Иванов", "Иванович", 0, 1, 1, false)] 
        public void PrepodValidation_TestCases_ExpectedResults(
            string firstName, string lastName, string middleName,
            int Academic_degreeId, int ТitleId, int facultyId, bool expectedResult)
        {
            // Arrange
            var prepod = new Prepod
            {
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName,
                Academic_degreeId = Academic_degreeId,
                ТitleId = ТitleId,
                facultyId = facultyId
            };

            // Act
            var isValid = !string.IsNullOrEmpty(prepod.FirstName) &&
                         !string.IsNullOrEmpty(prepod.LastName) &&
                         prepod.Academic_degreeId > 0 &&
                         prepod.ТitleId > 0 &&
                         prepod.facultyId > 0;

            // Assert
            Assert.Equal(expectedResult, isValid);
        }
    }
}