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
        public Heap heap; //дерево, которому он пренадежит
        public Node child { get; set; }
        public Node brother;
        public Node parent;
        public int value;
        public int degree;



        //Конструкторы
        public Node()
        {
            this.brother = null;
            this.child = null;
            this.parent = null;
            this.value = 0;
            this.degree = 0;
            this.heap = null;
        }
    }
}
