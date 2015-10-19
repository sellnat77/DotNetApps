using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudProject
{
    class Program
    {
        static void Main(string[] args)
        {
            readStudents();

        }

        static void createStudents(Student student)
        {
            using (var contxt = new SchoolDBEntities())
            {
                contxt.Students.Add(student);
                contxt.SaveChanges();
            }
        }

        static void readStudents()
        {
            SchoolDBEntities school = new SchoolDBEntities();
            var students = from st in school.Students 
                            select st;
            foreach(var st in students)
            {
                Console.WriteLine(st.StudentName);
            }
        }

        static void updateStudents()
        {

        }

        static void deleteStudents()
        {

        }

        static void createStandard()
        {

        }

        static void readStandard()
        {
            SchoolDBEntities standard = new SchoolDBEntities();
            var standards = from st in standard.Standards
                           select st;
            foreach (var st in standards)
            {
                Console.WriteLine(st.Name);
            }
        }

        static void updateStandard()
        {

        }

        static void deleteStandard()
        {

        }
    }
}
