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
            int row = 10;
            int column = 10;

            int[,] matrix = new int[row, column];

            PopulateMatrix(matrix, row, column);

            PrintMatrix(matrix, 10);

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

            int currentStep = 0;
            int maxStep = (row * column) - 1;

            while(currentStep <= maxStep)
            {
                if (direction == 0)
                {
                    for(int i = colLeft; i < colRight; i++)
                    {
                        matrix[rowBot, i] = count;
                        count++;
                        currentStep++;
                    }

                    rowBot--;
                    direction = 1;
                }
                else if(direction == 1)
                {
                    for(int i = colRight; i > rowTop; i--)
                    {
                        matrix[i, colRight] = count;
                        count++;
                        currentStep++;
                    }

                    colRight--;
                    direction = 2;
                }
                else if(direction == 2)
                {
                    for(int i = colRight + 1; i > colLeft; i--)
                    {
                        matrix[rowTop, i] = count;
                        count++;
                        currentStep++;
                    }
                    rowTop++;
                    direction = 3;
                }
                else if(direction == 3)
                {
                    for(int i = rowTop - 1; i <= rowBot; i++)
                    {
                        matrix[i, colLeft] = count;
                        count++;
                        currentStep++;
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
