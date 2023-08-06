using CsvHelper.Configuration.Attributes;

namespace UserManagementMVCSample.Core.Models
{ 
    public class PersonModel
    {
        public int ID { get; set; }
        public string Username { get; set; }       
        public string Password { get; set; }        
        public string Lastname { get; set; }        
        public string Firstname { get; set; }        
        public string DateOfBirth { get; set; }        
        public string PlaceOfBirth { get; set; }
        public string Residence { get; set; }
    }
}
