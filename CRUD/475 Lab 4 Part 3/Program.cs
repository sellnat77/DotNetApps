using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _475_Lab_4_Part_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create student 1
            Student aaa = new Student();
            aaa.StudentName = "aaa aaa";
            aaa.StudentAddress = new StudentAddress();
            aaa.StudentAddress.Address1 = "123 aaa";
            aaa.StudentAddress.Address2 = "345 aaa";
            aaa.StudentAddress.City = "Long Beach";
            aaa.StudentAddress.State = "California";

            //Create student 2
            Student bbb = new Student();
            bbb.StudentName = "bbb bbb";
            bbb.StudentAddress = new StudentAddress();
            bbb.StudentAddress.Address1 = "123 bbb";
            bbb.StudentAddress.Address2 = "345 bbb";
            bbb.StudentAddress.City = "Long Beach";
            bbb.StudentAddress.State = "California";

            //Create the students in the db
            createStudent(aaa);
            createStudent(bbb);

            //Read all students
            Console.WriteLine(readStudents("aaa aaa"));
            Console.WriteLine(readStudents("bbb bbb"));

            //Update student 1
            updateStudent("aaa aaa","123 aaa new");

            //Read student 1
            Console.WriteLine(readStudents("aaa aaa"));

            //Delete student 1's address
            deleteStudentAddr("aaa aaa");

            //Read all students
            Console.WriteLine(readStudents("aaa aaa"));

            //Create new standards
            Standard full = new Standard();
            Standard part = new Standard();

            full.StandardName = "FT";
            full.Description = "Full-time Instructor";

            part.StandardName = "PT";
            part.Description = "Part-time Instructor";

            //Create new teachers
            Teacher teach1 = new Teacher();
            Teacher teach2 = new Teacher();
            Teacher teach3 = new Teacher();

            teach1.TeacherName = "Teacher Name 1";
            teach2.TeacherName = "Teacher Name 2";
            teach3.TeacherName = "Teacher Name 3";

            teach1.Standard = full;
            teach2.Standard = full;
            teach3.Standard = part;

            full.Teachers.Add(teach1);
            full.Teachers.Add(teach2);
            part.Teachers.Add(teach3);

            //Create the standards and teachers in the db
            createStandard(full);
            createStandard(part);

            createTeacher(teach1);
            createTeacher(teach2);
            createTeacher(teach3);

            //Read all teachers
            Console.WriteLine(readTeachers(teach1.TeacherName,1));
            Console.WriteLine(readTeachers(teach2.TeacherName, 1));
            Console.WriteLine(readTeachers(teach3.TeacherName, 1));

            //Update the full time standard
            updateStandard("FT", "Full-time Instructor Update");

            Console.WriteLine(readTeachers("FT"));

            Console.WriteLine(readTeachers(teach1.TeacherName, 1));
            Console.WriteLine("Teacher 1 id = ", teach1.StandardId);
            Console.WriteLine("Teacher 2 id = ", teach2.StandardId);
            
            teach1.StandardId = teach3.StandardId;
            Console.WriteLine(readTeachers(teach1.TeacherName, 1));
            Console.WriteLine("Teacher 1 id = ", teach1.StandardId);
            Console.WriteLine("Teacher 2 id = ", teach2.StandardId);
         }

        static bool createStudent(Student student)
        {
            //Adds student to db
            using (var contxt = new SchoolDBEntities())
            {
                contxt.Students.Add(student);
                contxt.SaveChanges();
            }
            return true;
        }

        static String readStudents(String studentName)
        {
            var contxt = new SchoolDBEntities();
            string students = "";
            
            //Return all students in db
            if (studentName.Trim().Equals("*"))
            {
                var retStudent = from st in contxt.Students
                                 select st;

                foreach (Student student in retStudent)
                {
                    if (student.StudentName != null && student.StudentAddress != null && student.StudentAddress.Address1 != null && student.StudentAddress.Address2 != null)
                    {
                        students += "\n\n\nName     : " + student.StudentName
                                    + "\nAddress 1: " + student.StudentAddress.Address1
                                    + "\nAddress 2: " + student.StudentAddress.Address2;
                    }
                    else
                    {
                        students += "\n\n\nName     : " + student.StudentName
                                    + "\nAddress 1: null"
                                    + "\nAddress 2: null";
                    }
                }
            }
            else
            {
                var retStudent = contxt.Students.Where(st => st.StudentName == studentName).FirstOrDefault<Student>();
                if (retStudent.StudentName != null && retStudent.StudentAddress != null && retStudent.StudentAddress.Address1 != null && retStudent.StudentAddress.Address2 != null)
                {
                    students += "\n\n\nName     : " + retStudent.StudentName
                                + "\nAddress 1: " + retStudent.StudentAddress.Address1
                                + "\nAddress 2: " + retStudent.StudentAddress.Address2;
                }
                else
                {
                    students += "\n\n\nName     : " + retStudent.StudentName
                                    + "\nAddress 1: null"
                                    + "\nAddress 2: null";
                }
            }
            return students;
        }

        static bool updateStudent(String studentName, String newAddr)
        {
            //Updates a student based on whats passed in to the function
            var contxt = new SchoolDBEntities();
            Student toUpdate;

            toUpdate = contxt.Students.Where(st => st.StudentName == studentName).FirstOrDefault<Student>();

            if(toUpdate != null)
            {
                toUpdate.StudentAddress.Address1 = newAddr;
            }
            else
            {
                return false;
            }
            contxt.Entry(toUpdate).State = System.Data.Entity.EntityState.Modified;
            contxt.SaveChanges();

            return true;
        }

        static bool deleteStudentAddr(String studentName)
        {
            //Removes a particular students address
            Student toDel;
            var contxt = new SchoolDBEntities();

            toDel = contxt.Students.Where(st => st.StudentName == studentName).FirstOrDefault<Student>();
            contxt.Entry(toDel.StudentAddress).State = System.Data.Entity.EntityState.Deleted;
            contxt.SaveChanges();
            return true;
        }

        static bool createStandard(Standard stndrd)
        {
            //Add standard to db
            using (var contxt = new SchoolDBEntities())
            {
                contxt.Standards.Add(stndrd);
                contxt.SaveChanges();
            }
            return true;
        }

        static String readStandards(String standardName)
        {
            var contxt = new SchoolDBEntities();
            string standards = "";

            //Return all standards in db
            if (standardName.Trim().Equals("*"))
            {
                
                var retStandards = from st in contxt.Standards
                                 select st;

                foreach (Standard standard in retStandards)
                {
                    if (standard.Description != null && standard.StandardName != null )
                    {
                        standards += "\n\n\nName     : " + standard.StandardName
                                    + "\nDescription: " + standard.Description;
                    }
                    else
                    {
                        standards += null;
                    }
                }
            }
            else
            {
                var retStandard = contxt.Standards.Where(st => st.StandardName == standardName).FirstOrDefault<Standard>();
                if (retStandard.Description != null && retStandard.StandardName != null)
                {
                    standards += "\n\n\nName     : " + retStandard.StandardName
                                 + "\nDescription: " + retStandard.Description;
                }
                else
                {
                    standards += null;
                }

            }

            return standards;
        }

        static bool updateStandard(String standardName, String newDescription)
        {
            //Change standard description based on what is passed in
            var contxt = new SchoolDBEntities();
            Standard toUpdate;

            toUpdate = contxt.Standards.Where(st => st.StandardName == standardName).FirstOrDefault<Standard>();

            if (toUpdate != null)
            {
                toUpdate.Description = newDescription;
            }
            else
            {
                return false;
            }
            contxt.Entry(toUpdate).State = System.Data.Entity.EntityState.Modified;
            contxt.SaveChanges();

            return true;
        }

        static bool createTeacher(Teacher teach)
        {
            //Add teacher to db
            using (var contxt = new SchoolDBEntities())
            {
                contxt.Teachers.Add(teach);
                contxt.SaveChanges();
            }
            return true;
        }

        static String readTeachers(String standardName)
        {
            var contxt = new SchoolDBEntities();
            string teachers = "";
            //Return all teachers in db
            if (standardName.Trim().Equals("*"))
            {
                var retTeach = from tch in contxt.Teachers
                                 select tch;

                foreach (Teacher teacher in retTeach)
                {
                    if (teacher.TeacherName != null && teacher.Standard.Description != null)
                    {
                        teachers += "\n\n\nName     : " + teacher.TeacherName
                                    + "\nDescription: " + teacher.Standard.Description;
                    }
                    else
                    {
                        teachers += null;
                    }
                }
            }
            //Explicit standard name
            else
            {
                var retTeacher = contxt.Teachers.Where(tch => tch.Standard.StandardName == standardName).FirstOrDefault<Teacher>();
                if (retTeacher.TeacherName != null && retTeacher.Standard.Description!= null)
                {
                    teachers += "\n\n\nName     : " + retTeacher.TeacherName
                                + "\nDescription: " + retTeacher.Standard.Description;
                }
                else
                {
                    teachers += null;
                }
            }
            return teachers;
        }
        static String readTeachers(String teacherName, int byName)
        {
            var contxt = new SchoolDBEntities();
            string teachers = "";
            //Return all teachers in db
            if (teacherName.Trim().Equals("*"))
            {
                var retTeach = from tch in contxt.Teachers
                               select tch;

                foreach (Teacher teacher in retTeach)
                {
                    if (teacher.TeacherName != null && teacher.TeacherName != null)
                    {
                        teachers += "\n\n\nName     : " + teacher.TeacherName
                                    + "\nDescription: " + teacher.Standard.Description;
                    }
                    else
                    {
                        teachers += null;
                    }
                }
            }
            //Explicit teacher name
            else
            {
                var retTeacher = contxt.Teachers.Where(tch => tch.TeacherName == teacherName).FirstOrDefault<Teacher>();
                if (retTeacher.TeacherName != null && retTeacher.TeacherName != null)
                {
                    teachers += "\n\n\nName     : " + retTeacher.TeacherName
                                + "\nDescription: " + retTeacher.Standard.Description;
                }
                else
                {
                    teachers += null;
                }
            }
            return teachers;
        }
        
        //static bool updateTeachID(String newDescription)
        //{
        //    //Change standard description based on what is passed in
        //    var contxt = new SchoolDBEntities();
        //    Standard toUpdate;

        //    toUpdate = contxt.Standards.Where(st => st.StandardName == standardName).FirstOrDefault<Standard>();

        //    if (toUpdate != null)
        //    {
        //        toUpdate.Description = newDescription;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //    contxt.Entry(toUpdate).State = System.Data.Entity.EntityState.Modified;
        //    contxt.SaveChanges();

        //    return true;
        //}
    }
}


