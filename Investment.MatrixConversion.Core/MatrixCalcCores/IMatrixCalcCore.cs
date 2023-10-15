using System;
namespace Investment.MatrixConversion.Core
{
	public interface IMatrixCalcCore
	{
        Task InitMatrix(int size);
        Task<String> MatrixCalculation(int[] Adataset, int[] Bdataset, String type, int idx);
        Task<bool> validate(String sampleString);
    }
}

