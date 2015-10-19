﻿using System;
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
            Student aaa = new Student();
            aaa.StudentName = "aaa aaa";
            aaa.StudentAddress = new StudentAddress();
            aaa.StudentAddress.Address1 = "123 aaa";
            aaa.StudentAddress.Address2 = "345 aaa";
            aaa.StudentAddress.City = "Long Beach";
            aaa.StudentAddress.State = "California";

            Student bbb = new Student();
            bbb.StudentName = "bbb bbb";
            bbb.StudentAddress = new StudentAddress();
            bbb.StudentAddress.Address1 = "123 bbb";
            bbb.StudentAddress.Address2 = "345 bbb";
            bbb.StudentAddress.City = "Long Beach";
            bbb.StudentAddress.State = "California";


            createStudent(aaa);
            createStudent(bbb);

            Console.WriteLine(readStudents("*"));

            updateStudent("aaa aaa");

            Console.WriteLine(readStudents("aaa aaa"));

            deleteStudentAddr("aaa aaa");

            Console.WriteLine(readStudents("aaa aaa"));
            Console.WriteLine(readStudents("*"));

            Standard full = new Standard();
            Standard part = new Standard();

            full.StandardName = "FT";
            full.Description = "Full-time Instructor";

            part.StandardName = "PT";
            part.Description = "Part-time Instructor";

            Teacher teach1 = new Teacher();
            Teacher teach2 = new Teacher();
            Teacher teach3 = new Teacher();

            teach1.TeacherName = "Teacher Name 1";
            teach2.TeacherName = "Teacher Name 2";
            teach3.TeacherName = "Teacher Name 3";

            teach1.Standard = full;
            teach2.Standard = full;
            teach3.Standard = part;

            createStandard(full);
            createStandard(part);

            createTeacher(teach1);
            createTeacher(teach2);
            createTeacher(teach3);

            Console.WriteLine(readTeachers("*"));

            updateStandard("FT");

            Console.WriteLine(readTeachers("FT"));
            Console.WriteLine(readStandards("*"));


        }

        static bool createStudent(Student student)
        {

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
            if (studentName.Trim().Equals("*"))
            {
                //Return all students in db
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
                        students += null;
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
                    students += null;
                }

            }

            return students;
        }

        static bool updateStudent(String studentName)
        {
            var contxt = new SchoolDBEntities();
            Student toUpdate;

            toUpdate = contxt.Students.Where(st => st.StudentName == studentName).FirstOrDefault<Student>();

            if(toUpdate != null)
            {
                toUpdate.StudentAddress.Address1 = "123 aaa new";
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
            Student toDel;
            var contxt = new SchoolDBEntities();

            toDel = contxt.Students.Where(st => st.StudentName == studentName).FirstOrDefault<Student>();
            contxt.Entry(toDel.StudentAddress).State = System.Data.Entity.EntityState.Deleted;
            contxt.SaveChanges();
            return true;
        }

        static bool createStandard(Standard stndrd)
        {

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
            if (standardName.Trim().Equals("*"))
            {
                //Return all students in db
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

        static bool updateStandard(String standardName)
        {
            var contxt = new SchoolDBEntities();
            Standard toUpdate;

            toUpdate = contxt.Standards.Where(st => st.StandardName == standardName).FirstOrDefault<Standard>();

            if (toUpdate != null)
            {
                toUpdate.Description = "Full-time Instructor Update";
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

            using (var contxt = new SchoolDBEntities())
            {
                contxt.Teachers.Add(teach);
                contxt.SaveChanges();
            }
            return true;
        }

        static String readTeachers(String teachName)
        {
            var contxt = new SchoolDBEntities();
            string teachers = "";
            if (teachName.Trim().Equals("*"))
            {
                //Return all students in db
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
            else
            {

                var retTeacher = contxt.Teachers.Where(tch => tch.Standard.StandardName == teachName).FirstOrDefault<Teacher>();
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
        /*
        static bool updateTeacher(String studentName)
        {
            var contxt = new SchoolDBEntities();
            Student toUpdate;

            toUpdate = contxt.Students.Where(st => st.StudentName == studentName).FirstOrDefault<Student>();

            if (toUpdate != null)
            {
                toUpdate.StudentAddress.Address1 = "123 aaa new";
            }
            else
            {
                return false;
            }
            contxt.Entry(toUpdate).State = System.Data.Entity.EntityState.Modified;
            contxt.SaveChanges();

            return true;
        }

        static bool deleteTeacherAddr(String studentName)
        {
            Student toDel;
            var contxt = new SchoolDBEntities();

            toDel = contxt.Students.Where(st => st.StudentName == studentName).FirstOrDefault<Student>();
            contxt.Entry(toDel.StudentAddress).State = System.Data.Entity.EntityState.Deleted;
            contxt.SaveChanges();
            return true;
        }
        */

    }
}


