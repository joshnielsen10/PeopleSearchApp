using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Hosting;

namespace PeopleSearchApp.Models.DAL
{
    public class PersonInitializer : DropCreateDatabaseAlways<PersonContext>
    {
        public override void InitializeDatabase(PersonContext context)
        {
            base.InitializeDatabase(context);
        }

        protected override void Seed(PersonContext dbcontext)
        {
            var p1 = new Person()
            {
                FirstName = "Luke",
                LastName = "Combs",
                StreetAddress = "123 Hurricane Highway",
                City = "Charleston",
                State = "South Carolina",
                Zip = "29401",
                Age = 44,
                Interests = "music, drinks, country",
                PhotoPath = "Content\\SeedPhotos\\lukecombs.jpg"
            };
            dbcontext.Person.Add(p1);
            var p2 = new Person()
            {
                FirstName = "Tiger",
                LastName = "Woods",
                StreetAddress = "456 Fairway Drive",
                City = "Orlando",
                State = "Florida",
                Zip = "32789",
                Age = 41,
                Interests = "golf, family, money",
                PhotoPath = "Content\\SeedPhotos\\tigerwoods.jpg"
            };
            dbcontext.Person.Add(p2);
            var p3 = new Person()
            {
                FirstName = "Donald",
                LastName = "Duck",
                StreetAddress = "789 Quack Circle",
                City = "Anaheim",
                State = "California",
                Zip = "92802",
                Age = 10,
                Interests = "mickey, goofy, minnie",
                PhotoPath = "Content\\SeedPhotos\\donalduck.png"
            };
            dbcontext.Person.Add(p3);
            var p4 = new Person()
            {
                FirstName = "Julio",
                LastName = "Jones",
                StreetAddress = "11 Dirty Bird Drive",
                City = "Atlanta",
                State = "Georgia",
                Zip = "30301",
                Age = 25,
                Interests = "football, food, family",
                PhotoPath = "Content\\SeedPhotos\\juliojones.jpg"
            };
            dbcontext.Person.Add(p4);
            var p5 = new Person()
            {
                FirstName = "Barry",
                LastName = "Bonds",
                StreetAddress = "73 Crushed Court",
                City = "San Francisco",
                State = "California",
                Zip = "94016",
                Age = 36,
                Interests = "homeruns, baseball, walks",
                PhotoPath = "Content\\SeedPhotos\\barrybonds.jpg"
            };
            dbcontext.Person.Add(p5);
            dbcontext.SaveChanges();
        }
    }
}