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
            //List<int> our_number = new List<int>();
            //print_list(our_number);
            //our_number.Add(1);
            //our_number.Add(2); // Сразу [1,2]
            //StrictlyRegulatedSystem.StrictlyRegulatedNumber.increment(ref our_number, 0);
            //print_list(our_number);
            //StrictlyRegulatedSystem.StrictlyRegulatedNumber.increment(ref our_number, 0);
            //print_list(our_number);
            //for(int a = 0; a < 10; a++)
            //{
            //    StrictlyRegulatedSystem.StrictlyRegulatedNumber.increment(ref our_number, 0);
            //    print_list(our_number);
            //}

            //BinomialHeap.Node a = new BinomialHeap.Node(10); // Узел "10"
            //a.AddChild(new BinomialHeap.Node(11));
            //a.AddChild(new BinomialHeap.Node(12));
            //a.AddChild(new BinomialHeap.Node(13));
            //
            //BinomialHeap.Node b = new BinomialHeap.Node(9);
            //b.AddChild(a);
            //b.AddChild(new BinomialHeap.Node(7));




            Random rnd = new Random();

            BinomialHeapPack.BinomialHeap binomialHeap = new BinomialHeapPack.BinomialHeap();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < 500000; i++)
            {
                binomialHeap.Insert(rnd.Next(-1000000, 1000000));
            }

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Debug.WriteLine("RunTime sozdanie " + elapsedTime);


            stopWatch.Restart();

            int min = binomialHeap.GetMin();
            stopWatch.Stop();

            ts = stopWatch.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Debug.WriteLine("RunTime min " + elapsedTime + " binomialHeap min = {0}", min);

            BinomialHeapPack.BinomialHeap binomialHeap2 = new BinomialHeapPack.BinomialHeap();
            Stopwatch stopWatch2 = new Stopwatch();
            stopWatch2.Start();
            for (int i = 0; i < 500000; i++)
            {
                binomialHeap2.Insert(rnd.Next(-1000000, 1000000));
            }

            stopWatch2.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts2 = stopWatch2.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime2 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts2.Hours, ts2.Minutes, ts2.Seconds,
                ts2.Milliseconds / 10);
            Debug.WriteLine("RunTime sozdanie " + elapsedTime2);

            binomialHeap.PrintHeap();
            binomialHeap2.PrintHeap();

            Stopwatch stopWatch3 = new Stopwatch();
            stopWatch3.Start();

            binomialHeap.Insert(binomialHeap2);

            stopWatch3.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts3 = stopWatch3.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime3 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts3.Hours, ts3.Minutes, ts3.Seconds,
                ts3.Milliseconds / 10);
            Debug.WriteLine("RunTime sliyanie " + elapsedTime3);

            binomialHeap.PrintHeap();



            //Debug.WriteLine("binomialHeap min = {0}", binomialHeap.GetMin()); // 10


        }
    }
}
