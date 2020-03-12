using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinomialHeap.BinomialHeap
{
    class BinomialHeap
    {
        //Поля
        List<int> Binary; // Для быстродействия можно отслеживать степени деревьяев, а не массив (есть стпепень - 1, нет - 0)
        Heap head;

        public void Insert(Heap heap)
        {
            // Вот здесь используем {0,1,2}-систему
            // Узнаём ранг (i) добавляемой пирамиды
            //int heap_degree = heap.get_degree;

            // Делаем инкремент для числа Binary в (i)-ом разряде
            //StrictlyRegulatedSystem.StrictlyRegulatedNumber.increment(Binary, heap_degree);

            // СТАРАЯ ИДЕЯ: В зависимости от того, как поменяется число, merge-им пирамиды, или ничего не делаем
            // Во время инкремента сразу же измерняем и пирамиду
        }

        private void Merge(Heap h1, Heap h2)
        {
            // Сливаем 2 дерева пирамиды
        }

        private void Merge(int h1_degree, int h2_degree)
        {
            // Сливаем 2 дерева пирамиды по индексам
        }

        public void Merge(BinomialHeap biheap)
        {
            // Разбиваем сливаемую пирамиду на отдельные деревья
            // Heap h1 = biheap.pull() (?)
            // ...

            // Добавляем эти деревья в нашу пирамиду
            // Insert(h1)
            // ...
        }

        public Heap[] FindHeap(int degree)
        {
            // Найти пирамиду по степени

            Heap ptr_to_head = head;
            while(ptr_to_head != null)
            {

                ptr_to_head.GetSiblingHeap(); // Переходим к следующему дереву
            }

            return null;
        }

        public void Delete(Heap hp)
        {

        }

        public int GetMin()
        {
            return 0;
        }
    }
}
