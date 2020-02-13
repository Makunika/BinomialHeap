using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinomialHeap.BinomialHeap
{
   
    class CurHeap// <T> // Можно сделать template
    {
        //Поля
        public CurHeap right;
        public CurHeap left;
        public CurHeap sibling;
        public int value;



        //Конструкторы
        public CurHeap()
        {
            this.right = null;
            this.left = null;
            this.sibling = null;
            this.value = 0;
        }

        public CurHeap(CurHeap right, CurHeap left, CurHeap sibling, int value)
        {
            this.right = right;
            this.left = left;
            this.sibling = sibling;
            this.value = value;
        }





    }
}
