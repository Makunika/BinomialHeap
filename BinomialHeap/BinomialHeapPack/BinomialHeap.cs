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
            switch (binHeaps[HeapMerge.degree].size) // Бит, который стоит на месте степени дерева в числе
            {
                case 0:
                    {
                        //если в элемнете хранится 0 пирамида, то просто добавляем ее туда
                        binHeaps[HeapMerge.degree].SetHeap(HeapMerge);
                        return;
                    }
                case 1:
                    {
                        //если в элемнете хранится 0 или 1 пирамида, то просто добавляем ее туда
                        binHeaps[HeapMerge.degree].SetHeap(HeapMerge);
                        break;
                    }
                case 2:
                    {
                        //если в элементе хранится 2 пирамиды, то необходимо одну из них замерджить c HeapMerge.
                        //int degreetmp = HeapMerge.degree;
                        //HeapMerge.Merge(binHeaps[HeapMerge.degree].h2);
                        //binHeaps[degreetmp].SetHeap(null);
                        //Merge(HeapMerge);
                        binHeaps[HeapMerge.degree].size = 3;
                        break;
                    }
                default:
                    break;
            }

            // 1. ++di





            // 2. Находим db - первую экстремальную цифру {0,2,N/A} перед (дальше в списке) i
            int index_of_db = -1;
            for (int bit = HeapMerge.degree + 1; bit < binHeaps.Count - 1; bit++) // Проходимся до конца списка
            {
                if ((binHeaps[bit].size == 0) || (binHeaps[bit].size == 2)) // TODO: Понять, что значит N/A число.
                {
                    index_of_db = bit;
                    break;
                }
            }
            bool is_db_NA = false; // Флаг, который поднимается, если db не существует
            // Если индекс не изменился, значит, после di нет экстремальных чисел
            if (index_of_db == -1)
            {
                is_db_NA = true;
            }
            // 3. Находим da - первую экстремальную цифру {0,2,N/A} после (раньше в списке) i
            int index_of_da = -1;
            for (int bit = HeapMerge.degree - 1; bit >= 0; bit--) // Проходимся до начала списка
            {
                if ((binHeaps[bit].size == 0) || (binHeaps[bit].size == 2)) // TODO: Понять, что значит N/A число.
                {
                    index_of_da = bit;
                    break;
                }
            }
            bool is_da_NA = false; // Флаг, который поднимается, если db не существует
            // Если индекс не изменился, значит, после di нет экстремальных чисел
            if (index_of_da == -1)
            {
                is_da_NA = true;
            }
            // 4. if di=3 or ( di=2 and db!=0 )
            if (binHeaps[HeapMerge.degree].size == 3 || (binHeaps[HeapMerge.degree].size == 2 && (is_db_NA || binHeaps[index_of_db].size != 0)))
            {
                if (binHeaps[HeapMerge.degree].size == 3)
                {
                    fix_carry(HeapMerge.degree, HeapMerge);
                }
                else
                {
                    fix_carry(HeapMerge.degree, null);
                }
            }
            // 5. else if da = 2
            else if (!is_da_NA)
                if (binHeaps[index_of_da].size == 2)
                {
                    fix_carry(index_of_da, null);
                }
        }


        private void fix_carry(int indexDegree, Heap h3)
        {
            // Операция "фикс-перенос".

            // Считается, что di >= 2.
            if (binHeaps[indexDegree].size >= 2)
            {
                //Выполняем:
                // 1. d_i←d_i-2
                if (binHeaps.Count - 1 < indexDegree + 1)
                {
                    BinHeapNode tmp = new BinHeapNode();
                    binHeaps.Add(tmp);
                }


                if (binHeaps[indexDegree].size == 3)
                {
                    h3.Merge(binHeaps[indexDegree].h2);
                    binHeaps[indexDegree].SetHeap(null);
                    //Merge(h3);
                    switch (binHeaps[indexDegree + 1].size) // Бит, который стоит на месте степени дерева в числе
                    {
                        case 0:
                        case 1:
                            {
                                //если в элемнете хранится 0 или 1 пирамида, то просто добавляем ее туда
                                binHeaps[indexDegree + 1].SetHeap(h3);
                                break;
                            }
                        case 2:
                            {
                                //если в элементе хранится 2 пирамиды, то необходимо одну из них замерджить c HeapMerge.
                                //int degreetmp = HeapMerge.degree;
                                //HeapMerge.Merge(binHeaps[HeapMerge.degree].h2);
                                //binHeaps[degreetmp].SetHeap(null);
                                //Merge(HeapMerge);
                                binHeaps[indexDegree + 1].size = 3;
                                break;
                            }
                        default:
                            break;
                    }
                }
                else
                {
                    Heap tmp1;
                    binHeaps[indexDegree].h1.Merge(binHeaps[indexDegree].h2); // d[i] = d[i] - 2;
                    tmp1 = binHeaps[indexDegree].h1;
                    binHeaps[indexDegree].SetHeap(null);
                    binHeaps[indexDegree].SetHeap(null);
                    //Merge(tmp1);
                    switch (binHeaps[indexDegree + 1].size) // Бит, который стоит на месте степени дерева в числе
                    {
                        case 0:
                        case 1:
                            {
                                //если в элемнете хранится 0 или 1 пирамида, то просто добавляем ее туда
                                binHeaps[indexDegree + 1].SetHeap(tmp1);
                                break;
                            }
                        case 2:
                            {
                                //если в элементе хранится 2 пирамиды, то необходимо одну из них замерджить c HeapMerge.
                                //int degreetmp = HeapMerge.degree;
                                //HeapMerge.Merge(binHeaps[HeapMerge.degree].h2);
                                //binHeaps[degreetmp].SetHeap(null);
                                //Merge(HeapMerge);
                                binHeaps[indexDegree + 1].size = 3;
                                break;
                            }
                        default:
                            break;
                    }


                }
                // 2. d_(i+1)←d_(i+1)+1
                // Нужно проверять, есть ли элемент (i+1):

                //if (binHeaps.Count - 1 < indexDegree + 1)
                //{
                //    //Если длина числа меньше, чем необходимый бит, то дописываем к числу 0.
                //    d.Add(0);
                //}
                // d[indexDegree + 1] = d[indexDegree + 1] + 1; // Рекурсия?! Проверять то, что заменили вот здесь

                // Вот здесь merge между tmp и деревом, которое хранилось в ячейке indexDegree + 1

                if (binHeaps[indexDegree + 1].size >= 2)
                {
                    if (binHeaps[indexDegree + 1].size == 3)
                    {
                        fix_carry(indexDegree + 1, h3);
                    }
                    else
                    {
                        fix_carry(indexDegree + 1, null);
                    }
                }
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
