using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinomialHeap.BinomialHeapPack
{
    class BinHeapNode
    {
        private Heap[] heaps;
        public int size { get; private set; }
        public BinHeapNode()
        {
            heaps = new Heap[3];
        }

        public Heap PopHeap()
        {
            // Удаляет крайний heap из Node.
            if (size <= 0) throw new Exception("RemoveHeap: BinHeapNode size <= 0");

            size--;
            var return_heap = heaps[size];
            heaps[size] = null;

            return return_heap;
        }

        public void AddHeap(Heap heap)
        {
            // Добавляет переданный heap в Node.
            if (size >= 3) throw new Exception("RemoveHeap: BinHeapNode size >= 3");

            heaps[size++] = heap;
        }

        public int GetMin()
        {
            int return_int = int.MaxValue;
            foreach(Heap heap in heaps)
            {
                if ((heap != null) && (heap.GetMin() < return_int))
                    return_int = heap.GetMin();
            }
            return return_int;
        }
    }
}
