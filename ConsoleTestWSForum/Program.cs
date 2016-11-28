using Common;
using ConsumeWSRest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ConsoleTestWSForum
{
    class Program
    {
        private const string HTTP = @"http://localhost:5000/";
        private const string SERVICE = "ServiceForum.svc/";
        private static CancellationTokenSource _CancellationAsync;

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;

            WSR_Param p = new WSR_Param();
            RegisteredDTO r = new RegisteredDTO();
            p.Add("save", r);
            Response(p);
            //Response(5);
            Console.ReadKey();
        }

        public static async void Response(WSR_Param p)
        {
            _CancellationAsync = new CancellationTokenSource();
            WSR_Result r = await ConsumeWSR.Call(ConstructResource("Users"), "POST", p, TypeSerializer.Json, _CancellationAsync.Token);
            Console.WriteLine(r.Data);
            List<RegisteredDTO> lst = (List<RegisteredDTO>)r.Data;
            foreach (RegisteredDTO item in lst)
            {
                Console.WriteLine(item.NameUser);
            }
        }

        public static async void Response(int id)
        {
            _CancellationAsync = new CancellationTokenSource();
            WSR_Param p = new WSR_Param();
            p.Add("login", "toto");
            WSR_Result r = await ConsumeWSR.Call(ConstructResource("Users", id), "GET", p, TypeSerializer.Json, _CancellationAsync.Token);
            Console.WriteLine(r.Data);
            RegisteredDTO registered = (RegisteredDTO)r.Data;
            
            Console.WriteLine(registered.EmailUser);
            
        }
        private static string ConstructResource(string resource)
        {
            return string.Format("{0}{1}{2}", HTTP, SERVICE, resource);
        }
        private static string ConstructResource(string resource, int id)
        {
            return string.Format("{0}{1}{2}/{3}", HTTP, SERVICE, resource, id.ToString());
        }
    }
}
