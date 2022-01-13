using Microsoft.Data.SqlClient;

namespace Blog.Services
{
    public sealed class ConnectionService
    {
        private ConnectionService() { }

        private const string CONNECTION_STRING = @"
                    Server=localhost,1433;
                    Database=blog;
                    User ID=sa;
                    Password=1q2w3e4r@#$;
                    Trusted_Connection=False;
                    TrustServerCertificate=True";
        public SqlConnection Connection => new SqlConnection(CONNECTION_STRING);
        private static readonly ConnectionService _instance;

        public static ConnectionService GetInstance() => _instance ?? new ConnectionService();
    }
}