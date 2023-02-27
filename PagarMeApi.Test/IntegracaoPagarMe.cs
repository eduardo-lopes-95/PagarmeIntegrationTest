using Newtonsoft.Json;
using PagarMeApi.Test.Request;
using PagarMeApi.Test.Response;
using RestSharp;

namespace PagarMeApi.Test
{
    public class IntegracaoPagarMe
    {
        [Fact]
        public void CriarCliente()
        {
            var uri = "customers";
            var customerBody = "{\"name\":\"Eduardo Sabino\",\"email\":\"eduardosabinoteste@telecall.com\",\"code\":\"EDUARDOSABINOTESTE\",\"document\":\"93095135270\",\"type\":\"individual\",\"document_type\":\"CPF\",\"gender\":\"male\",\"address\":{\"line_1\":\"375, Av. General Justo, Centro\",\"line_2\":\"8º andar\",\"zip_code\":\"20021130\",\"city\":\"Rio de Janeiro\",\"state\":\"RJ\",\"country\":\"BR\"},\"birthdate\":\"05/03/1984\",\"phones\":{\"home_phone\":{\"country_code\":\"55\",\"area_code\":\"21\",\"number\":\"000000000\"},\"mobile_phone\":{\"country_code\":\"55\",\"area_code\":\"21\",\"number\":\"000000000\"}},\"metadata\":{\"company\":\"Avengers\"}}";
            RestClient client;
            RestRequest request;
            ClientPost(uri, customerBody, out client, out request);
            var response = client.ExecutePost<CustomerResponse>(request);
            Assert.NotNull(response.Content);
        }

        [Fact]
        public void ObterCliente()
        {
            var uri = "customers/cus_3vZQDE4ueuaOn7pN";
            RestClient client;
            RestRequest request;
            ClientGet(uri, out client, out request);
            var response = client.ExecuteGet<CustomerResponse>(request);
            var contentResponse = JsonConvert.DeserializeObject<CustomerResponse>(response.Content);
            var expectedJson = "{\r\n  \"id\": \"cus_3vZQDE4ueuaOn7pN\",\r\n  \"name\": \"Eduardo Sabino\",\r\n  \"email\": \"eduardosabinoteste@telecall.com\",\r\n  \"code\": \"EDUARDOSABINOTESTE\",\r\n  \"document\": \"93095135270\",\r\n  \"document_type\": \"cpf\",\r\n  \"type\": \"individual\",\r\n  \"gender\": \"male\",\r\n  \"delinquent\": false,\r\n  \"address\": {\r\n    \"id\": \"addr_5KxlJxli3inJMZwp\",\r\n    \"line_1\": \"375, Av. General Justo, Centro\",\r\n    \"line_2\": \"8º andar\",\r\n    \"zip_code\": \"20021130\",\r\n    \"city\": \"Rio de Janeiro\",\r\n    \"state\": \"RJ\",\r\n    \"country\": \"BR\",\r\n    \"status\": \"active\",\r\n    \"created_at\": \"2023-02-25T20:43:56Z\",\r\n    \"updated_at\": \"2023-02-25T20:43:56Z\"\r\n  },\r\n  \"created_at\": \"2023-02-25T20:43:56Z\",\r\n  \"updated_at\": \"2023-02-25T20:43:56Z\",\r\n  \"birthdate\": \"1984-05-03T00:00:00Z\",\r\n  \"phones\": {\r\n    \"home_phone\": {\r\n      \"country_code\": \"55\",\r\n      \"number\": \"000000000\",\r\n      \"area_code\": \"21\"\r\n    },\r\n    \"mobile_phone\": {\r\n      \"country_code\": \"55\",\r\n      \"number\": \"000000000\",\r\n      \"area_code\": \"21\"\r\n    }\r\n  },\r\n  \"metadata\": {\r\n    \"company\": \"Avengers\"\r\n  }\r\n}";
            var expected = JsonConvert.DeserializeObject<CustomerResponse>(expectedJson);
            Assert.Equivalent(contentResponse, expected);
        }

        [Fact]
        public void CriarCartao()
        {
            var uri = "customers/cus_3vZQDE4ueuaOn7pN/cards";
            var cardBody = "{\"number\":\"5502092853186384\",\"holder_name\":\"EDUARDO S LOPES\",\"holder_document\":\"15148116773\",\"exp_month\":1,\"exp_year\":31,\"cvv\":\"413\",\"brand\":\"Mastercard\",\"label\":\"Top\"}";
            RestClient client;
            RestRequest request;
            ClientPost(uri, cardBody, out client, out request);
            var response = client.ExecutePost<CardRequest>(request);
            Assert.True(response.IsSuccessful);
        }

        [Fact]
        public void ObterCartao()
        {
            var uri = "customers/cus_3vZQDE4ueuaOn7pN/cards/card_5JrK2JUPGsR6Kbn0";
            RestClient client;
            RestRequest request;
            ClientGet(uri, out client, out request);
            var response = client.ExecuteGet<CardResponse>(request);
            var contentResponse = JsonConvert.DeserializeObject<CardResponse>(response.Content);
            var expectedJson = "{\r\n  \"id\": \"card_5JrK2JUPGsR6Kbn0\",\r\n  \"first_six_digits\": \"550209\",\r\n  \"last_four_digits\": \"6384\",\r\n  \"brand\": \"Mastercard\",\r\n  \"holder_name\": \"EDUARDO S LOPES\",\r\n  \"holder_document\": \"15148116773\",\r\n  \"exp_month\": 1,\r\n  \"exp_year\": 2031,\r\n  \"status\": \"active\",\r\n  \"type\": \"credit\",\r\n  \"label\": \"Top\",\r\n  \"created_at\": \"2023-02-25T23:23:50Z\",\r\n  \"updated_at\": \"2023-02-25T23:23:50Z\",\r\n  \"customer\": {\r\n    \"id\": \"cus_3vZQDE4ueuaOn7pN\",\r\n    \"name\": \"Eduardo S Lopes\",\r\n    \"email\": \"eduardosabinoteste@telecall.com\",\r\n    \"code\": \"EDUARDOSABINOTESTE\",\r\n    \"document\": \"03244975712\",\r\n    \"document_type\": \"CPF\",\r\n    \"type\": \"individual\",\r\n    \"gender\": \"male\",\r\n    \"delinquent\": false,\r\n    \"created_at\": \"2023-02-25T20:43:56Z\",\r\n    \"updated_at\": \"2023-02-25T22:57:01Z\",\r\n    \"birthdate\": \"1984-05-03T00:00:00Z\",\r\n    \"phones\": {},\r\n    \"metadata\": {\r\n      \"company\": \"Avengers\"\r\n    }\r\n  }\r\n}";
            var expected = JsonConvert.DeserializeObject<CardResponse>(expectedJson);
            Assert.Equivalent(contentResponse, expected);
        }

        [Fact]
        public void CriarCobranca()
        {
            var uri = "charges";
            var chargeBody = "{\"payment\":{ \"payment_method\":\"credit_card\",\"credit_card\":{ \"installments\":1,\"statement_descriptor\":\"teste\",\"card\":{ \"number\":\"5502092853186384\",\"holder_name\":\"Eduardo S Lopes\",\"exp_month\":2,\"exp_year\":31,\"cvv\":\"413\",\"billing_address\":{ \"zip_code\":\"20021130\",\"city\":\"Rio de Janeiro\",\"state\":\"RJ\",\"country\":\"BR\",\"line_1\":\"375, Av. General Justo, Centro\"} } } },\"order_id\":\"Codigo31\",\"amount\":2,\"due_at\":\"2023-03-26T00:00:00\",\"customer_id\":\"cus_3vZQDE4ueuaOn7pN\"}";
            RestClient client;
            RestRequest request;
            ClientPost(uri, chargeBody, out client, out request);
            var response = client.ExecutePost<ChargeRequest>(request);
            Assert.False(response.IsSuccessful);
        }

        private static void ClientPost(string uri, string body, out RestClient client, out RestRequest request)
        {
            Client(uri, out client, out request);
            request.AddBody(body);
        }
        
        private static void ClientGet(string uri, out RestClient client, out RestRequest request)
        {
            Client(uri, out client, out request);
        }

        private static void Client(string uri, out RestClient client, out RestRequest request)
        {
            client = new RestClient("https://api.pagar.me/core/v5/");
            request = new RestRequest(uri);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("authorization", $"Basic ");
        }
    }
}