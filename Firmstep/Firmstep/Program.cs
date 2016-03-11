using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firmstep
{
    public class Program
    {
        static void Main(string[] args)
        {
            int row = 5;
            int column = 5;

            int[,] matrix = new int[row, column];

            PopulateMatrix(matrix, row, column);

            PrintMatrix(matrix, 5);

            Console.ReadKey();

        }

        public static void PopulateMatrix(int[,] matrix, int row, int column)
        {
            int rowTop = 0;
            int rowBot = row - 1;
            int colLeft = 0;
            int colRight = column - 1;

            int direction = 0;

            int count = 0;

            while(rowTop <= rowBot && colLeft <= colRight)
            {
                if (direction == 0)
                {
                    for(int i = colLeft; i < colRight; i++)
                    {
                        matrix[i, rowBot] = count;
                        count++;
                    }

                    rowBot--;
                    direction = 1;
                }
                else if(direction == 1)
                {
                    for(int i = colRight; i > rowTop; i--)
                    {
                        matrix[colRight, i] = count;
                        count++;
                    }

                    colRight--;
                    direction = 2;
                }
                else if(direction == 2)
                {
                    for(int i = colRight; i > colLeft; i--)
                    {
                        matrix[i, rowTop] = count;
                        count++;
                    }
                    rowTop++;
                    direction = 3;
                }
                else if(direction == 3)
                {
                    for(int i = rowTop; i < rowBot; i++)
                    {
                        matrix[colLeft, i] = count;
                        count++;
                    }
                    colLeft++;
                    direction = 0;
                }
            }
            
        } 
        private static void PrintMatrix(int[,] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0,3}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
