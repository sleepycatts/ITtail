using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    public class Matrix
    {
        public double[,] MatrixArray { get; set; }
        public int N { get; set; }
        public Matrix(int n)
        {
            MatrixArray = new double[n, n];
            N = n;
        }
        public int MonotoneRows()
        {
            int count = 0;
            //проходим массив
            for(int j = 0; j < N; j++)
            {
                bool firstIter = true;
                bool monotone = true;
                int a = 0;
                for(int i= 1; i < N; i++)
                {
                    if (firstIter)
                    {
                        firstIter = false;
                        a = MatrixArray[i, j].CompareTo(MatrixArray[i - 1, j]);
                        continue;
                    }
          
                    if (MatrixArray[i, j].CompareTo(MatrixArray[i - 1, j]) != a)
                    {
                        monotone = false;
                        break;
                    }     
                }
                if (monotone)
                    count++;
            }
            return count;
        }
    }
}
