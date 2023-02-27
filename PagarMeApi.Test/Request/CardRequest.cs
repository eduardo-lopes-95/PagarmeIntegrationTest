namespace PagarMeApi.Test.Request
{
    public class CardRequest
    {
        public BillingAddressRequest BillingAddress { get; set; }
        public OptionsRequest Options { get; set; }
        public string Number { get; set; }
        public string HolderName { get; set; }
        public string HolderDocument { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }
        public string Cvv { get; set; }
        public string Brand { get; set; }
        public string Label { get; set; }
    }
}
