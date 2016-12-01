using Common;
using ConsumeWSRest;
using DALClientWS;
using DLLAuth;
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
        private static DALClient d;
        private static RegisteredDTO reg = null;
        public Token tok = null;

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;

            WSR_Param p = new WSR_Param();
            Token t = new Token(1, "Snosjean", "admin", DateTime.UtcNow.Ticks);
            //Response<RegisteredDTO>(p, "Users", "GET", 1);
            //reg.KeywordUser = "Mablue mon chien";
            p.Add("save", reg);
            p.Add("token", t);
            //Console.WriteLine("param : " + t);

            d = new DALClient();
            //essai(t, CancellationToken.None);
            essai<StatusDTO>(CancellationToken.None);
            Console.ReadKey();
        }
        
        private static async void essai(Token t, CancellationToken cancel)
        {
            //DALClient d = new DALClient();
            DALWSR_Result r = await d.LoginAsync(t, cancel);
            t = (Token)r.Data;
            Console.WriteLine("retour : " + t);
        }

        private static async void essai<T>(CancellationToken cancel)
        {
            DALWSR_Result r = await d.GetListStatus(cancel);
            List<T> list = (List<T>)r.Data;
            foreach (T item in list)
            {
                Console.WriteLine(item.ToString());
            }
                
            
        }
        public static async void ResponseToken<Token>(WSR_Param p, string resource, string method)
        {
            _CancellationAsync = new CancellationTokenSource();
            WSR_Result r;
            string path;
            path = ConstructResource(resource);
            r = await ConsumeWSR.Call(path, method, p, TypeSerializer.Json, _CancellationAsync.Token);
            Token obj = (Token)r.Data;
            
            Console.WriteLine(obj.ToString());
        }

        public static async void Response<T>(WSR_Param p, string resource, string method, int id)
        {
            _CancellationAsync = new CancellationTokenSource();
            WSR_Result r;
            string path;
            
            if(method == "GET")
            {
                if (id != 0)
                {
                    path = ConstructResource(resource, id);
                    r = await ConsumeWSR.Call(path, method, p, TypeSerializer.Json, _CancellationAsync.Token);
                    T obj = (T)r.Data;
                    T reg = (T)r.Data; 
                    Console.WriteLine(obj.ToString());
                }
                else
                {
                    path = ConstructResource(resource);
                    r = await ConsumeWSR.Call(path, method, p, TypeSerializer.Json, _CancellationAsync.Token);
                    List<T> lst = new List<T>();
                    lst = (List<T>)r.Data;
                    Console.WriteLine(r.ErrorCode);
                    foreach (T item in lst)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
            }
            else if(method == "POST")
            {
                path = ConstructResource(resource);
                r = await ConsumeWSR.Call(path, method, p, TypeSerializer.Json, _CancellationAsync.Token);
                T obj = (T)r.Data;
                Console.WriteLine(obj.ToString());
            }
            else if(method == "DELETE")
            {
                path = ConstructResource(resource, id);
                r = await ConsumeWSR.Call(path, method, p, TypeSerializer.Json, _CancellationAsync.Token);
                bool obj = (bool)r.Data;
                Console.WriteLine(obj.ToString());
            }
        }

        public static async void Get<T>(string resource, string method)
        {
            _CancellationAsync = new CancellationTokenSource();
            WSR_Result r = await ConsumeWSR.Call(ConstructResource(resource), method, null, TypeSerializer.Json, _CancellationAsync.Token);
            
            List<T> lst = new List<T>();

            lst = (List<T>)r.Data;
            foreach (T item in lst)
            {
               Console.WriteLine(item.ToString());
            }
        }

        public static async void Get<T>(string resource, string method, int id)
        {
            _CancellationAsync = new CancellationTokenSource();
            WSR_Result r = await ConsumeWSR.Call(ConstructResource(resource, id), method, null, TypeSerializer.Json, _CancellationAsync.Token);

            Object obj = new Object();
            obj = (T)r.Data;
            Console.WriteLine(obj.ToString());
            

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
