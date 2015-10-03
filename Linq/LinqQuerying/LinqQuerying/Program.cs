using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqQuerying
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Invoice> invoiceItems = new List<Invoice>();
            Invoice sander = new Invoice(83,"Electric Sander",7,57.98M);
            Invoice saw = new Invoice(24,"Power Saw", 18, 99.99M);
            Invoice sledgeH = new Invoice(7, "Seldge Hammer", 11, 21.50M);
            Invoice hammer = new Invoice(77, "Hammer", 76, 11.99M);
            Invoice lawnMower = new Invoice(39, "Lawn Mower", 3, 79.50M);
            Invoice screwdriver = new Invoice(68, "Screwdriver", 106, 6.99M);
            Invoice jigSaw = new Invoice(56, "Jig Saw", 21, 11.00M);
            Invoice wrench = new Invoice(3, "Wrench", 34, 7.50M);

            invoiceItems.Add(sander);
            invoiceItems.Add(saw);
            invoiceItems.Add(sledgeH);
            invoiceItems.Add(hammer);
            invoiceItems.Add(lawnMower);
            invoiceItems.Add(screwdriver);
            invoiceItems.Add(jigSaw);
            invoiceItems.Add(wrench);

            var desc = from item in invoiceItems
                       orderby item.PartDescription
                       select item;
            foreach( Invoice element in desc)
            {
                Console.WriteLine(element.ToString());
            }

            Console.WriteLine("\n\n\n\n");
            var price = from item in invoiceItems
                       orderby item.Price
                       select item;
            foreach (Invoice element in price)
            {
                Console.WriteLine(element.ToString());
            }

            var quan = from item in invoiceItems
                        orderby item.Quantity
                        select new {item.PartDescription, item.Quantity};
            foreach (Invoice element in price)
            {
                //Console.WriteLine("{Part Description = {0}, Quantity = {1}",element.PartDescription,element.Quantity);
                Console.WriteLine(element);
            }

            var invoiceTtls = from item in invoiceItems
                              orderby (item.Price * item.Quantity)
                              select new { total=(item.Price*item.Quantity) , desc=item.PartDescription };
            foreach (var element in invoiceTtls)
            {
                Console.WriteLine(element.ToString());
            }
        }
    }
}
