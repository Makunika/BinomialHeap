using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinomialHeap.BinomialHeapPack
{
    class Heap
    {
        //Поля
        public Node head; //братья головоного узла дерева настраивается в классе BinomialHeap
        

        public int degree { get 
            {
                 return head != null? head.degree : 0;
            } }

        
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

        public Heap(Node headNode)
        {
            head = headNode;
        }


        public int GetMin() { return head.value; }

        public BinomialHeap DeleteRoot() //если удалим один элепмент, то дерево разобьется на мелкие дервья (поэтому возвращается массив)
        {
            BinomialHeap biheap = new BinomialHeap();
            Heap[] list = new Heap[degree];
            Node child = head.child;
            for (int i = 0; i < degree; i++)
            {
                child.parent = null;
                list[i] = new Heap(child);

                biheap.Insert(list[i]);

                child = child.brother;
            }

            return biheap;
        }

        public Node Find(int value)
        {
            if (head != null){
                return head.Find(value);
            }
            return null;
        }


        public void Insert(int value) 
        {
            if (head == null)
            {
                head = new Node(value);
                // head.heap = this;
            }
            else
            {
                Heap heapTmp = new Heap(value);
                // head.heap = this;
                Merge(heapTmp);
            }
        }

        public void Merge(Heap heapMerge) //merge heap только с одинаковыми степенями. у какого дерева минимальная голова, тот и станет головой нового дерева
        {
            if (this == null) head = heapMerge.head;
            if (heapMerge == null) return;
            if (degree != heapMerge.degree) throw new InvalidOperationException("Degrees are not equal.");


            if (head.value <= heapMerge.head.value) // Если у существующего дерева head меньше head добавляемого дерева
            {
                this.head.AddChild(heapMerge.head); // Добавляем новое дерево в качестве потомка исходного дерева
                //heapMerge.head.parent = head;
                //heapMerge.head.brother = head.child;
                //head.child = heapMerge.head;
                //head.degree = heapMerge.degree + head.degree;
            }
            else
            {
                heapMerge.head.AddChild(this.head); // Добавляем текущее дерево в качестве потомка нового дерева
                // this.head.parent = heapMerge.head;
                // this.head.brother = heapMerge.head.child;
                // heapMerge.head.child = this.head;
                // heapMerge.head.degree = heapMerge.degree + this.head.degree;
                this.head = heapMerge.head; // Перемещаем ссылку верхушки дерева на верхушку нового дерева
                // this.head.heap = this;
            }
        }

    }
}
