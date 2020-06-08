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
            size = 0;
        }
        public BinHeapNode(Heap heap)
        {
            heaps = new Heap[3];
            size = 0;
            AddHeap(heap);
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

        public Heap PopHeap(Heap hp)
        {
            // Удаляет крайний heap из Node.
            if (size <= 0) throw new Exception("RemoveHeap: BinHeapNode size <= 0");
            Heap return_heap;
            for (int i = 0; i < size; i++)
            {
                if (hp == heaps[i])
                {
                    return_heap = heaps[i];
                    size--;
                    heaps[i] = null;
                    return return_heap;
                }
            }
            throw new Exception("RemoveHeap: BinHeapNode heap != heaps");
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

        public Heap GetMinHeap()
        {
            if (size == 0) return null;
            int min_index = 0;
            int min_int = int.MaxValue;
            for (int i = 0; i < heaps.Length; i++)
            {
                if ((heaps[i] != null) && (heaps[i].GetMin() < min_int))
                {
                    min_int = heaps[i].GetMin();
                    min_index = i;
                }
            }
            return heaps[min_index];
        }
    }
}
