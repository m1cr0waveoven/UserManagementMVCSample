using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementMVCSample.Core.DataAccess
{
    public class CsvWriterFactory : ICsvWriterFactory
    {
        Func<StreamWriter, IWriter> _csvWriterFactory;

        public CsvWriterFactory(Func<StreamWriter, IWriter> csvWriterFactory)
        {
            _csvWriterFactory = csvWriterFactory;
        }

        public IWriter Create(string filename, bool append)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException($"The {filename} filed does not exist.");
            }

            StreamWriter streamWriter = new(filename, append, Encoding.UTF8);
            return _csvWriterFactory(streamWriter);
        }
    }
}
