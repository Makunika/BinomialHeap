using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinomialHeap.StrictlyRegulatedSystem
{
    class StrictlyRegulatedNumber
    {
        /* Строго регулярное число, это бинарное число, допускающее в себе "2"-ки.
         * Вид такого числа:
         * di di-1 ...  d1 d0
         *  , где i - степень двойки (вес цифры), d - значение этого бита.
         *  d может принимать значения {0, 1, 2}.
         *  
         *  В нашей реализации List<int> содержит значения битов данного числа в обратном порядке,
         *  например, следующее число будет сохранено в виде:
         *     12001 -> [1,0,0,2,1]
         * */
        static public void increment(ref List<int> d, int i)
        {
            //Инкрементация (увеличение на значение единицы) i-того элемента числа.
            int len_of_number = d.Count; // Запоминаем исходную длину числа
            if (len_of_number - 1 < i)
            {
                //Если длина числа меньше, чем необходимый бит, то дописываем к числу нужное
                //количество нулей, а на место i-того бита ставим "1".
                int count_of_needed_zeros = i - (len_of_number - 1) - 1;
                for (int added_bits = 0; added_bits < count_of_needed_zeros; added_bits++)
                {
                    d.Add(0);
                }
                // После добавления нулей достаточно записать "1" в конец числа.
                d.Add(1);
                return;
            }
            // Если бит, который необходимо инкрементировать, существует,
            // переходим к основному алгоритму.

            // 1. ++di
            d[i]++;
            // 2. Находим db - первую экстремальную цифру {0,2,N/A} перед (дальше в списке) i
            int index_of_db = -1;
            for (int bit = i + 1; bit < len_of_number; bit++) // Проходимся до конца списка
            {
                if ((d[bit] == 0) || (d[bit] == 2)) // TODO: Понять, что значит N/A число.
                {
                    index_of_db = bit;
                    break;
                }
            }
            bool is_db_NA = false; // Флаг, который поднимается, если db не существует
            // Если индекс не изменился, значит, после di нет экстремальных чисел
            if (index_of_db == -1)
            {
                is_db_NA = true;
            }
            // 3. Находим da - первую экстремальную цифру {0,2,N/A} после (раньше в списке) i
            int index_of_da = -1;
            for (int bit = i - 1; bit >= 0; bit--) // Проходимся до начала списка
            {
                if ((d[bit] == 0) || (d[bit] == 2)) // TODO: Понять, что значит N/A число.
                {
                    index_of_da = bit;
                    break;
                }
            }
            bool is_da_NA = false; // Флаг, который поднимается, если db не существует
            // Если индекс не изменился, значит, после di нет экстремальных чисел
            if (index_of_da == -1)
            {
                is_da_NA = true;
            }
            // 4. if di=3 or ( di=2 and db!=0 )
            if (d[i] == 3 || (d[i] == 2 && (is_db_NA || d[index_of_db] != 0)))
            {
                fix_carry(ref d, i);
            }
            // 5. else if da = 2
            else if (!is_da_NA)
                    if (d[index_of_da] == 2)
                        {
                            fix_carry(ref d, index_of_da);
                        }
        }

        static public void decrement(ref List<int> d, int i)
        {
            // Декрементация (уменьшение на значение единицы) i-того элемента числа.
        }

        static private void fix_carry(ref List<int> d, int i)
        {
            // Операция "фикс-перенос".

            // Считается, что di >= 2.
            if (d[i] >= 2)
            {
                //Выполняем:
                // 1. d_i←d_i-2
                d[i] = d[i] - 2;
                // 2. d_(i+1)←d_(i+1)+1
                // Нужно проверять, есть ли элемент (i+1):
                if (d.Count - 1 < i + 1)
                {
                    //Если длина числа меньше, чем необходимый бит, то дописываем к числу 0.
                    d.Add(0);
                }
                d[i + 1] = d[i + 1] + 1; // Рекурсия?! Проверять то, что заменили вот здесь
                if (d[i + 1] >= 2)
                {
                    fix_carry(ref d, i + 1);
                }
             }
        }

        static private void fix_borrow(ref List<int> d, int i)
        {
            // Операция "фикс-заимствование".

            // Считается, что di <= 2.
            if (d[i] <= 2)
            {
                //Выполняем:
                // 1. d_(i+1)←d_(i+1)-1
                // Не делаем проверку на сущетсвование, так как это ДОЛЖНО быть проверно раньше.
                d[i+1] = d[i+1] - 1;
                // 2. d_i←d_i+2
                d[i] = d[i] + 2;
            }
        }
    }
}
