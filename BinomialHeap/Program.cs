using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinomialHeap
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        //[STAThread]
        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new Form1());
        //}

        static public void print_list(List<int> list)
        {
            Console.Write("[");
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i]);
                Console.Write(",");
            }
            Console.WriteLine("]");
        }

        static void Main()
        {
            List<int> our_number = new List<int>();
            print_list(our_number);
            //our_number.Add(1);
            //our_number.Add(2); // Сразу [1,2]
            //StrictlyRegulatedSystem.StrictlyRegulatedNumber.increment(ref our_number, 0);
            //print_list(our_number);
            //StrictlyRegulatedSystem.StrictlyRegulatedNumber.increment(ref our_number, 0);
            //print_list(our_number);
            for(int a = 0; a < 10; a++)
            {
                StrictlyRegulatedSystem.StrictlyRegulatedNumber.increment(ref our_number, 0);
                print_list(our_number);
            }
        }
    }
}
