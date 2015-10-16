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

        }

        static void updateStandard()
        {

        }

        static void deleteStandard()
        {

        }
    }
}
