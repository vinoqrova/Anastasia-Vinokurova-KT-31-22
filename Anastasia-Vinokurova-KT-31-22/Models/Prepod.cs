using System.Text.Json.Serialization;

namespace Anastasia_Vinokurova_KT_31_22.Models
{
    public class Prepod
    {
        public int PrepodId { get; set; }

        public string FirstName { get; set;}

        public string LastName { get; set;}

        public string MiddleName { get; set;}

        public int Academic_degreeId { get; set; }
        public Academic_Academic_degree Academic_degree { get; set; }
        public int ТitleId { get; set; }
        public Тitle Тitle { get; set; }

        public int facultyId { get; set; }

        public faculty faculty { get; set; }
        
    }
}
