//using Microsoft.IdentityModel.Tokens;
using System.CodeDom;

namespace Anastasia_Vinokurova_KT_31_22.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }

        public string SubjectName { get; set; }

        public bool IsDeleted { get; set; } = false;

        public bool IsEmptyName()
        {
            return  SubjectName.Length == 0; 
        }
    }
}
