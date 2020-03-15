using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinomialHeap.BinomialHeapPack
{

    class Node// <T> // Можно сделать template
    {
        //Поля
        // public Heap heap; //дерево, которому он принадлежит
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
            // this.heap = null;
        }

        public Node(int _value)
        {
            this.brother = null;
            this.child = null;
            this.parent = null;
            this.value = _value;
            this.degree = 0;
            // this.heap = null;
        }

        public void AddChild(Node child){
            /* Добавляет ребёнка к существующему узлу.
             * Нет никакой проверки на правильность данного действия.
             */

            // Настройка параметров ребёнка и родителя
            child.parent = this;
            this.degree = Math.Max(this.degree, child.degree + 1); // Увеличиваем степень родителя

            if (this.child != null){
                // Если ребёнок уже существует

                Node last_brother = this.child.brother; // Узнаём, есть ли у него брат
                if (last_brother != null){ // Если есть брат, то проверяем, есть ли у этого брата брат...
                    while (last_brother.brother != null){
                        last_brother = last_brother.brother;
                    }
                    // Добвляем child в качестве последнего брата
                    last_brother.brother = child;
                }
                else
                {
                    // Если брата ещё нет, делаем child братом
                    this.child.brother = child;
                }
                return;
            }
            // Если ещё нет ни одного ребёнка
            this.child = child;
            this.IncreaseDegreeOfAllParents();
        }

        private void IncreaseDegreeOfAllParents(){
            /* Увеличивает показатель степени для всех родительских Node-ов данного узла.
             * Происходит при появлении у текущего узла узлов-потомков.
             */
            Node current_parrent = this.parent;
            while (current_parrent != null){
                current_parrent.degree++; // Увеличили степень
                current_parrent = current_parrent.parent; // Перешли к следующему
            }
        }

        public Node Find(int value)
        {
            /* Ищет в данном узле и его подузлах узел с значением value.
             * Возвращает null, если не нашёл такой узёл.
             */

            // Если сам узел - ответ:
            if (this.value == value){
               return this;
            }

            // Если у узла есть дети И искомое число БОЛЬШЕ значения данного узла:

            // Если число МЕНЬШЕ значения данного узла, то его дети не могут содержать данное значение,
            // так как там хранятся только узлы с большим и равным значениями.
            if (value > this.value && this.child != null){
                Node answer_node = this.child.Find(value); // Запускаем поиск по детям
                if (answer_node != null){
                    return answer_node;
                }
            }

            // Если у узла есть братья:
            if (this.brother != null){
                Node answer_node = this.brother.Find(value); // Запускаем поиск по братьям
                if (answer_node != null){
                    return answer_node;
                }
            }

            // Если дошли до сюда - узел не был найден.
            return null;
        }

        public Node NoStackFind(int value)
        {
            /* Тот же Find, но без рекурсии.
             */
             return null;
        }
    }
}
