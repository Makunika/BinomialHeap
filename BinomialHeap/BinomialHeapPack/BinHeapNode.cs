using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinomialHeap.BinomialHeapPack
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
            if (heap == null)
            {
                switch (size)
                {
                    case 2:
                    case 3:
                        {
                            h2 = null;
                            size = 1;
                            break;
                        }
                    case 1:
                        {
                            h1 = null;
                            size = 0;
                            break;
                        }
                    default:
                        break;
                }
            }
            else
            {
                if (size == 2) throw new Exception("BinHeapNode size > 2");
                if (size == 1)
                {
                    h2 = heap;
                    size = 2;
                }
                else
                {
                    h1 = heap;
                    size = 1;
                }
            }




        }
    }
}
