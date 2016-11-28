using ConsumeWSRest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ConsoleTestWSForum
{
    class Program
    {
        private const string HTTP = @"http://localhost:5000/ServiceForum.svc";
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;

            WSR_Param param = new WSR_Param();
            Post(param, "Users");
            Console.ReadKey();
        }
        public static void Post(WSR_Param essai, string resource)
        {
            string path = HTTP + "/" + resource + "/1";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(path);
            request.ContentType = "application/json";
            request.Method = "POST";
            if(essai != null)
            {
                using (StreamWriter streamW = new StreamWriter(request.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(essai);
                    streamW.Write(json);
                }
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader streamR = new StreamReader(response.GetResponseStream()))
            {
                string result = streamR.ReadToEnd();
                Console.WriteLine(result);
            }
        }
    }
}
