using CsvHelper;

namespace UserManagementMVCSample.Core.DataAccess
{
    public interface ICsvReaderFactory
    {
        IReader Create(string fielname);
    }
}