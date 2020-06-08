using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinomialHeap.BinomialHeapPack
{
    class BinHeapNode
    {
        Queue<Heap> heaps;
        // public Heap h1;
        // public Heap h2;
        // public Heap h3;
        public int size { get { return heaps.Count; } }
        public BinHeapNode()
        {
            heaps = new Queue<Heap>();
        }

        public Heap PopHeap()
        {
            // Удаляет крайний heap из Node.
            if (size <= 0) throw new Exception("RemoveHeap: BinHeapNode size <= 0");
            // Heap return_heap = null;
            // if (size >= 3) { return_heap = h3; h3 = null; }
            // else if (size == 2) { return_heap = h2; h2 = null; }
            // else if (size == 1) { return_heap = h1; h1 = null; }
            // size -= 1;
            // return return_heap;

            return heaps.Dequeue();
        }

        public void AddHeap(Heap heap)
        {
            // Добавляет переданный heap в Node.
            if (size >= 3) throw new Exception("RemoveHeap: BinHeapNode size >= 3");
            // if (size == 2)
            // {
            //     h3 = heap;
            //     size = 3;
            // }
            // if (size == 1)
            // {
            //     h2 = heap;
            //     size = 2;
            // }
            // else
            // {
            //     h1 = heap;
            //     size = 1;
            // }
            heaps.Enqueue(heap);
        }

        public int GetMin()
        {
            int return_int = int.MaxValue;
            foreach(Heap heap in heaps)
            {
                if (heap.GetMin() < return_int)
                    return_int = heap.GetMin();
            }
            return return_int;
        }
    }
}
