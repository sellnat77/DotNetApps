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

            Console.WriteLine("Sorted by Description:");
            var desc = from item in invoiceItems
                       orderby item.PartDescription
                       select item;
            foreach( Invoice element in desc)
            {
                Console.WriteLine(element.ToString());
            }

            Console.WriteLine("\n\n\n\nSorted by price:");
            var price = from item in invoiceItems
                       orderby item.Price
                       select item;
            foreach (Invoice element in price)
            {
                Console.WriteLine(element.ToString());
            }

            Console.WriteLine("\n\n\n\nSelect description and quantity, sort by quantity:");
            var quan = from item in invoiceItems
                        orderby item.Quantity
                        select new {PartDescription = item.PartDescription, Quantity = item.Quantity};
            foreach (var element in quan)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine("\n\n\n\nSelect description and invoice total, sort by invoice total:");
            var invoiceTtls = from item in invoiceItems
                              orderby (item.Price * item.Quantity)
                              select new { ItemDescription = item.PartDescription, InvoiceTotal = (item.Price * item.Quantity)};
            foreach (var element in invoiceTtls)
            {
                Console.WriteLine(element.ToString());
            }

            Console.WriteLine("\n\n\n\nInvoice totals between $200.00 and $500.00:");
            var invoiceTtlsFiltered = from item in invoiceItems
                                      orderby (item.Price * item.Quantity)
                                      where (item.Price * item.Quantity) < 500.00M && (item.Price * item.Quantity) > 200.00M
                                      select new { ItemDescription = item.PartDescription, InvoiceTotal = (item.Price * item.Quantity)};
            foreach (var element in invoiceTtlsFiltered)
            {
                Console.WriteLine(element.ToString());
            }
        }
    }
}
