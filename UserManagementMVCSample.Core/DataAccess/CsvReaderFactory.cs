using CsvHelper;

namespace UserManagementMVCSample.Core.DataAccess
{
    public class CsvReaderFactory : ICsvReaderFactory
    {
        private readonly Func<StreamReader, IReader> _csvReaderFactory;

        public CsvReaderFactory(Func<StreamReader, IReader> csvReaderFactory)
        {
            _csvReaderFactory = csvReaderFactory;
        }

        public IReader Create(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException($"The {filename} filed does not exist.");
            }

            StreamReader streamReader = new(filename);
            return _csvReaderFactory(streamReader);
        }
    }
}
