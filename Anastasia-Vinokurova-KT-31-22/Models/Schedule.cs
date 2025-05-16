using System.Diagnostics;

namespace Anastasia_Vinokurova_KT_31_22.Models
{
    public class Schedule
    {
        public int Id { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int PrepodId { get; set; }
        public Prepod Prepod { get; set; }

        public DayOfWeek DayOfWeek { get; set; }  // 1-6 Понедельник - Суббота
        public ClassOrder OrderInDay { get; set; } // 1-8 пара за день

        public bool IsValidSubject()
        {
            return Subject != null;
        }
        public bool IsValidPrepod()
        {
            return Prepod != null;
        }

        public bool IsValidSchedule()
        {
            return IsValidPrepod() && IsValidSubject();
        }
    }
    public enum DayOfWeek
    {
        Monday = 1, //пн
        Tuesday = 2, //вт
        Wednesday = 3, //ср
        Thursday = 4, //чт
        Friday = 5, //пт
        Saturday = 6 //сб
    }

    public enum ClassOrder
    {
        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4,
        Fifth = 5,
        Sixth = 6,
        Seventh = 7,
        Eighth = 8
    }
}
