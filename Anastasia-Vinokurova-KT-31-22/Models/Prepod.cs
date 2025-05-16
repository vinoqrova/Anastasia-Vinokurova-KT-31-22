using System.Text.Json.Serialization;

namespace Anastasia_Vinokurova_KT_31_22.Models
{
    public class Prepod
    {
        public int PrepodId { get; set; }

        public string FirstName { get; set;}

        public string LastName { get; set;}

        public string MiddleName { get; set;}

        public int DegreeId { get; set; }
        public Degree Degree { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }

        public int CafedraId { get; set; }

        public Cafedra Cafedra { get; set; }
        
    }
}
