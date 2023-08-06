using CsvHelper;
using UserManagementMVCSample.Core.Models;

namespace UserManagementMVCSample.Core.DataAccess
{
    public class DataAccess : IDataAccess
    {
        readonly ICsvReaderFactory _csvReaderFactory;
        readonly ICsvWriterFactory _csvWriterFactory;
        readonly string _filename;

        public DataAccess(ICsvReaderFactory csvReaderFactory, ICsvWriterFactory csvWriterFactory, string filename)
        {
            _csvReaderFactory = csvReaderFactory;
            _csvWriterFactory = csvWriterFactory;
            _filename = filename;
        }

        public async Task<List<PersonModel>> GetPeople()
        {
            try
            {
                using var reader = _csvReaderFactory.Create(_filename);
                var people = reader.GetRecordsAsync<PersonModel>();
                return await people.ToListAsync();
            }
            catch (FileLoadException ex)
            {
                throw;
            }
            catch (CsvHelperException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PersonModel> GetPerson(int id)
        {
            try
            {
                var person = (await GetPeople()).FirstOrDefault(p => p.ID == id);
                return person;
            }
            catch (FileNotFoundException ex)
            {
                throw;
            }
            catch (CsvHelperException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<bool> CreatePerson(PersonModel person)
        {
            if (person is null || person.ID <= 0)
                return false;

            try
            {
                person.ID = await GetNextNewId();
                using var writer = _csvWriterFactory.Create(_filename, true);
                writer.WriteRecord(person);
                return true;
            }
            catch (FileNotFoundException ex)
            {
                throw;
            }
            catch (CsvHelperException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task UpdatePerson(PersonModel person)
        {
            if (person is null || person.ID <= 0)
                return;

            var people = await GetPeople();
            int index = people.FindIndex(p => p.ID == person.ID);
            people.RemoveAt(index);
            people.Insert(index, person);
            using var writer = _csvWriterFactory.Create(_filename, false);
            await writer.WriteRecordsAsync(people);
        }

        public void DeletePerson(int id)
        {
            if (id <= 0)
                return;
        }

        private async Task<int> GetNextNewId()
        {
            int[] idArray = (await GetPeople()).Select(p => p.ID).ToArray();
            Array.Sort(idArray);
            return idArray[idArray.Length - 1];
        }
    }
}
