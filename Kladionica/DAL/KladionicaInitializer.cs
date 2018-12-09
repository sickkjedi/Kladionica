﻿using System;
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
                    UserId = 1,
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

            var pairs = new List<Pair>
            {
                new Pair
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
                new Pair
                {
                    PairId = 2,
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
                    PairId = 3,
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
                    PairId = 4,
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
                    PairId = 48,
                    Pair1 = "Hrvatska",
                    Pair2 = "Danska",
                    Type1 = 1.92m,
                    Type2 = 3.77m,
                    Typex = 7.89m,
                    StartDate = new DateTime(2018,12,5,12,0,0),
                    CategoryID = 4
                },
            };

            pairs.ForEach(p => context.Pairs.Add(p));
            context.SaveChanges();


          
        }
    }
}