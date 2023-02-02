namespace ShoppingMVC.ClientAddress
{
    public class HttpAddress
    {
        public HttpClient Initial()
        {
            var client=new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7217/");
            return client;
        }
    }
}
