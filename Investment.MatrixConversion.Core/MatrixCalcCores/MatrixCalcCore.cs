using System;
using System.Data;
using System.Drawing;
using Investment.MatrixConversion.Core.Utils;

namespace Investment.MatrixConversion.Core
{
	public class MatrixCalcCore: IMatrixCalcCore
    {
		public MatrixCalcCore()
		{
		}

		public Task InitMatrix(int size)
        {
            try
			{
                Collection.Size = size;
                Collection.MatrixA = new int[size, size];
				Collection.MatrixB = new int[size, size];

                return Task.CompletedTask;
            }
			catch(Exception) { throw; }
        }

        public async Task<String> MatrixCalculation(int[] Adataset, int[] Bdataset, String type, int idx)
        {
            try
            {
                String retVal = String.Empty;
                int size = Collection.Size;
                int[,] matrixA = new int[size, size];
                int[,] matrixB = new int[size, size];
                int[,] matrixC = new int[size, size];
                int totalVal = size * size;

                if (Adataset.Length != totalVal || Adataset.Length != totalVal)
                    throw new Exception("dataset not matching with size");

                if(type == "row")
                    retVal = this.setRowMatrix(out matrixC, Adataset, Bdataset, idx);
                else if(type == "col")
                    retVal = this.setColMatrix(out matrixC, Adataset, Bdataset, idx);

                Collection.CalcVal = retVal;

                return this.GenerateMD5(retVal);
            }
			catch (Exception) { throw; }
		}

        public async Task<bool> validate(String sampleString)
        {
            try
            {
                var val = Collection.CalcVal;
                String generatedmd5 = this.GenerateMD5(val);
                if (sampleString == generatedmd5)
                    return true;
                else
                    return false;
            }
            catch (Exception) { throw; }
        }

        #region Local Methods

        private String setRowMatrix(out int[,] matrixC, int[] Adataset, int[] Bdataset, int idx)
        {
            try
            {
                int size = Collection.Size;
                matrixC = new int[size, size];
                int rowA = 0, originrowA = 0;
                int rowC = idx, colC = 0;
                int totalVal = size * size;
                
                rowA = size * (idx - 1);
                originrowA = rowA;
                String retVal = String.Empty;
                for (int i = 0; i < totalVal; i++)
                {
                    int aVal = Adataset[rowA];
                    int bVal = Bdataset[i];

                    int calcVal = aVal * bVal;
                    matrixC[idx - 1, colC] += calcVal;
                    retVal += $"{matrixC[idx - 1, colC]},";

                   if (colC == size - 1)
                   {
                        rowA++;
                        colC = 0;
                        if (i + 1 < totalVal)
                            retVal = string.Empty;
                   }
                   else
                   {
                       colC++;
                   }

                }

                return retVal;
            }
            catch(Exception) { throw; }
        }

        private String setColMatrix(out int[,] matrixC, int[] Adataset, int[] Bdataset, int idx)
        {
            try
            {
                String retVal = String.Empty;
                int size = Collection.Size;
                matrixC = new int[size, size];

                int rowB = 0, originrowB = 0;
                int rowC = 0, colC = idx;
                int totalVal = size * size;


                rowB = idx - 1;
                originrowB = rowB;
                int count = 0;
                for (int i = 0; i < totalVal; i++)
                {
                    int bVal = Bdataset[rowB];
                    int aVal = Adataset[i];

                    int calcVal = aVal * bVal;
                    matrixC[rowC, idx - 1] += calcVal;
                    

                    if (count == size - 1)
                    {
                        retVal += $"{matrixC[rowC, idx - 1]},";
                        count = 0;
                        rowB = idx - 1;
                        rowC++;
                    }
                    else
                    {
                        rowB += size;
                        count++;
                    }

                }
                return retVal;
            }
            catch (Exception) { throw; }
        }

        private String GenerateMD5(String input)
        {
            try
            {
                using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
                {
                    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);

                    return Convert.ToHexString(hashBytes); 
                }
            }
            catch(Exception) { throw; }
        }

            private Task<int[,]> setMatrix(int[] dataset, int size)
        {
            try
            {
                int[,] matrix = new int[size, size];

                int row = 0;
                int col = 0;
                for (int i = 0; i < dataset.Length; i++)
                {
                    int val = dataset[i];
                    if (row == size)
                        break;

                    matrix[row, col] = val;
                    if (col == size - 1)
                    {
                        row++;
                        col = 0;
                    }
                    else
                        col++;
                }
                return Task.FromResult(matrix);
            }
            catch (Exception) { throw; }
        }

		/*private Task<String> MatrixMulti(int[,] matrixA, int[,] matrixB, int size)
		{
            try
            {
                for
            }
            catch (Exception) { throw; }
		}*/

        #endregion
    }
}

