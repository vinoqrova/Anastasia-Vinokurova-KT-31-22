namespace Anastasia_Vinokurova_KT_31_22.Models
{
    public class Cafedra
    {
        public int CafedraId { get; set; }

        public string CafedraName { get; set; }
        public int AdminId { get; set; }
        public Prepod Admin { get; internal set; }
    }
}
