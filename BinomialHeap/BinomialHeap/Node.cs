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
        public Node left;
        public Node sibling;
        public int value;



        //Конструкторы
        public Node()
        {
            this.right = null;
            this.left = null;
            this.sibling = null;
            this.value = 0;
        }

        public Node(Node right, Node left, Node sibling, int value)
        {
            this.right = right;
            this.left = left;
            this.sibling = sibling;
            this.value = value;
        }





    }
}
