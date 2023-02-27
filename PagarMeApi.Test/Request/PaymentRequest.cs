namespace PagarMeApi.Test.Request
{
    public class PaymentRequest
    {
        public string PaymentMethod { get; set; }
        public CreditCardRequest CreditCard { get; set; }
    }
}