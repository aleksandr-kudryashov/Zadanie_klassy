using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_Klassy
{
    public static class DataAccess
    {
        public static decimal GirlK { get; set; } = 0.67M;
        public static decimal StipendyAmount { get; set; } = 5000M;
    }
    public abstract class Student
    {
        // имена студентов
        public string Name { get; set; }
        //  группа
        public int Group { get; set; }
        // их пол
        public string Gender { get; protected set; }
        // средний балл
        public double Midlemark { get; set; }
        // Получает ли стипендию
        public bool HasStipendy => Stipendy > 0;

        public abstract decimal Stipendy { get; }
    }

    public class MenStudent : Student
    {
        public MenStudent()
        {
            Gender = "Мужчина";
        }

        /// <summary>
        /// Парням выплачивается фиксированная стипендия, если их средний балл не менее 4
        /// </summary>
        public override decimal Stipendy => Midlemark >= 4 ? DataAccess.StipendyAmount : 0;
    }

    public class GirlStudent : Student
    {
        public GirlStudent()
        {
            Gender = "Женщина";
        }

        public override decimal Stipendy => DataAccess.StipendyAmount * DataAccess.GirlK;
    }

    class Program
    {
        static void Main(string[] args)
        {
            MenStudent myStudent1 = new MenStudent();
            GirlStudent myStudent2 = new GirlStudent();

            myStudent1.Name = "Василий Олегович Пупкин";
            myStudent1.Group = 107;
            myStudent1.Midlemark = 4.8;

            myStudent2.Name = "Казакова Александра Борисовна";
            myStudent2.Group = 345;
            myStudent2.Midlemark = 4.8;

            Console.WriteLine(GetInfo(myStudent1));
            Console.WriteLine(GetInfo(myStudent2));

            Console.ReadKey();
        }

        static string GetInfo(Student student)
        {
            string stipendyInfo;
            if (student.HasStipendy)
                stipendyInfo = $"получает стипендию {student.Stipendy}";
            else
                stipendyInfo = "не получает стипендию";
            var s = $"{student.Name} {student.Gender} {stipendyInfo}";
            return s;
        }
    }
}