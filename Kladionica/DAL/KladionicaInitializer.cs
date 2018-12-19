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
            var categories = new List<Category>
            {
                new Category{CategoryId = 1,Name = "Nogomet"},
                new Category{CategoryId = 2,Name = "Tenis"},
                new Category{CategoryId = 3,Name = "Košarka"},
                new Category{CategoryId = 4,Name = "Rukomet"},
                new Category{CategoryId = 5,Name = "Hokej"},
                new Category{CategoryId = 6,Name = "Vaterpolo"},
                new Category{CategoryId = 7,Name = "Rugby"}
            };

            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();

            var users = new List<User>
            {
                new User
                {
                    FirstName = "Anton",
                    LastName = "Šustić",
                    Email = "protos3@gmail.com",
                    Address = "Neka adresa 123",
                    City = "Arroyo",
                    PhoneNumber = "+385 91 234 5678"
                }
            };

            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            var transactions = new List<Transaction>
            {
                new Transaction
                {
                    Amount = 50.00m,
                    Success = true,
                    UserID = 1
                }
            };

            transactions.ForEach(t => context.Transactions.Add(t));
            context.SaveChanges();

            var pairs = new List<Pair>
            {
                new Pair
                {
                    Pair1 = "Hajduk",
                    Pair2 = "Dinamo",
                    Type1 = 3.42m,
                    Type2 = 1.52m,
                    Typex = 2.89m,
                    StartDate = new DateTime(2018,12,5,12,0,0),
                    CategoryID = 1
                },
                new Pair
                {
                    Pair1 = "Real Madrid",
                    Pair2 = "Barcelona",
                    Type1 = 12.42m,
                    Type2 = 1.52m,
                    Typex = 7.89m,
                    StartDate = new DateTime(2018,12,5,12,0,0),
                    CategoryID = 1
                },
                new Pair
                {
                    Pair1 = "PSG",
                    Pair2 = "Liverpool",
                    Type1 = 1.72m,
                    Type2 = 4.22m,
                    Typex = 8.89m,
                    StartDate = new DateTime(2018,12,5,12,0,0),
                    CategoryID = 1
                },
                new Pair
                {
                    Pair1 = "AC Milan",
                    Pair2 = "Bayern Munich",
                    Type1 = 1.42m,
                    Type2 = 2.32m,
                    Typex = 1.89m,
                    StartDate = new DateTime(2018,12,5,12,0,0),
                    CategoryID = 1
                },
                new Pair
                {
                    Pair1 = "Hrvatska",
                    Pair2 = "Danska",
                    Type1 = 1.92m,
                    Type2 = 3.77m,
                    Typex = 7.89m,
                    StartDate = new DateTime(2018,12,5,12,0,0),
                    CategoryID = 4
                },
                new Pair
                {
                    Pair1 = "Hrvatska",
                    Pair2 = "Francuska",
                    Type1 = 1.92m,
                    Type2 = 3.77m,
                    Typex = 7.89m,
                    StartDate = new DateTime(2018,12,5,12,0,0),
                    CategoryID = 4
                },
                new Pair
                {
                    Pair1 = "Švedska",
                    Pair2 = "Španjolska",
                    Type1 = 1.92m,
                    Type2 = 3.77m,
                    Typex = 7.89m,
                    StartDate = new DateTime(2018,12,5,12,0,0),
                    CategoryID = 4
                },
                new Pair
                {
                    Pair1 = "Đoković",
                    Pair2 = "Čilić",
                    Type1 = 5.92m,
                    Type2 = 9.77m,
                    Typex = 1.89m,
                    StartDate = new DateTime(2018,12,5,12,0,0),
                    CategoryID = 2
                },
                new Pair
                {
                    Pair1 = "Federer",
                    Pair2 = "Nadal",
                    Type1 = 1.92m,
                    Type2 = 4.77m,
                    Typex = 2.89m,
                    StartDate = new DateTime(2018,12,5,12,0,0),
                    CategoryID = 2
                },
                new Pair
                {
                    Pair1 = "Clippers",
                    Pair2 = "Warriors",
                    Type1 = 5.92m,
                    Type2 = 2.77m,
                    Typex = 3.89m,
                    StartDate = new DateTime(2018,12,5,12,0,0),
                    CategoryID = 3
                },
                new Pair
                {
                    Pair1 = "Nets",
                    Pair2 = "Lakers",
                    Type1 = 2.92m,
                    Type2 = 1.77m,
                    Typex = 4.89m,
                    StartDate = new DateTime(2018,12,5,12,0,0),
                    CategoryID = 3
                },
                new Pair
                {
                    Pair1 = "Bulls",
                    Pair2 = "Pacers",
                    Type1 = 1.92m,
                    Type2 = 4.77m,
                    Typex = 2.89m,
                    StartDate = new DateTime(2018,12,5,12,0,0),
                    CategoryID = 3
                },
                new Pair
                {
                    Pair1 = "Sabers",
                    Pair2 = "Panthers",
                    Type1 = 1.92m,
                    Type2 = 1.77m,
                    Typex = 6.89m,
                    StartDate = new DateTime(2018,12,5,12,0,0),
                    CategoryID = 5
                },
                new Pair
                {
                    Pair1 = "Blackhawks",
                    Pair2 = "Predators",
                    Type1 = 4.92m,
                    Type2 = 1.77m,
                    Typex = 7.89m,
                    StartDate = new DateTime(2018,12,5,12,0,0),
                    CategoryID = 5
                },
                new Pair
                {
                    Pair1 = "Hrvatska",
                    Pair2 = "Srbija",
                    Type1 = 1.92m,
                    Type2 = 6.77m,
                    Typex = 9.89m,
                    StartDate = new DateTime(2018,12,5,12,0,0),
                    CategoryID = 6
                },
                new Pair
                {
                    Pair1 = "Izrael",
                    Pair2 = "Grčka",
                    Type1 = 1.92m,
                    Type2 = 2.77m,
                    Typex = 3.89m,
                    StartDate = new DateTime(2018,12,5,12,0,0),
                    CategoryID = 6
                },
                new Pair
                {
                    Pair1 = "Francuska",
                    Pair2 = "Škotska",
                    Type1 = 5.92m,
                    Type2 = 1.77m,
                    Typex = 2.89m,
                    StartDate = new DateTime(2018,12,5,12,0,0),
                    CategoryID = 7
                },
                new Pair
                {
                    Pair1 = "Engleska",
                    Pair2 = "Samoa",
                    Type1 = 1.92m,
                    Type2 = 7.77m,
                    Typex = 12.89m,
                    StartDate = new DateTime(2018,12,5,12,0,0),
                    CategoryID = 7
                },
            };

            pairs.ForEach(p => context.Pairs.Add(p));
            context.SaveChanges();

        }
    }
}