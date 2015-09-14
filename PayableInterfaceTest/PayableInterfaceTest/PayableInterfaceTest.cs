using System;

//Delegate instantiation
public delegate int Comparer(Employee emp1, Employee emp2);

public class PayrollSystemTest
{
    //Declaring the payable objects ill be using
    IPayable[] payableObjects = new IPayable[8];

    //Constructor
    public PayrollSystemTest()
    {
        payableObjects[0] = new SalariedEmployee("John", "Smith", "111-11-1111", 700M);
        payableObjects[1] = new SalariedEmployee("Antonio", "Smith", "555-55-5555", 800M);
        payableObjects[2] = new SalariedEmployee("Victor", "Smith", "444-44-4444", 600M);
        payableObjects[3] = new HourlyEmployee("Karen", "Price", "222-22-2222", 16.75M, 40M);
        payableObjects[4] = new HourlyEmployee("Ruben", "Zamora", "666-66-6666", 20.00M, 40M);
        payableObjects[5] = new CommissionEmployee("Sue", "Jones", "333-33-3333", 10000M, .06M);
        payableObjects[6] = new BasePlusCommissionEmployee("Bob", "Lewis", "777-77-7777", 5000M, .04M, 300M);
        payableObjects[7] = new BasePlusCommissionEmployee("Lee", "Duarte", "888-88-888", 5000M, .04M, 300M);
    }

    //Entry point into the program
    public static void Main(string[] args)
    {
        //Initializing the constructor
        PayrollSystemTest payrollInstance = new PayrollSystemTest();

        //Initializing the delegate
        Comparer cmp = new Comparer(Employee.compareSSNs);

        bool again = true;

        //Loop to handle menu options
        while (again)
        {
            Console.WriteLine("\n\n1.) Sort by social security number in ascending order");
            Console.WriteLine("2.) Sort by last name in ascending order");
            Console.WriteLine("3.) Sort by pay amount in descending order");
            Console.WriteLine("4.) Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    //Sort by ssn Asc
                    Console.WriteLine("SORTING BY SSN Ascending\n\n");
                    
                    payrollInstance.sortSSNs(cmp);

                    foreach (var currentPayable in payrollInstance.payableObjects)
                    {
                        Console.WriteLine("{0}: {1:C}\n", currentPayable, currentPayable.Earnings());
                    }
                    break;

                case "2":
                    //Sort by last name Desc
                    Console.WriteLine("SORTING BY LAST NAME Ascending\n\n");
                    Array.Sort(payrollInstance.payableObjects, Employee.sortByLNameAsc());
                    foreach (var currentPayable in payrollInstance.payableObjects)
                    {
                        Console.WriteLine("{0}: {1:C}\n", currentPayable, currentPayable.Earnings());
                    }
                    break;

                case "3":
                    //Sort by $ Dsc
                    //Using Comparable's default sort order by overriding the CompareTo method
                    Console.WriteLine("SORTING BY PAY Decending\n\n");
                    int k;
                    Employee[] empCopies = new Employee[payrollInstance.payableObjects.Length];
                    for(k = 0; k < payrollInstance.payableObjects.Length; k++)
                    {
                        empCopies[k] = (Employee)payrollInstance.payableObjects[k];
                    }

                    //CompareTo is implemented in the Employee class so the Array of IPayables was casted to Employee
                    //So we can use the default sort on the earnings
                    Array.Sort(empCopies);

                    foreach (var currentPayable in empCopies)
                    {
                        Console.WriteLine("{0}: {1:C}\n", currentPayable, currentPayable.Earnings());
                    }
                    break;

                    //Default case catches when user wants to exit
                default:
                    again = false;
                    Console.WriteLine("Thank you!");
                    break;
            }
        }
    } // end Main

    //Method written here for the delegate
    public void sortSSNs(Comparer compare)
    {
        IPayable temp;

        //Bubble Sor
        for(int j = 0; j < payableObjects.Length; j++)
        {
            for (int k = 0; k < payableObjects.Length; k++)
            {
                //Using the delegate to compare the objects, the delegate grabs the ssns and compares them
                //Explicit cast needed since the compare method is implemented in the employee class
                if (compare((Employee)payableObjects[j], (Employee)payableObjects[k]) > 0)
                {
                    //Swap
                    temp = payableObjects[j];
                    payableObjects[j] = payableObjects[k];
                    payableObjects[k] = temp;
                }
            }
        }
    }
} // end class PayrollSystemTest