using System.Data.SqlClient;

namespace TTDotNetCore.ConsoleApp;

internal static class ConnectionStrings
{
    public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = "localhost",
        InitialCatalog = "DotNetTrainingBatch4",
        UserID = "sa",
        Password = "Sasa@123",
        TrustServerCertificate = true,
    };

}
