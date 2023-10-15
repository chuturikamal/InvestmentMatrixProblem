using System;
using Microsoft.Extensions.DependencyInjection;
using Investment.MatrixConversion.Business.Services;
using Investment.MatrixConversion.Core;

namespace Investment.MatrixConversion.Business.Configurations
{
	public static class ServiceExtension
	{
		public static void AddServiceCollection(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddScoped<INumbersService, NumbersService>();
			serviceCollection.AddScoped<IMatrixCalcCore, MatrixCalcCore>();
        }
	}
}

