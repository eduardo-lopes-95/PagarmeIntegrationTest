namespace PagarMeApi.Test.Request
{
    public class CreditCardRequest
    {
        public int Installments { get; set; }
        public string StatementDescriptor { get; set; }
        public CardRequest Card { get; set; }
    }
}