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

            BinomialHeapPack.BinomialHeap binomialHeap = new BinomialHeapPack.BinomialHeap(10);
            binomialHeap.Insert(11);
            binomialHeap.Insert(12);
            binomialHeap.Insert(13);

            Debug.WriteLine("binomialHeap min = {0}", binomialHeap.GetMin()); // 10

            BinomialHeapPack.BinomialHeap binomialHeap2 = new BinomialHeapPack.BinomialHeap(3);
            binomialHeap2.Insert(4);
            binomialHeap2.Insert(2);
            binomialHeap2.Insert(8);


            Debug.WriteLine("binomialHeap2 min = {0}", binomialHeap2.GetMin()); // 2

            binomialHeap.Insert(binomialHeap2); // Теперь binomialHeap - дерево степени 3.

            binomialHeap.Insert(4);

            Debug.WriteLine("a min = {0}", binomialHeap.GetMin()); // 2
        }
    }
}
