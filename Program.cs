using NorthwindEfCodeFirst.Contexts;
using NorthwindEfCodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindEfCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Birlestir_Gelismis();

            //using (var northwindContext = new NorthwindContext())
            //{
            //    foreach (var customer in northwindContext.Customers)
            //    {
            //        Console.WriteLine("Customer Name : {0}", customer.ContactName);
            //    }
            //}
            Console.ReadLine();
        }

        private static void Sil()
        {
            using (var northwindContext = new NorthwindContext())
            {
                Order order = northwindContext.Orders.Find(1);
                northwindContext.Orders.Remove(order);
                northwindContext.SaveChanges();
            }
        }

        private static void Guncelle()
        {
            using (var northwindContext = new NorthwindContext())
            {
                Customer customer = northwindContext.Customers.Find("ENGIN");
                customer.Country = "Turkey";
                northwindContext.SaveChanges();
            }
        }

        private static void SiparisEkle()
        {
            using (var northwindContext = new NorthwindContext())
            {
                Customer customer = northwindContext.Customers.Find("ENGIN");
                customer.Orders.Add(new Order
                {
                    OrderID = 1,
                    OrderDate = DateTime.Now,
                    ShipCity = "Ankara",
                    ShipCountry = "Türkiye"
                });
                northwindContext.SaveChanges();
            }
        }

        private static void MusteriEkle()
        {
            using (var northwindContext = new NorthwindContext())
            {
                var customer = new Customer
                {
                    CustomerID = "ENGIN",
                    City = "Ankara",
                    CompanyName = "YazilimDevi.Com",
                    ContactName = "Engin Demiroğ",
                    Country = "Türkiye"
                };

                northwindContext.Customers.Add(customer);
                northwindContext.SaveChanges();
            }
        }

        private static void MusteriListesi()
        {
            using (var northwindContext = new NorthwindContext())
            {
                foreach (var customer in northwindContext.Customers)
                {
                    Console.WriteLine("Customer Name : {0}", customer.ContactName);
                }
            }
        }

        private static void Projection_()
        {
            using (var northwindContext = new NorthwindContext())
            {
                IQueryable<Customer> result = from c in northwindContext.Customers
                                              select c;
                foreach (var customer in result)
                {
                    Console.WriteLine(customer.ContactName);
                }
            }
        }

        private static void Liste_()
        {
            using (var northwindContext = new NorthwindContext())
            {
                List<Customer> result = (from c in northwindContext.Customers
                                              select c).ToList();
                foreach (var customer in result)
                {
                    Console.WriteLine(customer.ContactName);
                }
            }
        }

        private static void Tek_Kolon()
        {
            using (var northwindContext = new NorthwindContext())
            {
                var result = from c in northwindContext.Customers
                             select c.Country;
                foreach (var country in result)
                {
                    Console.WriteLine(country);
                }
            }
        }

        private static void BirdenFazla_Kolon()
        {
            using (var northwindContext = new NorthwindContext())
            {
                var result = from c in northwindContext.Customers
                             select new { c.Country, c.CompanyName, c.ContactName };
                foreach (var country in result)
                {
                    Console.WriteLine(country);
                }
            }
        }

        private static void Liste_Sart()
        {
            using (var northwindContext = new NorthwindContext())
            {
                List<Customer> result = (from c in northwindContext.Customers
                                         where c.City == "London" && c.Country == "UK"
                                         select c).ToList();
                foreach (var customer in result)
                {
                    Console.WriteLine("Contact Name : {0} , City : {1}",customer.ContactName,customer.City);
                }
            }
        }

        private static void Gruplama()
        {
            using (var northwindContext = new NorthwindContext())
            {
                var result = from c in northwindContext.Customers
                             group c by c.Country
                             into g
                             select g;
                foreach (var group in result)
                {
                    Console.WriteLine(group.Key);
                }
            }
        }

        private static void Gruplama_BirdenFazlaKolon()
        {
            using (var northwindContext = new NorthwindContext())
            {
                var result = from c in northwindContext.Customers
                             group c by new { c.Country,c.City}
                             into g
                             select g;
                foreach (var group in result)
                {
                    Console.WriteLine(group.Key);
                }
            }
        }

        private static void Gruplama_BirdenFazlaKolon_Gelismis()
        {
            using (var northwindContext = new NorthwindContext())
            {
                var result = from c in northwindContext.Customers
                             group c by new { c.Country, c.City }
                             into g
                             select new
                             {
                                 Sehir = g.Key.City,
                                 Ulke = g.Key.Country,
                                 Adet = g.Count()
                             };
                foreach (var group in result)
                {
                    Console.WriteLine("Ulke: {0}, Şehir : {1}, Adet : {2}",group.Ulke,group.Sehir,group.Adet);
                }
            }
        }

        private static void Sirala()
        {
            using (var northwindContext = new NorthwindContext())
            {
                List<Customer> result = (from c in northwindContext.Customers
                                         orderby c.Country,c.ContactName
                                         select c).ToList();
                foreach (var customer in result)
                {
                    Console.WriteLine("{0},{1}", customer.Country, customer.ContactName);
                }
            }
        }

        private static void Sirala_Uzunluga_Gore()
        {
            using (var northwindContext = new NorthwindContext())
            {
                List<Customer> result = (from c in northwindContext.Customers
                                         orderby c.Country.Length, c.ContactName
                                         select c).ToList();
                foreach (var customer in result)
                {
                    Console.WriteLine("{0},{1}", customer.Country, customer.ContactName);
                }
            }
        }

        private static void Sirala_Azalan()
        {
            using (var northwindContext = new NorthwindContext())
            {
                List<Customer> result = (from c in northwindContext.Customers
                                         orderby c.Country.Length descending, c.ContactName descending
                                         select c).ToList();
                foreach (var customer in result)
                {
                    Console.WriteLine("{0},{1}", customer.Country, customer.ContactName);
                }
            }
        }

        private static void Birlestir()
        {
            using (var northwindContext = new NorthwindContext())
            {
                var result = from c in northwindContext.Customers
                             join o in northwindContext.Orders
                             on c.CustomerID equals o.CustomerID
                             select new
                             {
                                 c.CustomerID,c.ContactName,o.OrderDate,o.ShipCity
                             };

                foreach (var item in result)
                {
                    Console.WriteLine("{0},{1},{2},{3}",item.CustomerID,item.ContactName,item.OrderDate,item.ShipCity);
                }
            }
        }

        private static void Birlestir_Gelismis()
        {
            using (var northwindContext = new NorthwindContext())
            {
                var result = from c in northwindContext.Customers
                             join o in northwindContext.Orders
                             on c.CustomerID equals o.CustomerID
                             select new
                             {
                                 c.CustomerID,
                                 c.ContactName,
                                 o.OrderDate,
                                 o.ShipCity
                             };

                foreach (var item in result)
                {
                    Console.WriteLine("{0},{1},{2},{3}", item.CustomerID, item.ContactName, item.OrderDate, item.ShipCity);
                }
                Console.WriteLine("{0} adet sipariş vardır.", result.Count());
            }
        }





    }
}





