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

    //Method for the delegate compare
   public static int compareSSNs(Employee emp1, Employee emp2, SortType order)
   {
        string ssn1 = emp1.SocialSecurityNumber;
        string ssn2 = emp2.SocialSecurityNumber;

        if ( order == SortType.Ascending)
        {
            //Compares the ssns
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
        else
        {
            //Compares the ssns
            if (String.Compare(ssn1, ssn2) > 0)
            {
                return 1;
            }
            else if (String.Compare(ssn1, ssn2) < 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
   }
    
    //Helper method for sorting the last name using icomparer
    private class sortLNameAscHelper : IComparer
    {
        int IComparer.Compare(object a, object b)
        {
            Employee e1 = (Employee)a;
            Employee e2 = (Employee)b;

            return string.Compare(e1.LastName, e2.LastName);
        }
    }

    //Overriding the default CompareTo method to use with the delegate
    int IComparable<Employee>.CompareTo(Employee obj)
    {
        //Forcing the default sort to work on the earnings
        Employee emp = (Employee)obj;
        return this.Earnings().CompareTo(emp.Earnings())*-1;
    }
    
    //Method to be used by an outside class to sort last names
    public static IComparer sortByLNameAsc()
    {
        return (IComparer)new sortLNameAscHelper();
    }

} // end abstract class Employee