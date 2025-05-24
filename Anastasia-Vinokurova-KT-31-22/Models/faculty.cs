namespace Anastasia_Vinokurova_KT_31_22.Models
{
    public class faculty
    {
        public int facultyId { get; set; }

        public string facultyName { get; set; }
        public int AdminId { get; set; }
        public Prepod Admin { get; internal set; }
    }
}
