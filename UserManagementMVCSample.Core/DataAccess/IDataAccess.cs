using UserManagementMVCSample.Core.Models;

namespace UserManagementMVCSample.Core.DataAccess
{
    public interface IDataAccess
    {
        Task<bool> CreatePerson(PersonModel person);
        void DeletePerson(int id);
        Task<List<PersonModel>> GetPeople();
        Task<PersonModel> GetPerson(int id);
        Task UpdatePerson(PersonModel person);
    }
}