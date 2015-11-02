using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace NavigationWithLinqToXml
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("***** Fun with LINQ to XML *****\n");

      // Load the Inventory.xml document into memory.
      XElement doc = XElement.Load("Inventory.xml");

      // We will author each of these next...
      PrintAllPetNames(doc);
      Console.WriteLine();
      GetAllFords(doc);
      Console.WriteLine(); 
      AddNewElements(doc);
      Console.ReadLine();
      displayCarMakeColor(doc);
      Console.ReadLine();
    }

    #region Helper methods
    private static void PrintAllPetNames(XElement doc)
    {
      var petNames = from pn in doc.Descendants("PetName")
                     select pn.Value;

      foreach (var name in petNames)
        Console.WriteLine("Name: {0}", name);
    }

    static void GetAllFords(XElement doc)
    {
      var fords = from c in doc.Descendants("Make")
                  where c.Value == "Ford"
                  select c;

      foreach (var f in fords)
        Console.WriteLine("Name: {0}", f);
    }
    
    static void displayCarMakeColor(XElement doc)
    {
        Console.Write("Please enter a make:");
        string make = Console.ReadLine();
        Console.Write("Please enter a color:");
        string color = Console.ReadLine();

        var filtered = from c in doc.Elements()
                     where c.Element("Make").Value.ToLower() == make.ToLower()
                     where c.Element("Color").Value.ToLower() == color.ToLower()
                    select c;

        foreach (var f in filtered)
        {
            Console.WriteLine("Pet name: {0}", f.Element("PetName").Value);
            Console.WriteLine("Make: {0}", f.Element("Make").Value);
            Console.WriteLine("Color: {0}", f.Element("Color").Value);
        }
    }

    static void AddNewElements(XElement doc)
    {
      // Add 5 new purple Fords to the incoming document.
      for (int i = 0; i < 5; i++)
      {
          string pets = "Spot " + i;
        // Create a new XElement
        XElement newCar =
          new XElement("Car", new XAttribute("ID", i + 1000),
            new XElement("Color", "Green"),
            new XElement("Make", "Ford"),
            new XElement("PetName", pets)
        );

        // Add to doc.
        doc.Add(newCar);
      }
      // Show the updates.
      Console.WriteLine(doc);
    }
    #endregion
  }
}
