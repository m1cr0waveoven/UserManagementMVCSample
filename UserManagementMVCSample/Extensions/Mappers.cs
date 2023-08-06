namespace UserManagementMVCSample.Extensions
{
    using PersonDto = UserManagementMVCSample.Core.Models.PersonModel;
    using PersonViewModel = UserManagementMVCSample.Models.PersonModel;
    public static class Mappers
    {
        public static PersonViewModel ToPersonModel(this PersonDto model)
        {
            PersonViewModel viewModel = new PersonViewModel();
            viewModel.ID = model.ID;
            viewModel.Username = model.Username;
            viewModel.Password = model.Password;
            viewModel.Firstname = model.Firstname;
            viewModel.Lastname = model.Lastname;
            viewModel.DateOfBirth = DateTime.Parse(model.DateOfBirth);
            viewModel.PlaceOfBirth = model.PlaceOfBirth;
            viewModel.Residence = model.Residence;
            return viewModel;
        }

        public static PersonDto ToPersonDto(this PersonViewModel model)
        {
            PersonDto personDto = new PersonDto();
            personDto.ID = model.ID;
            personDto.Username = model.Username;
            personDto.Password = model.Password;
            personDto.Firstname = model.Firstname;
            personDto.Lastname = model.Lastname;
            personDto.DateOfBirth = model.DateOfBirth.ToString("d");
            personDto.PlaceOfBirth = model.PlaceOfBirth;
            personDto.Residence=model.Residence;
            return personDto;
        }
    }
}
