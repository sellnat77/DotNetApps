// Fig. 12.15: PayableInterfaceTest.cs
// Tests interface IPayable with disparate classes.
using System;

public class PayableInterfaceTest
{
   public static void Main(string[] args)
   {
      // create four-element IPayable array
      IPayable[] payableObjects = new IPayable[10];

      // populate array with objects that implement IPayable
      payableObjects[0] = new Invoice("01234", "seat", 2, 375.00M);
      payableObjects[1] = new Invoice("56789", "tire", 4, 79.95M);
      payableObjects[2] = new SalariedEmployee("John", "Smith", "111-11-1111", 800.00M);
      payableObjects[3] = new SalariedEmployee("Lisa", "Barnes", "888-88-8888", 1200.00M);
      payableObjects[4] = new SalariedEmployee("Charles", "Phillipson", "999-98-5656", 1255.36M);
      payableObjects[5] = new HourlyEmployee("Farrah", "Faucet", "123-45-6789",12.50m, 40.0m);
      payableObjects[6] = new HourlyEmployee("Jake", "Jacobson", "564-89-7412", 10.50m, 40.0M);
      payableObjects[7] = new CommissionEmployee("Phil", "Future", "898-75-4561",25000.00m,.07m );
      payableObjects[8] = new BasePlusCommissionEmployee("Phyllis", "Garrison", "545-12-6789",5000m,.1m,50000.00m);
      payableObjects[9] = new BasePlusCommissionEmployee("George", "Korals", "898-74-1459", 65400m, .15m, 40000.00m);

      Console.WriteLine("Invoices and Employees processed polymorphically:\n");
      // generically process each element in array payableObjects
      foreach (var currentPayable in payableObjects)
      {
         // output currentPayable and its appropriate payment amount
         Console.WriteLine("payment due {0}: {1:C}\n", currentPayable, currentPayable.GetPaymentAmount());
      } // end foreach
      bool again = true;

       while(again)
       {
           Console.WriteLine("1.) Sort by social security number in ascending order");
           Console.WriteLine("2.) Sort by last name in descending order");
           Console.WriteLine("3.) Sort by pay amount in ascending order");
           Console.WriteLine("4.) Sort by pay amount in descending order");
           Console.WriteLine("5.) Exit");

           switch(Console.ReadLine())
           {
               case "1":
                   //Sort by ssn Asc
                   Console.WriteLine("SORTING BY SSN\n\n");
                   foreach (var currentPayable in payableObjects)
                   {
                       Console.WriteLine("payment due {0}: {1:C}\n", currentPayable, currentPayable.GetPaymentAmount());
                   }
                   break;
               case "2":
                   //Sort by last name Desc
                   Console.WriteLine("SORTING BY LAST NAME\n\n");
                   foreach (var currentPayable in payableObjects)
                   {
                       Console.WriteLine("payment due {0}: {1:C}\n", currentPayable, currentPayable.GetPaymentAmount());
                   }
                   break;
               case "3":
                   //Sort by $ Asc
                   Console.WriteLine("SORTING BY PAY\n\n");
                   foreach (var currentPayable in payableObjects)
                   {
                       Console.WriteLine("payment due {0}: {1:C}\n", currentPayable, currentPayable.GetPaymentAmount());
                   }
                   break;
               case "4":
                   //Sort by $ Desc
                   Console.WriteLine("SORTING BY PAY\n\n");
                   foreach (var currentPayable in payableObjects)
                   {
                       Console.WriteLine("payment due {0}: {1:C}\n", currentPayable, currentPayable.GetPaymentAmount());
                   }
                   break;
               default:
                   again = false;
                   Console.WriteLine("Thank you!");
                   break;
           }
       }







   } // end Main

   
} // end class PayableInterfaceTest

/**************************************************************************
 * (C) Copyright 1992-2009 by Deitel & Associates, Inc. and               *
 * Pearson Education, Inc. All Rights Reserved.                           *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 **************************************************************************/