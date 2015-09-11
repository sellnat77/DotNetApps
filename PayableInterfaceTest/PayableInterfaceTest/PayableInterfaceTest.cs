using System;

public class PayrollSystemTest
{
    public static void Main(string[] args)
    {
        // create derived class objects
        SalariedEmployee salariedEmployee =
           new SalariedEmployee("John", "Smith", "111-11-1111", 800.00M);
        HourlyEmployee hourlyEmployee =
           new HourlyEmployee("Karen", "Price",
           "222-22-2222", 16.75M, 40.0M);
        CommissionEmployee commissionEmployee =
           new CommissionEmployee("Sue", "Jones",
           "333-33-3333", 10000.00M, .06M);
        BasePlusCommissionEmployee basePlusCommissionEmployee =
           new BasePlusCommissionEmployee("Bob", "Lewis",
           "444-44-4444", 5000.00M, .04M, 300.00M);

        Console.WriteLine("Employees processed individually:\n");

        Console.WriteLine("{0}\nearned: {1:C}\n",
           salariedEmployee, salariedEmployee.Earnings());
        Console.WriteLine("{0}\nearned: {1:C}\n",
           hourlyEmployee, hourlyEmployee.Earnings());
        Console.WriteLine("{0}\nearned: {1:C}\n",
           commissionEmployee, commissionEmployee.Earnings());
        Console.WriteLine("{0}\nearned: {1:C}\n",
           basePlusCommissionEmployee,
           basePlusCommissionEmployee.Earnings());

        // create four-element Employee array
        Employee[] employees = new Employee[4];

        // initialize array with Employees of derived types
        employees[0] = salariedEmployee;
        employees[1] = hourlyEmployee;
        employees[2] = commissionEmployee;
        employees[3] = basePlusCommissionEmployee;

        Console.WriteLine("Employees processed polymorphically:\n");

        // generically process each element in array employees
        foreach (Employee currentEmployee in employees)
        {
            Console.WriteLine(currentEmployee); // invokes ToString

            // determine whether element is a BasePlusCommissionEmployee
            if (currentEmployee is BasePlusCommissionEmployee)
            {
                // downcast Employee reference to 
                // BasePlusCommissionEmployee reference
                BasePlusCommissionEmployee employee =
                   (BasePlusCommissionEmployee)currentEmployee;

                employee.BaseSalary *= 1.10M;
                Console.WriteLine(
                   "new base salary with 10% increase is: {0:C}",
                   employee.BaseSalary);
            } // end if

            Console.WriteLine(
               "earned {0:C}\n", currentEmployee.Earnings());
        } // end foreach

        // get type name of each object in employees array
        for (int j = 0; j < employees.Length; j++)
            Console.WriteLine("Employee {0} is a {1}", j,
               employees[j].GetType());


        // generically process each element in array payableObjects
        foreach (var currentPayable in employees)
        {
            // output currentPayable and its appropriate payment amount
            Console.WriteLine("payment due {0}: {1:C}\n", currentPayable, currentPayable.Earnings());
        } // end foreach
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
                    Array.Sort(employees, Employee.sortBySSNAsc());
                    foreach (var currentPayable in employees)
                    {
                        Console.WriteLine("payment due {0}: {1:C}\n", currentPayable, currentPayable.Earnings());
                    }
                    break;
                case "2":
                    //Sort by last name Desc
                    Console.WriteLine("SORTING BY LAST NAME\n\n");
                    Array.Sort(employees,Employee.sortByLNameAsc());
                    foreach (var currentPayable in employees)
                    {
                        Console.WriteLine("payment due {0}: {1:C}\n", currentPayable, currentPayable.Earnings());
                    }
                    break;
                case "3":
                    //Sort by $ Asc
                    Console.WriteLine("SORTING BY PAY\n\n");
                    Array.Sort(employees, Employee.sortByEarningsAsc());
                    foreach (var currentPayable in employees)
                    {
                        Console.WriteLine("payment due {0}: {1:C}\n", currentPayable, currentPayable.Earnings());
                    }
                    break;
                case "4":
                    //Sort by $ Desc
                    Console.WriteLine("SORTING BY PAY\n\n");
                    Array.Sort(employees, Employee.sortByEarningsDesc());
                    foreach (var currentPayable in employees)
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
} // end class PayrollSystemTest