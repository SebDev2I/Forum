using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using DLLForumV2;
using DALClientWS;
using Common;

namespace ConsoleTestClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;

            /*Forum f = new Forum();
            f.GetListRubrics();
            f.GetListTopics();
            Console.WriteLine(f.ListRubric.Count);
            foreach (Rubric item in f.ListRubric)
            {
                Console.WriteLine(item);
            }
            foreach (Topic item in f.ListTopic)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("essai");
            essai();
            Console.ReadKey();*/
        }
        /*private static async void essai()
        {
            DALClient dal = new DALClient();
            DALWSR_Result r1 = await dal.GetListUsers(CancellationToken.None);
            List<Registered> l = new List<Registered>();
            foreach (RegisteredDTO item in (List<RegisteredDTO>)r1.Data)
            {
                l.Add(new Registered(item));
                Console.WriteLine(item);
            }

        }*/
    }
}
