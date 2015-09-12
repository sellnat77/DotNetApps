﻿using System;
using System.Collections;

public abstract class Employee : IComparable<Employee>, IPayable 
{

   // read-only property that gets employee's first name
   public string FirstName { get; private set; }

   // read-only property that gets employee's last name
   public string LastName { get; private set; }

   // read-only property that gets employee's social security number
   public string SocialSecurityNumber { get; private set; }

   // three-parameter constructor
   public Employee(string first, string last, string ssn)
   {
      FirstName = first;
      LastName = last;
      SocialSecurityNumber = ssn;
   } // end three-parameter Employee constructor

   // return string representation of Employee object
   public override string ToString()
   {
      return string.Format("{0} {1}\nsocial security number: {2}", FirstName, LastName, SocialSecurityNumber);
   } // end method ToString

   // Note: We do not implement IPayable method GetPaymentAmount here so
   // this class must be declared abstract to avoid a compilation error.
   public abstract decimal Earnings();

    public static int compareSSNs(Employee emp1, Employee emp2)
   {
        string ssn1 = emp1.SocialSecurityNumber;
        string ssn2 = emp2.SocialSecurityNumber;

        if (String.Compare(ssn1, ssn2) < 0)
        {
            return 1;
        }
        else if (String.Compare(ssn1, ssn2) > 0)
        {
            return -1;
        }
        else
        {
            return 0;
        }
   }

    //public void sortByFName();
   public abstract void sortLNameDesc();

    private class sortLNameDescHelper : IComparer
    {
        int IComparer.Compare(object a, object b)
        {
            Employee e1 = (Employee)a;
            Employee e2 = (Employee)b;

            return string.Compare(e1.LastName, e2.LastName);
        }
    }

    private class sortLNameAscHelper : IComparer
    {
        int IComparer.Compare(object a, object b)
        {
            Employee e1 = (Employee)a;
            Employee e2 = (Employee)b;

            return string.Compare(e1.LastName, e2.LastName)*-1;
        }
    }

    private class sortFNameDescHelper : IComparer
    {
        int IComparer.Compare(object a, object b)
        {
            Employee e1 = (Employee)a;
            Employee e2 = (Employee)b;

            return string.Compare(e1.FirstName, e2.FirstName);
        }
    }

    private class sortSSNDescHelper : IComparer
    {
        int IComparer.Compare(object a, object b)
        {
            Employee e1 = (Employee)a;
            Employee e2 = (Employee)b;

            return string.Compare(e1.SocialSecurityNumber, e2.SocialSecurityNumber);
        }
    }

    private class sortSSNAscHelper : IComparer
    {
        int IComparer.Compare(object a, object b)
        {
            Employee e1 = (Employee)a;
            Employee e2 = (Employee)b;

            return string.Compare(e1.SocialSecurityNumber, e2.SocialSecurityNumber)*-1;
        }
    }

    private class sortEarningsDescHelper : IComparer
    {
        int IComparer.Compare(object a, object b)
        {
            Employee e1 = (Employee)a;
            Employee e2 = (Employee)b;

            if (e1.Earnings() < e2.Earnings())
                return 1;
            if (e1.Earnings() > e2.Earnings())
                return -1;
            else
                return 0;
        }
    }

    private class sortEarningsAscHelper : IComparer
    {
        int IComparer.Compare(object a, object b)
        {
            Employee e1 = (Employee)a;
            Employee e2 = (Employee)b;

            if (e1.Earnings() > e2.Earnings())
                return 1;
            if (e1.Earnings() < e2.Earnings())
                return -1;
            else
                return 0;
        }
    }

    int IComparable<Employee>.CompareTo(Employee obj)
    {
        Employee emp = (Employee)obj;
        return String.Compare(this.LastName, emp.LastName);
    }

    public static IComparer sortByLNameDesc()
    {
        return (IComparer) new sortLNameDescHelper();
    }
    
    public static IComparer sortByLNameAsc()
    {
        return (IComparer)new sortLNameAscHelper();
    }

    public static IComparer sortBySSNDesc()
    {
        return (IComparer)new sortSSNDescHelper();
    }

    public static IComparer sortBySSNAsc()
    {
        return (IComparer)new sortSSNAscHelper();
    }

    public static IComparer sortByEarningsDesc()
    {
        return (IComparer)new sortEarningsDescHelper();
    }

    public static IComparer sortByEarningsAsc()
    {
        return (IComparer)new sortEarningsAscHelper();
    }

   //public void sortBySSN();
   //public void sortByPay();
} // end abstract class Employee