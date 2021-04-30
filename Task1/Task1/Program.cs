using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixLib;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //содержит размер матрицы
            int n = 0;
            //делаем "бесконечный" цикл, для опроса пользователя о размере массива
            while (true)
            {
                //делаем обертку на исключение
                try
                {
                    //спрашиваем пользователя о размерность
                    Console.Write("Укажите N (размер матрицы): ");
                    n = int.Parse(Console.ReadLine());
                    //выходим из бесконечного цикла, если размерность больше 1, иначе так и будем в нем крутиться
                    if (n > 1)
                        break;
                    Console.WriteLine("Размер матрицы должен быть больше 1!");
                }
                catch
                {
                    //если пользователь ввел неправильные данные, выводится ошибка и выполняется следующая итерация цикла
                    Console.WriteLine("Ошибка, неправильный формат входных данных!");
                }
            }
            //новый объект типа Matrix
            Matrix matrix = new Matrix(n);
            //пробегаем матрицу
            for(int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    //здесь по аналогии с размерностью, только теперь мы заполняем массив данными
                    while (true)
                    {
                        try
                        {
                            Console.Write($"Элемент [{i},{j}]: ");
                            matrix.MatrixArray[i,j] = double.Parse(Console.ReadLine());
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Ошибка, неправильный формат входных данных!");
                        }
                    }
                }
            }
            //выводим результат на экран
            Console.WriteLine("Монотонных строк в матрице: "+matrix.MonotoneRows());
            Console.ReadKey();
        }
    }
}
