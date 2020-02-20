using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinomialHeap.BinomialHeap
{
    class Heap //у правого потомка не могут быть потомков
    {
        //Поля
        Node head;

        
        //Конструкторы
        public Heap()
        {
            head = null;
        }
        public Heap(int value)
        {
            head = null;
            Insert(value);
        }

        public Heap(int[] values)
        {
            head = null;
            foreach (int value in values)
            {
                Insert(value);
            }
            
        }


        //////////////МЕТОДЫ МАКСИМ////////////////////////////
        public int GetMin() { return 5; }
        public int GetMax() { return 5; }
        public void DeleteCur(Node cur) { }

        //////////////МЕТОДЫ СЕРЕЖА////////////////////////////
        public Node FindCur(int value) { return new Node(); }
        public void Insert(int value) { }
        // Плюс еще методы, если надо будет 

        public Heap GetSibling()
        {
            // Возвращает брата
            return null;
        }
    }
}
