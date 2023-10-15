using System;
using Investment.MatrixConversion.Business.Util;
using System.Drawing;
using Investment.MatrixConversion.Core;

namespace Investment.MatrixConversion.Business.Services
{
	public class NumbersService: INumbersService
    {
        private readonly IMatrixCalcCore _matrixCalcCore;
        public NumbersService(IMatrixCalcCore matrixCalcCore)
        {
            _matrixCalcCore = matrixCalcCore;
        }

		public async Task<int> Init(int size)
		{
            try
            {
                await _matrixCalcCore.InitMatrix(size);
                return size;
            }
            catch(Exception ex) { throw; }
        }

        public async Task<String> GetDataSet(String dataset, String type, int idx)
        {
            try
            {
                String[] strSplit = dataset.Split("|");
                if (strSplit.Length == 2)
                {
                    String setA = strSplit[0];
                    String setB = strSplit[1];

                    int[] datasetA = setA.Split(",").Select(x => int.Parse(x)).ToArray();
                    int[] datasetB = setB.Split(",").Select(x => int.Parse(x)).ToArray();

                    return await _matrixCalcCore.MatrixCalculation(datasetA, datasetB, type, idx);
                }
                else throw new Exception("datasets are not valid");
            }
            catch(Exception) { throw; }
        }

        public async Task<bool> validate(String sampleString)
        {
            try
            {
                return await _matrixCalcCore.validate(sampleString);
            }
            catch (Exception) { throw; }
        }
    }
}

