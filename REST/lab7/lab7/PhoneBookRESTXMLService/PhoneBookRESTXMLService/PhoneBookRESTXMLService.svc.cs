using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PhoneBookRESTXMLService
{
   public class PhoneBookRESTXMLService : IPhoneBookRESTXMLService
   {
       void IPhoneBookRESTXMLService.AddEntry(string firstName, string lastName, string phoneNumber)
       {
           PhoneBookEntry entry = new PhoneBookEntry();

           entry.FirstName = firstName;
           entry.LastName = lastName;
           entry.PhoneNumber = phoneNumber;

           using(var contxt = new PhoneBookEntities())
           {
               PhoneBook book = new PhoneBook();

               book.FirstName = firstName;
               book.LastName = lastName;
               book.PhoneNumber = phoneNumber;
               contxt.PhoneBooks.Add((book));
               contxt.SaveChanges();
           }

       }
      // create a dbcontext object to access PhoneBook database
       
               // add an entry to the phone book database
      
         // create PhoneBook entry to be inserted in database
                 

         // insert PhoneBook entry in database
         
        
       // end method AddEntry

      // retrieve phone book entries with a given last name
      
      // return string array of matching entries
       PhoneBookEntry[] IPhoneBookRESTXMLService.GetEntries(string lastName)
       {

           PhoneBookEntry[] entries;
           using(var context = new PhoneBookEntities())
           {
               var results = (from res in context.PhoneBooks
                             where res.LastName.ToLower() == lastName.ToLower()
                             select res).ToList();
               entries = new PhoneBookEntry[results.Count];
               int k = 0;
               foreach(var item in results)
               {
                   PhoneBookEntry temp = new PhoneBookEntry();
                   temp.FirstName = item.FirstName;
                   temp.LastName = item.LastName;
                   temp.PhoneNumber = item.PhoneNumber;
                   entries[k] = temp;
                   k++;
               }
           }

           return entries;
       }
      
   }
}

