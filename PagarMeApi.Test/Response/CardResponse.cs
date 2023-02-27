namespace PagarMeApi.Test.Response
{
    public class CardResponse
    {
        public string Id { get; set; }
        public string FirstSixDigits { get; set; }
        public string LastFourDigits { get; set; }
        public string Brand { get; set; }
        public string HolderName { get; set; }
        public string HolderDocument { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }
        public string Status { get; set; }
        public string Label { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public BillingAddressResponse BillingAddress { get; set; }
        public CustomerResponse Customer { get; set; }
        public string Type { get; set; }
    }
}
