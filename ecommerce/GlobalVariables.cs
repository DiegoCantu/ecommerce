using Microsoft.Extensions.Configuration;

namespace ecommerce
{
    public static class GlobalVariables
    {
        public static int IdUser { get; set; }
        public static string ConnectionString { get; set; }
        public static JWTParameters JWTParameters;

        public static void Setter(IConfiguration configuration)
        {
            // Get database connection string:
            ConnectionString = configuration.GetConnectionString("ConexionDatabase");
            // Get JWT Parameters:
            JWTParameters = new JWTParameters
            {
                Issuer = configuration["JWTParameters:Issuer"],
                Audience = configuration["JWTParameters:Audience"],
                SigningKey = configuration["JWTParameters:SigningKey"]
            };
        }
    }

    public class JWTParameters
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SigningKey { get; set; }
    }
}
