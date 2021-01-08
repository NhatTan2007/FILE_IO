using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace READ_AND_WRITE_FILE
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = string.Empty;
            string inputFileName = "InputData.txt";
            string outputPath = string.Empty;
            string outputFileName = "OutputData.txt";
            List<string> inputData = new List<string>();
            List<string> outputData = new List<string>();
            string outputDataToPrint = string.Empty;
            int[,] matrixCreate;
            int[,] matrixRead;
            int sizeRow = 0;
            int sizeCol = 0;
            List<string> matrixStringData;
            List<int> matrixNumberData = new List<int>();
            Dictionary<int, int> numbersExistsInMatrix = new Dictionary<int, int>();
            

            inputData = ReadFile(inputFileName);
            string[] matrixSetupData = inputData[0].Split(" ");
            bool checkSizeRow = int.TryParse(matrixSetupData[0], out sizeRow);
            bool checkSizeCol = int.TryParse(matrixSetupData[1], out sizeCol);
            if (checkSizeCol || checkSizeRow)
            {
                //create a Matrix after read row and column
                matrixCreate = CreateMatrix(sizeRow, sizeCol);
                outputData.Add(inputData[0]);
                outputData.Add(ToStringMatrix(matrixCreate));
                foreach (string item in outputData)
                {
                    outputDataToPrint += item + "\n";
                }
                WriteFile(outputDataToPrint, inputFileName);
                inputData.Clear();
                outputData.Clear();
                //Read data from file input already have matrix
                inputData = ReadFile(inputFileName);
                while (inputData.Contains("")) inputData.Remove("");

                //Chose matrix data from inputData
                matrixStringData = new List<string>(inputData);
                matrixStringData.RemoveAt(0);
                foreach (string item in matrixStringData)
                {
                    string[] tempNumber = item.Split(" ");
                    foreach (string number in tempNumber)
                    {
                        matrixNumberData.Add((int.Parse(number)));
                    }
                }
                matrixRead = new int[sizeRow, sizeCol];
                //Create a matrix from matrix data
                if (matrixRead.Length == matrixNumberData.Count)
                {
                    GetMatrixFromData(matrixNumberData, matrixRead);
                    int[,] x3Matrix = new int[sizeRow, sizeCol];
                    for (int i = 0; i < x3Matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < x3Matrix.GetLength(1); j++)
                        {
                            x3Matrix[i, j] = matrixRead[i, j] * 3;
                        }
                    }
                    foreach (int item in matrixNumberData)
                    {
                        if (!numbersExistsInMatrix.ContainsKey(item))
                        {
                            numbersExistsInMatrix.Add(item, 0);
                        }
                    }
                    foreach (int item in matrixNumberData)
                    {
                        numbersExistsInMatrix[item]++;
                    }

                    //Make data to write
                    string dataToWrite = string.Empty;
                    dataToWrite += "Tổng giá trị các số chẵn trong ma trận: " + SumEvenNumbers(matrixRead) + "\n";
                    dataToWrite += "Tổng giá trị các số trên đường biên ma trận: " + SumBorderLine(matrixRead) + "\n";
                    dataToWrite += ToStringMatrix(x3Matrix);
                    dataToWrite += "Số lần xuất hiện các giá trị trong ma trận \n";
                    foreach (KeyValuePair<int, int> item in numbersExistsInMatrix)
                    {
                        dataToWrite += $"|\t{item.Key}\t";
                    }
                    dataToWrite += "|\n";
                    foreach (KeyValuePair<int, int> item in numbersExistsInMatrix)
                    {
                        dataToWrite += $"|\t{item.Value}\t";
                    }
                    dataToWrite += "|";

                    //write file
                    WriteFile(dataToWrite, outputFileName);
                    

                }
                else Console.WriteLine("Please check again your data");

            } else Console.WriteLine("Please check your input data");


        }

        static List<string> ReadFile(string pathFile)
        {
            using (StreamReader reader = new StreamReader(pathFile, new UTF8Encoding()))
            {
                List<string> dataReader = new List<string>();
                string line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    dataReader.Add(line);
                }
                return dataReader;
            }
        }

        static void WriteFile(string dataToWrite, string pathFile, bool append = false)
        {
            using (StreamWriter writer = new StreamWriter(path: pathFile, append: append, new UTF8Encoding()))
            {
                writer.WriteLine(dataToWrite);
            }
        }

        static string ToStringMatrix(int[,] matrix)
        {
            string result = string.Empty;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result += $"{matrix[i, j]} ";
                }
                result = result.Trim() + "\n";
            }
            return result;
        }

        static int[,] CreateMatrix(int row, int column)
        {
            Random randomNumber = new Random();
            int[,] newMatrix = new int[row, column];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    newMatrix[i, j] = randomNumber.Next(10, 21);
                }
            }
            return newMatrix;
        }

        static void GetMatrixFromData(List<int> data, int[,] desMatrix)
        {
            int count = 0;
            for (int i = 0; i < desMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < desMatrix.GetLength(1); j++)
                {
                    desMatrix[i, j] = data[count++];
                }
            }
        }

        static int SumEvenNumbers(int[,] matrix)
        {
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sum += matrix[i, j];
                }
            }
            return sum;
        }

        static int SumBorderLine(int[,] matrix)
        {
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == 0 || i == matrix.GetLength(0) - 1 || (i != 0 && i != matrix.GetLength(0) - 1 && (j == 0 || j == matrix.GetLength(1))))
                    {
                        sum += matrix[i, j];
                    }
                }
            }
            return sum;
        }
    }
}
