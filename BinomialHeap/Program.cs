using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics; // Для использования Debug.WriteLine
using BinomialHeap.BinomialHeapPack;

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



            Random rnd = new Random();

            DateTime time1, time2;
            int total = 10;

            rnd.Next(1, 2);
            BinomialHeapPack.BinomialHeap b = new BinomialHeapPack.BinomialHeap();
            time1 = DateTime.Now;
            for (int i = 0; i < total / 2; i++)
                b.Insert(rnd.Next(1, 10000));
            time2 = DateTime.Now;
            Console.WriteLine($"Вставка {total / 2} элем в пирамиду за " + (time2 - time1));

            BinomialHeapPack.BinomialHeap c = new BinomialHeapPack.BinomialHeap();
            time1 = DateTime.Now;
            for (int i = 0; i < total / 2; i++)
                c.Insert(rnd.Next(1, 100000));
            time2 = DateTime.Now;
            Console.WriteLine($"Вставка {total / 2} элем в пирамиду за " + (time2 - time1));

            time1 = DateTime.Now;
            //b.Insert(c);
            time2 = DateTime.Now;
            Console.WriteLine($"Слияние пирамид по {total / 2} элем кажд за " + (time2 - time1));

            time1 = DateTime.Now;
            for (int i = 0; i < total / 2; i++)
                b.PopMin();
            time2 = DateTime.Now;
            Console.WriteLine($"Извлечение всех элементов из пирамиды с {total} элем за " + (time2 - time1));
            b.PrintHeap();


        }
    }
}
