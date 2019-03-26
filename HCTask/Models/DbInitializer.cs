using HCTask.PersonContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCTask.Models
{
    public static class DbInitializer
    {
        public static void Initialize(PersonDbContext context)
        {
            if (context.People.Any())
            {
                return;
            }

            var people = new List<PersonRecord>
            {
                new PersonRecord { FirstName = "Bill", LastName = "Gates", DateOfBirth = new DateTime(1955, 10, 28), Street = "Microsoft way", City = "Seattle", State = "Washington",  PostalCode = "98134", PictureName = "a4759609-0051-4cd5-a84b-1d4efa743c97.jpg" },
                new PersonRecord { FirstName = "Mark", LastName = "Zuckerberg", DateOfBirth = new DateTime(1984, 5, 14), Street = "Facebook street", City = "White Plains", State= "New York", PostalCode = "10016", PictureName = "4dc720fc-cb7b-4f94-a004-21101c1a64e7.jpg" },
                new PersonRecord { FirstName = "Jeff", LastName = "Bezos", DateOfBirth = new DateTime(1964, 1, 12), Street = "Amazon Prime way", City = "Albuquerque", State = "New Mexico", PostalCode = "87110", PictureName = "f1c1d561-a45d-4d8c-bb37-4641de13a64e.jpg" },
                new PersonRecord { FirstName = "Steve", LastName = "Jobs", DateOfBirth = new DateTime(1955, 02, 24), Street = "Apple Parkway", City = "San Francisco", State = "California",  PostalCode = "90201", PictureName = "bc3b154e-135c-4fd3-aee0-e9dfceee8286.jpg" },
                new PersonRecord { FirstName = "Elon", LastName = "Musk", DateOfBirth = new DateTime(1971, 6, 28), Street = "Tesla street way", City = "Pretoria", State = "South Africa", PostalCode = "Unknown", PictureName = "2702f7df-bce7-4f3b-8741-efe32215435b.jpg" },
                new PersonRecord { FirstName = "Tim", LastName = "Cook", DateOfBirth = new DateTime(1960, 11, 1), Street = "Apple Parkway", City = "Mobile", State = "Alabama", PostalCode = "36611", PictureName = "3271aeb1-2db7-470f-acac-b375a9002cc4.jpg" },
            };

            people.ForEach(p => context.People.Add(p));
            context.SaveChangesAsync();
        }
    }
}
