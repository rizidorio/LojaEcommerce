namespace Loja.Ecommerce.Infra.Config
{
    public class ServerConfig
    {
        public MongoDbConfig MongoDb { get; set; } => new MongoDbConfig();
    }
}
