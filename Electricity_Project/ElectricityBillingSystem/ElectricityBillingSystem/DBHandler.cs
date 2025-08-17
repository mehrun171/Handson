using System.Data.SqlClient;
using System.Configuration;

public class DBHandler
{
    public static SqlConnection GetConnection()
    {
        string connStr = ConfigurationManager.ConnectionStrings["ElectricityBillDB"].ConnectionString;
        return new SqlConnection(connStr);
    }
}
