using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.IO;
using Kladionica.Models;

namespace Kladionica.DAL
{
    public class KladionicaInitializer : DropCreateDatabaseAlways<KladionicaContext>
    {
        protected override void Seed(KladionicaContext context)
        {
            var categories = new List<Category>()
            {
                new Category()
                {
                    CategoryId = 1,
                    Name = "Nogomet"
                },
                new Category()
                {
                    CategoryId = 2,
                    Name = "Tenis"
                },
                new Category()
                {
                    CategoryId = 3,
                    Name = "Košarka"
                },
                new Category()
                {
                    CategoryId = 4,
                    Name = "Rukomet"
                },
                new Category()
                {
                    CategoryId = 5,
                    Name = "Hokej"
                },
                new Category()
                {
                    CategoryId = 6,
                    Name = "Vaterpolo"
                },
                new Category()
                {
                    CategoryId = 7,
                    Name = "Rugby"
                }
            };

            var users = new List<User>()
            {
                new User()
                {
                    UserId = 1,
                    FirstName = "Anton",
                    LastName = "Šustić",
                    Email = "protos3@gmail.com",
                    Address = "Neka adresa 123",
                    City = "Arroyo",
                    PhoneNumber = "+385 91 234 5678"
                }
            };

            var pairs = new List<Pair>()
            {
                new Pair()
                {
                    PairId = 1,
                    Pair1 = "Hajduk",
                    Pair2 = "Dinamo",
                    Type1 = 3.42m,
                    Type2 = 1.52m,
                    Typex = 2.89m,
                    StartDate = new DateTime(2018,12,5,12,0,0),
                    CategoryID = 1
                },
            };


          
        }
    }
}