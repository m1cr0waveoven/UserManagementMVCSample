using CsvHelper;

namespace UserManagementMVCSample.Core.DataAccess
{
    public interface ICsvWriterFactory
    {
        IWriter Create(string filename, bool append);
    }
}