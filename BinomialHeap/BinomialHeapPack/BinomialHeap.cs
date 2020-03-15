using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinomialHeap.BinomialHeapPack
{
    class BinomialHeap
    {
        //Поля
        List<BinHeapNode> binHeaps; // Для быстродействия можно отслеживать степени деревьяев, а не массив (есть стпепень - 1, нет - 0)




        public BinomialHeap()
        {
            binHeaps = new List<BinHeapNode>();
            BinHeapNode tmp = new BinHeapNode();
            binHeaps.Add(tmp);
        }

        public BinomialHeap(int num)
        {
            binHeaps = new List<BinHeapNode>();
            BinHeapNode tmp = new BinHeapNode();

            Heap heaptmp = new Heap(num);
            tmp.SetHeap(heaptmp);
            binHeaps.Add(tmp);
        }


        public BinomialHeap(BinomialHeap binomialHeap)
        {
            binHeaps = new List<BinHeapNode>(binomialHeap.binHeaps);
        }


        public void Insert(int num)
        {
            BinomialHeap binomialHeapTmp = new BinomialHeap(num);
            Insert(binomialHeapTmp);
        }


        public void Insert(BinomialHeap binomialHeap2)
        {
            //Если НЕ нужно в this.binHeaps добавлять новый элементы 
            if (binHeaps.Count >= binomialHeap2.binHeaps.Count)
            {
                //Мерджить только те элементы, который в binomialHeap2 имеют ращмер больше 0
                foreach (BinHeapNode binHeapNode in binomialHeap2.binHeaps)
                {
                    //TODO: работа строго регулярной системы. Пока набросок того, чтобы было всегда 2.
                    if (binHeapNode.size > 0)
                    {
                        if (binHeapNode.size == 1)
                        {
                            Merge(binHeapNode.h1);
                        }
                        else
                        {
                            Merge(binHeapNode.h1);
                            Merge(binHeapNode.h2);
                        }
                    }
                }
            }
            else
            {
                //Добавление не хватающих элементов
                int off = binHeaps.Count - 1;
                for (int i = off; i < binomialHeap2.binHeaps.Count; i++)
                {
                    binHeaps.Add(binomialHeap2.binHeaps[i]);
                }

                //Мерджить только те элементы, который в binomialHeap2 имеют ращмер больше 0
                for (int i = 0; i < off + 1; i++)
                {
                    //TODO: работа строго регулярной системы. Пока набросок того, чтобы было всегда 2.
                    if (binomialHeap2.binHeaps[i].size > 0)
                    {
                        if (binomialHeap2.binHeaps[i].size == 1)
                        {
                            Merge(binomialHeap2.binHeaps[i].h1);
                        }
                        else
                        {
                            Merge(binomialHeap2.binHeaps[i].h1);
                            Merge(binomialHeap2.binHeaps[i].h2);
                        }
                    }
                }
            }

        }

        private void Merge(Heap HeapMerge)
        {

            //если индекс выходит за пределы листа binHeaps, то добавляет доп элемент (больше 1 не может быть)
            if (HeapMerge.degree > binHeaps.Count - 1)
            {
                BinHeapNode tmp = new BinHeapNode();
                binHeaps.Add(tmp);
            }
            switch (binHeaps[HeapMerge.degree].size)
            {
                case 0:
                case 1:
                    {
                        //если в элемнете хранится 0 или 1 пирамида, то просто добавляем ее туда
                        binHeaps[HeapMerge.degree].SetHeap(HeapMerge);
                        break;
                    }
                case 2:
                    {
                        //если в элементе хранится 2 пирамиды, то необходимо одну из них замерджить c HeapMerge.
                        int degreetmp = HeapMerge.degree;
                        HeapMerge.Merge(binHeaps[HeapMerge.degree].h2);
                        binHeaps[degreetmp].SetHeap(null);
                        Merge(HeapMerge);
                        break;
                    }
                default:
                    break;
            }
        }

        public Heap[] FindHeap(int degree)
        {
            // Найти пирамиду по степени
            return null;
        }

        public void Delete(Heap hp)
        {

        }

        public int GetMin()
        {

            int min = int.MaxValue;
            foreach (BinHeapNode binHeapNode in binHeaps)
            {
                switch (binHeapNode.size)
                {
                    case 1:
                        {
                            if (min > binHeapNode.h1.GetMin()) min = binHeapNode.h1.GetMin();
                            break;
                        }
                    case 2:
                        {
                            if (min > binHeapNode.h1.GetMin()) min = binHeapNode.h1.GetMin();
                            if (min > binHeapNode.h2.GetMin()) min = binHeapNode.h2.GetMin();
                            break;
                        }
                    default:
                        break;
                }
            }


            return min;
        }
    }
}
