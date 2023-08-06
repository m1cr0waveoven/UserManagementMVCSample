using CsvHelper;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace UserManagementMVCSample.Core.DataAccess
{
    public static class GenerateCsvReaderWithFactoryExtension
    {
        public static IServiceCollection AddCsvReaderWithFactory(this IServiceCollection services)
        {
            //services.AddSingleton(new StreamReader(filename));
            services.AddSingleton<Func<StreamReader, IReader>>(x=>(fn)=> new CsvReader(fn, CultureInfo.InvariantCulture));
            services.AddSingleton<ICsvReaderFactory, CsvReaderFactory>();
            return services;
        }
    }
}
