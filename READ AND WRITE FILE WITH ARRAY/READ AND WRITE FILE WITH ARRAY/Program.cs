using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace READ_AND_WRITE_FILE_WITH_ARRAY
{
    class Program
    {
        static void Main(string[] args)
        {
            int intSizeOfMatrix;
            bool boolCheckInput = false;
            int[,] matrixNumber;
            Dictionary<string, int> miniDataOutput = new Dictionary<string, int>();
            string strOutputName = "data.txt";
            string strOutputPath = string.Empty;
            List<string> allDataToPrint = new List<string>();

            do
            {
                Console.Write("Nhập size của ma trận: ");
                boolCheckInput = int.TryParse(Console.ReadLine(), out intSizeOfMatrix);
            } while (!boolCheckInput || intSizeOfMatrix <= 0);
            matrixNumber = CreateMatrix(intSizeOfMatrix);
            miniDataOutput.Add("Tổng các số chẵn trong ma trận:", SumAllEvenNumberInMatrix(matrixNumber));
            miniDataOutput.Add("Tổng các số trên đường chéo chính:", SumOfMainDiagonal(matrixNumber));
            miniDataOutput.Add("Tổng các số trên đường chéo phụ:", SumOfAntiDiagonal(matrixNumber));
            miniDataOutput.Add("Tổng các số trên đường biên:", SumOfSideLine(matrixNumber));

            allDataToPrint.Add(ToStringMatrix(matrixNumber));
            allDataToPrint.Add("\n");
            foreach (KeyValuePair<string, int> item in miniDataOutput)
            {
                allDataToPrint.Add($"{item.Key} {item.Value}");
            }
            allDataToPrint.Add("\n");
            allDataToPrint.Add("Ma trận tam giác dưới:");
            allDataToPrint.Add($"{ToStringLowerTriangularMatrix(matrixNumber)}");
            allDataToPrint.Add("Ma trận tam giác trên:");
            allDataToPrint.Add($"{ToStringUpperTriangularMatrix(matrixNumber)}");
            foreach (string item in allDataToPrint)
            {
                WriteFile(item, strOutputPath, strOutputName);
            }

        }

        static int[,] CreateMatrix(int intSize)
        {
            Random randomNumber = new Random();
            int[,] randomMatrixNumber = new int[intSize, intSize];
            for (int i = 0; i < randomMatrixNumber.GetLength(0); i++)
            {
                for (int j = 0; j < randomMatrixNumber.GetLength(1); j++)
                {
                    randomMatrixNumber[i, j] = randomNumber.Next(10, 91);
                }
            }
            return randomMatrixNumber;
        }

        static int SumAllEvenNumberInMatrix(int[,] inputMatrix)
        {
            int intSum = 0;
            for (int i = 0; i < inputMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < inputMatrix.GetLength(1); j++)
                {
                    if (IsEven(inputMatrix[i, j])) intSum += inputMatrix[i, j];
                }
            }
            return intSum;
        }

        static bool IsEven(int number)
        {
            if (number % 2 == 0) return true;
            return false;
        }

        static int SumOfMainDiagonal(int[,] inputMatrix)
        {
            int intSum = 0;
            for (int i = 0; i < inputMatrix.GetLength(0); i++)
            {
                intSum += inputMatrix[i, i];
            }
            return intSum;
        }

        static int SumOfAntiDiagonal(int[,] inputMatrix)
        {
            int intSum = 0;
            for (int i = inputMatrix.GetLength(0) - 1, j = 0; i >= 0; i--, j++)
            {
                intSum += inputMatrix[i, j];
            }
            return intSum;
        }

        static int SumOfSideLine(int[,] inputMatrix)
        {
            int intSum = 0;
            for (int i = 0; i < inputMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < inputMatrix.GetLength(1); j++)
                {
                    if (i == 0 || i == inputMatrix.GetLength(0) - 1 || (i > 0 && i < inputMatrix.GetLength(0) - 1 && (j == 0 || j == inputMatrix.GetLength(1) - 1)))
                    {
                        intSum += inputMatrix[i, j];
                    }
                }
            }
            return intSum;
        }

        static string ToStringLowerTriangularMatrix(int[,] matrixInput)
        {
            string result = string.Empty;
            for (int i = 0; i < matrixInput.GetLength(0); i++)
            {
                for (int j = 0; j < matrixInput.GetLength(1); j++)
                {
                    if (j <= i) result += $"{matrixInput[i, j]}\t";
                    else result += "--\t";
                }
                result += "\n";
            }
            return result;
        }

        static string ToStringUpperTriangularMatrix(int[,] matrixInput)
        {
            string result = string.Empty;
            for (int i = 0; i < matrixInput.GetLength(0); i++)
            {
                for (int j = 0; j < matrixInput.GetLength(1); j++)
                {
                    if (j >= i) result += $"{matrixInput[i, j]}\t";
                    else result += "--\t";
                }
                result += "\n";
            }
            return result;
        }

        static string ToStringMatrix(int[,] matrixInput)
        {
            string result = string.Empty;
            for (int i = 0; i < matrixInput.GetLength(0); i++)
            {
                for (int j = 0; j < matrixInput.GetLength(1); j++)
                {
                    result += $"{matrixInput[i, j]}\t";
                }
                result = result.Trim() + "\n";
            }
            return result;
        }

        //static void WriteFile(List<string> dataToPrint, string path, string fileName, bool append = true)
        //{
        //    using (StreamWriter sw = new StreamWriter(path: $@"{path}\{fileName}", append, new UTF8Encoding()))
        //    {
        //        foreach (string item in dataToPrint)
        //        {
        //            sw.WriteLine(item);
        //        }
        //    }
        //}

        static void WriteFile(string dataToPrint, string path, string fileName, bool append = true)
        {
            using (StreamWriter sw = new StreamWriter(path: $@"{path}\{fileName}", append, new UTF8Encoding()))
            {
                sw.WriteLine(dataToPrint);
            }
        }
    }
}
