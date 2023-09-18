using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ТеорияСистемИСистемныйАнализ
{
    internal class GroupExpertAssessment
    {
        public static void CalculationGroupExpertAssessment(double[,] matrix)
        {
            WriteMatrix(matrix);
            NormalizationMatrix(matrix);
            WriteMatrix(matrix);
            double[,] rangsMatrix = CalculationMatrixRangs(matrix);
            WriteMatrix(rangsMatrix);
            CalculationCoefСompetence(matrix);

        }

        private static void CalculationCoefСompetence(double[,] matrix)
        {
            double[,] k = new double[5,5];
            for (int i = 0; i < k.Length; i++)
            {
                k[i,0] = 1 / matrix.GetLength(0);
            }
            double xtj;
            for (int t = 0; t < 5; t++)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        
                    }
                }
            }
            
            
        }

        private static double[,] CalculationMatrixRangs(double[,] matrix)
        {
            double[,] rangsMatrix = new double[matrix.GetLength(0), matrix.GetLength(1)];
            double[,] matrixTMP = matrix;
            double max;
            bool flagDoublicate = false;
            for (int i = 0; i < matrixTMP.GetLength(0); i++)
            {

                for (int k = 1; k < matrixTMP.GetLength(1)+1; k++)
                {
                    max = double.MinValue;
                    List<int> indexMin = new();
                    for (int j = 0; j < matrixTMP.GetLength(1); j++)
                    {
                        if (matrixTMP[i, j] > max)
                        {
                            max = matrixTMP[i, j];
                         
                        }
                    }
                    for (int z = 0; z < matrixTMP.GetLength(1); z++)
                    {
                        if (matrixTMP[i, z] == max)
                        {
                            matrixTMP[i, z] = double.MinValue;
                            indexMin.Add(z);
                        }
                    }
                    WriteMatrix(matrixTMP);
                    WriteMatrix(rangsMatrix);
                    foreach (var item in indexMin)
                    {
                        if (rangsMatrix[i, item]==0&&indexMin.Count<2)
                        {
                            rangsMatrix[i, item] = k;
                        }
                        if (rangsMatrix[i, item] == 0 && indexMin.Count >= 2)
                        {
                            rangsMatrix[i, item] = (k+k+1.0)/2.0;
                            flagDoublicate = true;
                        }
                    }
                    if (flagDoublicate)
                    {
                        k++;
                        flagDoublicate = false;
                    }

                }
                
            }
            return rangsMatrix;

        }

        private static void NormalizationMatrix(double[,] matrix)
        {
            double max;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                max = double.MinValue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max) max = matrix[i, j];
                }
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    matrix[i, k] = matrix[i, k] / max;
                }
            }
        }

        public static void WriteMatrix(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0}\t", matrix[i, j]);

                }
            }
            Console.WriteLine();
        }
        public static void WriteMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0}\t", matrix[i, j]);

                }
            }
            Console.WriteLine();
        }
    }
}
