using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics; // Для использования Debug.WriteLine

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

            BinomialHeap.Heap a = new BinomialHeap.Heap(10);
            BinomialHeap.Heap b = new BinomialHeap.Heap(11);
            BinomialHeap.Heap c = new BinomialHeap.Heap(12);
            BinomialHeap.Heap d = new BinomialHeap.Heap(13);

            a.Merge(b);
            d.Merge(c);
            a.Merge(d); // Теперь a - дерево степени 2.

            Debug.WriteLine("a min = {0}",a.GetMin()); // 10

            BinomialHeap.Heap _a = new BinomialHeap.Heap(3);
            BinomialHeap.Heap _b = new BinomialHeap.Heap(4);
            BinomialHeap.Heap _c = new BinomialHeap.Heap(2);
            BinomialHeap.Heap _d = new BinomialHeap.Heap(8);

            _a.Merge(_b);
            _d.Merge(_c);
            _a.Merge(_d); // Теперь _a - дерево степени 2.

            Debug.WriteLine("_a min = {0}",_a.GetMin()); // 2

            a.Merge(_a); // Теперь a - дерево степени 3.
            Debug.WriteLine("a min = {0}",a.GetMin()); // 2
            Debug.WriteLine("a degree = {0}",a.degree); // 3
        }
    }
}
