using System.Net;

namespace PagarMeApi.Test.Request
{
    public class CustomerRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }
        public string Document { get; set; }
        public string Type { get; set; }
        public string DocumentType { get; set; }
        public string Gender { get; set; }
        public AddressRequest Address { get; set; }
        public string Birthdate { get; set; }
        public PhonesRequest Phones { get; set; }
        public MetadataResponse Metadata { get; set; }
    }
}
