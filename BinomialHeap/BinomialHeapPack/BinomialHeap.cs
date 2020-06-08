using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinomialHeap.BinomialHeapPack
{
    class BinomialHeap
    {
        //Поля
        private List<BinHeapNode> binHeaps; // Для быстродействия можно отслеживать степени деревьяев, а не массив (есть стпепень - 1, нет - 0)

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
            tmp.AddHeap(heaptmp);
            binHeaps.Add(tmp);
        }


        public BinomialHeap(BinomialHeap binomialHeap)
        {
            binHeaps = new List<BinHeapNode>(binomialHeap.binHeaps);
        }


        public void Insert(int num)
        {
            //BinomialHeap binomialHeapTmp = new BinomialHeap(num);

            Heap heap = new Heap(num);
            Merge(heap);
        }


        public void Insert(BinomialHeap insertHeap)
        {
            //Добавление не хватающих элементов
            int off = binHeaps.Count;
            for (int i = off; i < insertHeap.binHeaps.Count; i++)
            {
                binHeaps.Add(insertHeap.binHeaps[i]);
            }

            //Мерджить только те элементы, который в mergeHeap имеют ращмер больше 0
            for (int i = 0; i < off; i++)
            {
                int size = insertHeap.binHeaps[i].size;

                for(int j = 0; j < size; j++)
                {
                    Merge(insertHeap.binHeaps[i].PopHeap());
                }
            }
        }

        private void Merge(Heap mergeHeap)
        {
            //если индекс выходит за пределы листа binHeaps, то добавляет доп элемент (больше 1 не может быть)
            if (mergeHeap.degree > binHeaps.Count - 1)
            {
                BinHeapNode tmp = new BinHeapNode();
                binHeaps.Add(tmp);
            }

            // 1. ++di

            BinHeapNode currentNode = binHeaps[mergeHeap.degree];

            currentNode.AddHeap(mergeHeap);

            // 2. Находим db - первую экстремальную цифру {0,2,N/A} перед (дальше в списке) i
            int index_of_db = find_extremal(mergeHeap.degree + 1, binHeaps.Count);
            // Если индекс не изменился, значит, после di нет экстремальных чисел
            bool is_db_NA = index_of_db == -1; // Флаг, который поднимается, если db не существует
            
            // 3. Находим da - первую экстремальную цифру {0,2,N/A} после (раньше в списке) i
            int index_of_da = find_extremal(0, mergeHeap.degree);
            // Если индекс не изменился, значит, после di нет экстремальных чисел
            bool is_da_NA = index_of_da == -1; // Флаг, который поднимается, если db не существует

            // 4. if di=3 or ( di=2 and db!=0 )
            if (currentNode.size == 3 || (currentNode.size == 2 && (is_db_NA || currentNode.size != 0)))
            {
                fix_carry(mergeHeap.degree);
            }
            // 5. else if da = 2
            else if ((!is_da_NA) && (binHeaps[index_of_da].size == 2))
            {
                fix_carry(index_of_da);
            }
        }

        private int find_extremal(int from, int to)
        {
            // Возварщает индекс первого экстремального числа {0, 2, N/A} в указанном промежутке.


            int index = -1;
            // int way = from <= to ? 1 : -1; // Направление поиска. Если from меньше или равен to - ++, если from больше to - --.

            if (from <= to)
            {
                for (int bit = from; bit < to; bit ++)
                {
                    if ((binHeaps[bit].size == 0) || (binHeaps[bit].size == 2))
                    {
                        index = bit;
                        break;
                    }
                }
            }
            else
            {
                for (int bit = from; bit >= to; bit--)
                {
                    if ((binHeaps[bit].size == 0) || (binHeaps[bit].size == 2))
                    {
                        index = bit;
                        break;
                    }
                }
            }

            return index;
        }


        private void fix_carry(int indexDegree)
        {
            // Операция "фикс-перенос".

            BinHeapNode currentNode = binHeaps[indexDegree];

            // Считается, что di >= 2.
            if (currentNode.size >= 2)
            {
                //Выполняем:
                // 1. d_i←d_i-2

                var h1 = currentNode.PopHeap();
                var h2 = currentNode.PopHeap();

                h1.Merge(h2);

                // 2. d_(i+1)←d_(i+1)+1
                if (binHeaps.Count - 1 < indexDegree + 1)
                {
                    BinHeapNode tmp = new BinHeapNode();
                    binHeaps.Add(tmp);
                }

                binHeaps[indexDegree + 1].AddHeap(h1);
                // if (binHeaps[indexDegree + 1].size >= 2) // Эта проверка не нужна, так как она выполняется в самом fix_carry
                fix_carry(indexDegree + 1);
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
                int currentHeapMin = binHeapNode.GetMin();
                if (currentHeapMin < min)
                    min = currentHeapMin;
            }

            return min;
        }
        public void PrintHeap()
        {
            // Выводит все size-ы Node-ов из binHeaps.
            foreach(BinHeapNode bhNode in binHeaps)
            {
                Debug.Write(bhNode.size.ToString());
            }
            Debug.WriteLine("");
        }
    }
}
