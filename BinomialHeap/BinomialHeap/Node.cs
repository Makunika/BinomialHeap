using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinomialHeap.BinomialHeap
{
   
    class Node// <T> // Можно сделать template
    {
        //Поля
        public Node right;
        public Node child;
        public Node sibling;
        public int value;
        public int degree; //степень и количество потомков



        //Конструкторы
        public Node()
        {
            this.right = null;
            this.child = null;
            this.sibling = null;
            this.value = 0;
        }


    }
}
