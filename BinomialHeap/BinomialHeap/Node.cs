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
        public Node left { get; set; }
        public Node brother;
        public Node parent;
        public int value;



        //Конструкторы
        public Node()
        {
            this.brother = null;
            this.left = null;
            this.parent = null;
            this.value = 0;
        }
    }
}
