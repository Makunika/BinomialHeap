using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinomialHeap.BinomialHeap
{
    class BinHeapNode
    {
        public Heap h1;
        public Heap h2;
        public int size;
        public BinHeapNode()
        {
            size = 0;
            h1 = null;
            h2 = null;
        }

        public void SetHeap(Heap heap)
        {
            if (size == 2)
            {
                if (heap == null) size = 1;
                else throw new Exception("BinHeapNode size > 2");
            }
            if (size == 1)
            {
                h2 = heap;
                if (heap == null) size = 1;
                else size = 2;
            }
            else
            {
                h1 = heap;
                if (heap == null) size = 0;
                else size = 1;
            }




        }
    }
}
