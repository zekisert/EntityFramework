using EntityFrameworkMiddleLevel.Contexts;
using EntityFrameworkMiddleLevel.Entities;
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
            MusteriEkle();
            MusteriListesi();
            using (var northwindContext = new NorthwindContext())
            {
                foreach (var customer in northwindContext.Customers)
                {
                    Console.WriteLine("Customer Name : {0}", customer.ContactName);
                }
            }
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
                Customer customer = northwindContext.Customers.Find("ZEKİ");
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
                    CustomerID = "ZEKİ",
                    City = "Bursa",
                    CompanyName = "DijitalDonusum.com",
                    ContactName = "Zeki SERT",
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
    }
}





