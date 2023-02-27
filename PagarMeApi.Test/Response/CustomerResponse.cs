namespace PagarMeApi.Test.Response
{
    public class CustomerResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }
        public string Document { get; set; }
        public string DocumentType { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public bool Delinquent { get; set; }
        public AddressResponse Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime Birthdate { get; set; }
        public PhonesResponse Phones { get; set; }
        public MetadataResponse Metadata { get; set; }
    }
}
