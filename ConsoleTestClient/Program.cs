using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using DLLForumV2;

namespace ConsoleTestClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;

            essai();
            
            Console.ReadKey();
        }
        private static async void essai()
        {
            Rubric r = new Rubric(2, "réseau");
            List<Topic> l = new List<Topic>();
            l = await r.GetListTopicsByRubric();
            foreach (Topic item in l)
            {
                Console.WriteLine(item);
            }
        }
    }
}
