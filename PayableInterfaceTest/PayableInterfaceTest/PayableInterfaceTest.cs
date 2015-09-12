using System;

public delegate int Comparer(Employee emp1, Employee emp2);

public class PayrollSystemTest
{
    IPayable[] payableObjects = new IPayable[8];

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

    public static void Main(string[] args)
    {
        PayrollSystemTest empDelegate = new PayrollSystemTest();

        Comparer cmp = new Comparer(Employee.compareSSNs);

        bool again = true;

        while (again)
        {
            Console.WriteLine("1.) Sort by social security number in ascending order");
            Console.WriteLine("2.) Sort by last name in descending order");
            Console.WriteLine("3.) Sort by pay amount in ascending order");
            Console.WriteLine("4.) Sort by pay amount in descending order");
            Console.WriteLine("5.) Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    //Sort by ssn Asc
                    Console.WriteLine("SORTING BY SSN\n\n");
                    
                    empDelegate.sortSSNs(cmp);

                    foreach (var currentPayable in empDelegate.payableObjects)
                    {
                        Console.WriteLine("payment due {0}: {1:C}\n", currentPayable, currentPayable.Earnings());
                    }
                    break;
                case "2":
                    //Sort by last name Desc
                    Console.WriteLine("SORTING BY LAST NAME\n\n");
                    Array.Sort(empDelegate.payableObjects, Employee.sortByLNameAsc());
                    foreach (var currentPayable in empDelegate.payableObjects)
                    {
                        Console.WriteLine("payment due {0}: {1:C}\n", currentPayable, currentPayable.Earnings());
                    }
                    break;
                case "3":
                    //Sort by $ Asc
                    Console.WriteLine("SORTING BY PAY\n\n");
                    Array.Sort(empDelegate.payableObjects, Employee.sortByEarningsAsc());
                    foreach (var currentPayable in empDelegate.payableObjects)
                    {
                        Console.WriteLine("payment due {0}: {1:C}\n", currentPayable, currentPayable.Earnings());
                    }
                    break;
                case "4":
                    //Sort by $ Desc
                    Console.WriteLine("SORTING BY PAY\n\n");
                    Array.Sort(empDelegate.payableObjects, Employee.sortByEarningsDesc());
                    foreach (var currentPayable in empDelegate.payableObjects)
                    {
                        Console.WriteLine("payment due {0}: {1:C}\n", currentPayable, currentPayable.Earnings());
                    }
                    break;
                default:
                    again = false;
                    Console.WriteLine("Thank you!");
                    break;
            }
        }

    } // end Main

    public void sortSSNs(Comparer compare)
    {
        IPayable temp;

        for(int j = 0; j < payableObjects.Length; j++)
        {
            for (int k = 0; k < payableObjects.Length; k++)
            {
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