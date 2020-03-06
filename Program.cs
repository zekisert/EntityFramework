//using NorthwindEfCodeFirst.Contexts;
//using NorthwindEfCodeFirst.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace NorthwindEfCodeFirst
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
            //NewMethod();
            //Add();
            //NewMethod1();

            // Silme Operasyonu
            //using (var northwindContext = new NorthwindContext())
            //{
            //    Order order = northwindContext.Orders.Find(1);
            //    northwindContext.Orders.Remove(order);
            //    northwindContext.SaveChanges();
            //}

            // Update İşlemi
            //using (var northwindContext = new NorthwindContext())
            //{
            //    Customer customer = northwindContext.Customers.Find("ENGIN");
            //    customer.Country = "Turkey";
            //    northwindContext.SaveChanges();
            //}

            //using (var northwindContext = new NorthwindContext())
            //{
            //    IQueryable<Customer> result = from c in northwindContext.Customers
            //}






        //    Console.ReadLine();
        //}

        // Sipariş Tablosundaki Ekleme İşlemi
        //private static void NewMethod1()
        //{
        //    using (var northwindContext = new NorthwindContext())
        //    {
        //        Customer customer = northwindContext.Customers.Find("ENGIN");
        //        customer.Orders.Add(new Order
        //        {
        //            OrderID = 1,
        //            OrderDate = DateTime.Now,
        //            ShipCity = "Ankara",
        //            ShipCountry = "Türkiye"
        //        });
        //        northwindContext.SaveChanges();
        //    }
        //}


        // Müşteri Eklemek
        //private static void Add()
        //{
        //    using (var northwindContext = new NorthwindContext())
        //    {
        //        var customer = new Customer
        //        {
        //            CustomerID = "ENGIN",
        //            City = "Ankara",
        //            CompanyName = "YazilimDevi.Com",
        //            ContactName = "Engin Demiroğ",
        //            Country = "Türkiye"
        //        };

        //        northwindContext.Customers.Add(customer);
        //        northwindContext.SaveChanges();
        //    }
        //}

        // Müşteri Listesi Yazmak
        //private static void NewMethod()
        //{
        //    using (var northwindContext = new NorthwindContext())
        //    {
        //        foreach (var customer in northwindContext.Customers)
        //        {
        //            Console.WriteLine("Customer Name : {0}", customer.ContactName);
        //        }
        //    }
        //}
//    }
//}
