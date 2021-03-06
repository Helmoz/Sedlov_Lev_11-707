﻿using System;
using System.Collections.Generic;
using System.IO;

namespace LinqObj100
{
    public class Product
    {
        public string Name { get; set; }
        public string VendorCode { get; set; }
        public int Price { get; set; }

        public Product(string source)
        {
            var array = source.Split(' ');
            Price = int.Parse(array[0]);
            VendorCode = array[1];
            Name = array[2];
        }

        public override string ToString()
        {
            return $"{Price}\t{VendorCode}\t{Name}";
        }
    }

    public class ProductFrom
    {
        public string Country { get; set; }
        public string VendorCode { get; set; }
        public string Category { get; set; }

        public ProductFrom(string source)
        {
            var array = source.Split(' ');
            Country = array[1];
            VendorCode = array[0];
            Category = array[2];
        }

        public override string ToString()
        {
            return $"{VendorCode}\t{Country}\t{Category}";
        }
    }

    public class Purchases
    {
        public string Name { get; set; }
        public string VendorCode { get; set; }
        public int Code { get; set; }

        public Purchases(string source)
        {
            var array = source.Split(' ');
            Code = int.Parse(array[0]);
            VendorCode = array[2];
            Name = array[1];
        }

        public override string ToString()
        {
            return $"{Code}\t{VendorCode}\t{Name}";
        }
    }

    public class Customer
    {
        public int Year { get; set; }
        public int Code { get; set; }
        public string Street { get; set; }

        public Customer(string source)
        {
            var array = source.Split(' ');
            Year = int.Parse(array[0]);
            Code = int.Parse(array[1]);
            Street = array[2];
        }

        public override string ToString()
        {
            return $"{Year}\t{Code}\t{Street}";
        }
    }

    public class Generator
    {
        public static string[] VendorCodes;

        public static string[] Names;

        public static string[] Streets;

        public static string[] Сountries;

        public static string[] Category;

        static Generator()
        {
            VendorCodes = new[]
            {
                "AA322-1337", "DC341-2436", "ET165-1675", "DG527-5795", "JK839-2342", "GR234-6343", "KL345-7145",
                "RT345-7235"
            };

            Names = new[]
            {
                "Ashan", "Lenta", "Karusel", "Pyatyorochka", "Magnit", "Perekrestok", "Faktoria"
            };

            Streets = new[]
            {
                "Adoratskogo", "Gavrilova", "Dekabristov", "Korolenko", "Yamasheva", "Tolstogo", "Absalyamova"
            };

            Сountries = new[]
            {
                "Russia", "GB", "USA", "Germany", "France", "Denmark"
            };

            Category = new[]
            {
                "First", "Second", "Third", "Fourth", "Fifth"
            };
        }

        public static void Generate(int size)
        {
            var random = new Random();
            var directory = @"D:\ITIS\Sedlov_Lev_11-707\SPRING2017\Linq_tasks\Data";

            using (StreamWriter sw = new StreamWriter($"{directory}\\LinqObj100D.txt"))
            {
                for (int j = 0; j < size; j++)
                {
                    sw.WriteLine($"{random.Next(100, 5000)} {VendorCodes[random.Next(0, VendorCodes.Length)]} {Names[random.Next(0, Names.Length)]}");
                }
            }
            using (StreamWriter sw = new StreamWriter($"{directory}\\LinqObj100E.txt"))
            {
                for (int j = 0; j < size; j++)
                {
                    sw.WriteLine($"{random.Next(1, 100)} {Names[random.Next(0, Names.Length)]} {VendorCodes[random.Next(0, VendorCodes.Length)]}");
                }
            }

            using (StreamWriter sw = new StreamWriter($"{directory}\\LinqObj100A.txt"))
            {
                for (int j = 0; j < size; j++)
                {
                    sw.WriteLine($"{random.Next(1999, 2018)} {random.Next(1, 100)} {Streets[random.Next(0, Streets.Length)]}");
                }
            }

            using (StreamWriter sw = new StreamWriter($"{directory}\\LinqObj100B.txt"))
            {
                for (int j = 0; j < size; j++)
                {
                    sw.WriteLine($"{VendorCodes[random.Next(0, VendorCodes.Length)]} {Сountries[random.Next(0, Сountries.Length)]} {Category[random.Next(0, Category.Length)]}");
                }
            }

        }

        public static List<Product> GetProducts(int size)
        {
            var directory = @"D:\ITIS\Sedlov_Lev_11-707\SPRING2017\Linq_tasks\Data";

            var list = new List<string>();

            var products = new List<Product>();

            using (StreamReader sr = new StreamReader($"{directory}\\LinqObj100D.txt"))
                while (!sr.EndOfStream)
                    list.Add(sr.ReadLine());

            foreach (var product in list)
            {
                products.Add(new Product(product));
            }

            return products;
        }

        public static List<Purchases> GetPurchases(int size)
        {
            var directory = @"D:\ITIS\Sedlov_Lev_11-707\SPRING2017\Linq_tasks\Data";

            var list = new List<string>();

            var purchases = new List<Purchases>();

            using (StreamReader sr = new StreamReader($"{directory}\\LinqObj100E.txt"))
                while (!sr.EndOfStream)
                    list.Add(sr.ReadLine());

            foreach (var purchase in list)
            {
                purchases.Add(new Purchases(purchase));
            }

            return purchases;
        }

        public static List<Customer> GetCustomers(int size)
        {
            //Generate(size);
            var directory = @"D:\ITIS\Sedlov_Lev_11-707\SPRING2017\Linq_tasks\Data";

            var list = new List<string>();

            var customers = new List<Customer>();

            using (StreamReader sr = new StreamReader($"{directory}\\LinqObj100A.txt"))
                while (!sr.EndOfStream)
                    list.Add(sr.ReadLine());

            foreach (var customer in list)
            {
                customers.Add(new Customer(customer));
            }

            return customers;
        }

        public static List<ProductFrom> GetProductsFrom(int size)
        {
            //Generate(size);
            var directory = @"D:\ITIS\Sedlov_Lev_11-707\SPRING2017\Linq_tasks\Data";

            var list = new List<string>();

            var productFroms = new List<ProductFrom>();

            using (StreamReader sr = new StreamReader($"{directory}\\LinqObj100B.txt"))
                while (!sr.EndOfStream)
                    list.Add(sr.ReadLine());

            foreach (var product in list)
            {
                productFroms.Add(new ProductFrom(product));
            }

            return productFroms;
        }
    }
}
