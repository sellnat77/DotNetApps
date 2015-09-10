using System;
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

    private class sortEarningsAsscHelper : IComparer
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

    int IComparable.CompareTo(object obj)
    {
        Employee emp = (Employee)obj;
        return String.Compare(this.LastName, emp.LastName);
    }
   //public void sortBySSN();
   //public void sortByPay();
} // end abstract class Employee