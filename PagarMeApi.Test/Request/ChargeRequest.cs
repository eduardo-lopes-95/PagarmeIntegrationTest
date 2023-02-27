namespace PagarMeApi.Test.Request
{
    public class ChargeRequest
    {
        public PaymentRequest Payment { get; set; }
        public string OrderId { get; set; }
        public int Amount { get; set; }
        public string DueAt { get; set; }
        public string CustomerId { get; set; }
    }
}
