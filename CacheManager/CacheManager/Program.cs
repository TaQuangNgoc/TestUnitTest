using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CacheManager.Core;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using StackExchange.Redis;
using Unity;
using Unity.Injection;

namespace CacheManager
{
    class Program
    {
        delegate int MyDelegate(string s);
        static int ConvertStringToInt(string str)
        {
            int result = 0;
            Int32.TryParse(str, out result);
            Console.WriteLine("success");
            return result;
        }
        
        static void NhapHoVaTen (MyDelegate convert)
        {
            Console.WriteLine("Nhập số ");
            string so = Console.ReadLine();
            int result = convert(so);
            Console.WriteLine(result);
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            MyDelegate myDelegate = new MyDelegate(ConvertStringToInt);
            NhapHoVaTen(myDelegate);



            //IUnityContainer objContainer = new UnityContainer();
            //objContainer.RegisterType<Customer>();
            //objContainer.RegisterType<IDAL, Oracle>();
            //objContainer.RegisterType<IDAL, SqlServer>();
            //Customer obj = objContainer.Resolve<Customer>();
            // obj.Add();
            //using(RedisClient client = new RedisClient("localhost", 6379))
            //{

            //    List<string> listString = new List<string>();
            //    listString.Add("aaa");
            //    listString.Add("bbb");
            //    client.Set("test", listString);
            //    var result = client.Get<List<string>>("test");
            //    foreach (var item in result)
            //    {
            //        Console.WriteLine(item);
            //    }
            //    Console.ReadLine();
            //}
            //var cache = CacheFactory.Build("getStartedCache", settings =>
            //{
            //    settings.WithSystemRuntimeCacheHandle("handleName");
            //});
            //List<int> list = new List<int>();
            //list.Add(1);
            //list.Add(2);
            //cache.Add("keyA", list);
            //cache.Put("keyB", 23);
            //cache.Update("keyB", v => 42);
            //if(cache.Get("keyA")!=null)
            //{
            //     List<int> result =(List<int>)cache.Get("keyA");
            //    foreach (var item in result)
            //    {
            //        Console.WriteLine(item);
            //    }

            //}    


            //cache.Remove("keyA");

            //Console.WriteLine("KeyA removed? " + (cache.Get("keyA") == null).ToString());

            //Console.WriteLine("We are done...");
            //Console.ReadKey();
        }

        public interface IDAL
        {
            void Add();
        }
        public class Oracle : IDAL
        {
            public void Add()
            {
                Console.WriteLine("Oracle inserted!");
                Console.ReadLine();
            }
        }

        public class SqlServer : IDAL
        {
            public void Add()
            {
                Console.WriteLine("SQL Server inserted!");
                Console.ReadLine();
            }
        }

        public class Customer
        {
            public string name { get; set; }
            private IDAL v_dal;
            public Customer(IDAL idal)
            {
                v_dal = idal;
            }

            public void Add()
            {
                v_dal.Add();
            }
        }

    }
}
