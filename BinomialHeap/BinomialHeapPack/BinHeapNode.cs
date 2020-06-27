using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinomialHeap.BinomialHeapPack
{
    class BinHeapNode
    {
        public List<Heap> heaps { get; }
        public int size { get { return heaps.Count; } }
        public BinHeapNode()
        {
            heaps = new List<Heap>();
        }
        public BinHeapNode(Heap heap)
        {
            heaps = new List<Heap>();
            AddHeap(heap);
        }

        public Heap PopHeap()
        {
            // Удаляет крайний heap из Node.
            if (size <= 0) throw new Exception("RemoveHeap: BinHeapNode size <= 0");

            Heap return_heap = heaps.First();
            heaps.Remove(return_heap);

            return return_heap;
        }

        public Heap PopHeap(Heap hp)
        {
            // Удаляет крайний heap из Node.
            if (size <= 0) throw new Exception("RemoveHeap: BinHeapNode size <= 0");
            Heap return_heap;

            foreach (Heap heap in heaps)
            {
                if (hp == heap)
                {
                    return_heap = heap;
                    heaps.Remove(heap);
                    return return_heap;
                }
            }
            throw new Exception("RemoveHeap: BinHeapNode heap != heaps");
        }

        public void AddHeap(Heap heap)
        {
            // Добавляет переданный heap в Node.
            if (size >= 3) throw new Exception("RemoveHeap: BinHeapNode size >= 3");

            heaps.Add(heap);
        }

        public int GetMin()
        {
            int return_int = int.MaxValue;
            foreach (Heap heap in heaps)
            {
                if (heap.GetMin() < return_int)
                    return_int = heap.GetMin();
            }
            return return_int;
        }

        public Heap GetMinHeap()
        {
            if (size == 0) return null;
            int min_index = 0;
            int min_int = int.MaxValue;
            for (int i = 0; i < heaps.Count; i++)
            {
                if ((heaps[i] != null) && (heaps[i].GetMin() < min_int))
                {
                    min_int = heaps[i].GetMin();
                    min_index = i;
                }
            }
            return heaps[min_index];
        }

        public void Clear()
        {
            foreach (Heap heap in heaps)
            {
                heap.Clear();
            }
            heaps.Clear();
        }
    }
}