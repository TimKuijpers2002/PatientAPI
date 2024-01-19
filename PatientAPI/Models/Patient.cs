namespace PatientAPI.Models
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string EmailAdress { get; set; }
        public string? PhoneNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public bool ConcentStorageOfRecords { get; set; }
    }
}
