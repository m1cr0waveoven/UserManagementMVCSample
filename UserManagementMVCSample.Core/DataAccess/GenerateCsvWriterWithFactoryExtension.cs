using CsvHelper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementMVCSample.Core.DataAccess
{
    public static class GenerateCsvWriterWithFactoryExtension
    {
        public static IServiceCollection AddCsvWriterWithFactory(this IServiceCollection services)
        {
            //services.AddSingleton(new StreamReader(filename));
            services.AddSingleton<Func<StreamWriter, IWriter>>(x => (fn) => new CsvWriter(fn, CultureInfo.InvariantCulture));
            services.AddSingleton<ICsvWriterFactory, CsvWriterFactory>();
            return services;
        }
    }
}
