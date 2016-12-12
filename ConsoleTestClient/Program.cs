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

            DALClient dal = new DALClient();
            List<RegisteredDTO> lst = (List<RegisteredDTO>)dal.GetUsers(CancellationToken.None).Data;
            foreach (RegisteredDTO item in lst)
            {
                string hash = string.Join(":", new string[] { item.LoginUser, "2isaMillau%2016" });
                string hashLeft = "";
                string hashRight = "";

                hashLeft = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Join(":", hash, item.PwdUser)));
                item.PwdUser = hashLeft;
                DALWSR_Result r = dal.SaveUser(item, null, CancellationToken.None);
                Console.WriteLine(item.PwdUser);
            }
            
            Console.ReadKey();
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
