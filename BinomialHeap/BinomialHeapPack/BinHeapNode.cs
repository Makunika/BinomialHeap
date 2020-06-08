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
        public int size { get { return heaps.Count; } }
        public BinHeapNode()
        {
            heaps = new Queue<Heap>();
        }

        public Heap PopHeap()
        {
            // Удаляет крайний heap из Node.
            if (size <= 0) throw new Exception("RemoveHeap: BinHeapNode size <= 0");

            return heaps.Dequeue();
        }

        public void AddHeap(Heap heap)
        {
            // Добавляет переданный heap в Node.
            if (size >= 3) throw new Exception("RemoveHeap: BinHeapNode size >= 3");
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
