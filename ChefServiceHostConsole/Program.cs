using chef_servicelibrary;
using fooditems_servicelibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using customer_servicelibrary;
using order_servicelibrary;

namespace ChefServiceHostConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(ChefService);
            Type t2 = typeof(FoodItemService);
            Type t3= typeof(CustomerService);
            Type t4 = typeof(OrderService);
            /*Uri tcp = new Uri("net.tcp://localhost:8010/ChefService");*/
            Uri http = new Uri("http://localhost:8733/Design_Time_Addresses/ChefService");
            Uri http2 = new Uri("http://localhost:8733/Design_Time_Addresses/FoodItemService");
            Uri http3 = new Uri("http://localhost:8733/Design_Time_Addresses/CustomerService");
            Uri http4 = new Uri("http://localhost:8733/Design_Time_Addresses/OrderService");
            ServiceHost host=new ServiceHost(t, http);
            ServiceHost host2= new ServiceHost(t2, http2);
            ServiceHost host3 = new ServiceHost(t3, http3);
            ServiceHost host4 = new ServiceHost(t4, http4);
            host.Open();
            host2.Open();
            host3.Open();
            host4.Open();
            Console.WriteLine("published");
            Console.ReadLine();
            host.Close();
            host2.Close();
            host3.Close();
            host4.Close();
        }
    }
}
