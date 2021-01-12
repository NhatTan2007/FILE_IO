using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace BAI_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string strPathFile = @"D:\LEARNING\MODULE 2\14. FILE IO\EXERCISE\BAI TAP THEM\READ AND WRITE JSON\BAI 1\BAI 1\data\";
            string strFileNameInput = "input.json";
            string strFileNameOutput1 = "output1.json";
            string strFileNameOutput2 = "output2.json";
            string strDataRead = string.Empty;
            string strDataWrite = string.Empty;
            //read data from json file
            using (StreamReader streamReadFileJson = new StreamReader($"{strPathFile}{strFileNameInput}", new UTF8Encoding()))
            {
                strDataRead = streamReadFileJson.ReadToEnd();
            }
            //Convert data read from file to InputData Type;
            InputData<Numbers> inputData = JsonConvert.DeserializeObject<InputData<Numbers>>(strDataRead);
            #region Câu 1
            //Mapping data Numbers file to NumbersWithAverage file
            List<NumbersWithSum> tempGroupNumbers = new List<NumbersWithSum>();
            InputData<NumbersWithSum> newInputData = new InputData<NumbersWithSum>();
            foreach (Numbers item in inputData.GroupOfNumbers)
            {
                NumbersWithSum temp = new NumbersWithSum();
                temp.a = item.a;
                temp.b = item.b;
                temp.c = item.c;
                tempGroupNumbers.Add(temp);
            }
            newInputData.GroupOfNumbers = tempGroupNumbers;
            //write data to new json file
            strDataWrite = JsonConvert.SerializeObject(newInputData);
            using (StreamWriter streamWriteFileJson = new StreamWriter(path: $"{strPathFile}{strFileNameOutput1}", append: false, new UTF8Encoding()))
            {
                streamWriteFileJson.WriteLine(strDataWrite);
            }
            #endregion

            #region Câu 2
            ////Mapping data Numbers file to double numbers
            //List<Numbers> newGroupNumbersToDouble = new List<Numbers>();
            //foreach (Numbers item in inputData.GroupOfNumbers)
            //{
            //    Numbers temp = new Numbers();
            //    temp.a = item.a * 2;
            //    temp.b = item.b * 2;
            //    temp.c = item.c * 2;
            //    newGroupNumbersToDouble.Add(temp);
            //}
            ////write data to new json file
            //strDataWrite = JsonConvert.SerializeObject(newGroupNumbersToDouble);
            //using (StreamWriter streamWriteFileJson = new StreamWriter(path: $"{strPathFile}{strFileNameOutput2}", append: false, new UTF8Encoding()))
            //{
            //    streamWriteFileJson.WriteLine(strDataWrite);
            //}
            #endregion
        }
    }

    class NumbersWithSum : Numbers
    {
        public double SumNumbers => CalSumNumbers();

        private double CalSumNumbers()
        {
            return a + b + c;
        }
    }
}
