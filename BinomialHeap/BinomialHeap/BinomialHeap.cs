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
        }

        private void Merge(Heap h1, Heap h2)
        {

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
            return 0;
        }
    }
}
