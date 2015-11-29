namespace MVCBook.Migrations
{
    using MVCBook.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCBook.Models.BookDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MVCBook.Models.BookDBContext";
        }

        protected override void Seed(MVCBook.Models.BookDBContext context)
        {
            context.Books.AddOrUpdate(i => i.Title,
                new Book
                {                       
                    AuthorID = 1,
                    Title = "One Flew Over the Cuckoo's Nest",
                    EditionNumber  = 1,
                    Copyright = "Public Domain",
                    FirstName = "Ken",
                    LastName = "Kesey" 
                },

                 new Book
                 {
                    AuthorID = 2,
                    Title = "1984",
                    EditionNumber  = 2,
                    Copyright = "Public Domain",
                    FirstName = "George",
                    LastName = "Orwel"
                 },

                 new Book
                 {
                    AuthorID = 3,
                    Title = "Frankenstein",
                    EditionNumber  = 1,
                    Copyright = "Public Domain",
                    FirstName = "Mary",
                    LastName = "Shelley"
                 },

               new Book
               {
                    AuthorID = 4,
                    Title = "The Great Gatsby",
                    EditionNumber  = 3,
                    Copyright = "Public Domain",
                    FirstName = "F. Scott",
                    LastName = "Fitzgerald"
               }
           );
        }
    }
}
