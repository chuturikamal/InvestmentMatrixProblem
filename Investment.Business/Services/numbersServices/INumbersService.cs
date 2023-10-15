using System;
using System.Threading.Tasks;

namespace Investment.MatrixConversion.Business.Services
{
	public interface INumbersService
	{

        public Task<int> Init(int size);
        public Task<String> GetDataSet(String dataset, String type, int idx);
        Task<bool> validate(String sampleString);
    }
}

