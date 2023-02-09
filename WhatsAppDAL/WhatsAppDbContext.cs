using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace WhatsAppDAL
{
    public class WhatsAppDbContext : IDisposable
    {
        private readonly string _connString;

        private bool _disposed;

        private SqlConnection _dbConnection = null;

        public WhatsAppDbContext():this(@"Data Source=DESKTOP-N2LHC09;Initial Catalog=WhatsappDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
            
        }

        public WhatsAppDbContext(string connString)
        {
            _connString = connString;
        }

        public async Task<SqlConnection> OpenConnection()
        {
            _dbConnection = new SqlConnection(_connString);
           await _dbConnection.OpenAsync();
           return _dbConnection;
        }

        public async Task CloseConnection()
        {
            if (_dbConnection?.State != ConnectionState.Closed)
            {
               await _dbConnection?.CloseAsync();
            }
        }


        protected virtual void Dispose(bool disposing)
        {
            WhatsAppDbContext whatsAppDbContext = new WhatsAppDbContext();
            if (_disposed)
            {
               return; 
            }

            if (disposing)
            {
                whatsAppDbContext._dbConnection.Dispose();
            }

            whatsAppDbContext._disposed = true;
        }
        public void Dispose()
        {
            WhatsAppDbContext whatsAppDbContext = new WhatsAppDbContext();
            whatsAppDbContext.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
