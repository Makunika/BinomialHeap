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
            head.degree = 1;
        }


        public int GetMin() { return head.value; }

        public Heap[] DeleteNode(Node node) //если удалим один элепмент, то дерево разобьется на мелкие дервья (поэтому возвращается массив)
        {
            //Math.Log(degree) / Math.Log(2) - эквивалент степени числа в двоичной система счисления
            int lenghtList = (int)(Math.Log(degree) / Math.Log(2)) - 1;
            Heap[] list = new Heap[lenghtList];

            //TODO: код удаления ноды
            //А может лучше только минимум удалять, а не рандомную ноду?



            return list;
        }

        //TODO
        public Node FindCur(int value) { return new Node(); }


        public void Insert(int value) 
        {
            if (head == null)
            {
                head = new Node();
                head.degree = 1;
                head.value = 1;
            }
            else
            {
                Heap heapTmp = new Heap(value);
                Merge(heapTmp);
            }
        }

        public void Merge(Heap heapMerge) //merge heap только с одинаковыми степенями. у какого дерева минимальная голова, тот и станет головой нового дерева
        {
            if (this == null) head = heapMerge.head;
            if (heapMerge == null) return;
            if (degree != heapMerge.degree) throw new InvalidOperationException("Degrees not correct");


            if (head.value <= heapMerge.head.value)
            {
                heapMerge.head.parent = head;
                heapMerge.head.brother = head.child;
                head.child = heapMerge.head;
                head.degree = heapMerge.degree + head.degree;
            }
            else
            {
                head.parent = heapMerge.head;
                head.brother = heapMerge.head.child;
                heapMerge.head.child = head;
                heapMerge.head.degree = heapMerge.degree + head.degree;
                head = heapMerge.head;
            }

        }



        public Heap GetSiblingHeap()
        {
            // Возвращает брата
            return head.heap;
        }
    }
}
