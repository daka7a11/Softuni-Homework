using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace IncreaseAgeStoredProcedure
{
    public class StartUp
    {
        private const string ConnectionString = @"Server=DESKTOP-Q72FB2M\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;";
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            int minionId = int.Parse(Console.ReadLine());

            string procName = @"usp_GetOlder";
            using SqlCommand increaseMinionAgeCmd = new SqlCommand(procName, sqlConnection);
            increaseMinionAgeCmd.CommandType = CommandType.StoredProcedure;
            increaseMinionAgeCmd.Parameters.AddWithValue("@minionId", minionId);
            increaseMinionAgeCmd.ExecuteNonQuery();

            string getMinionQueryText = @"SELECT * FROM Minions WHERE Id=@minionId";
            using SqlCommand getMinionCmd = new SqlCommand(getMinionQueryText, sqlConnection);
            getMinionCmd.Parameters.AddWithValue("@minionId", minionId);

            using SqlDataReader reader = getMinionCmd.ExecuteReader();

            reader.Read();
            if (!reader.HasRows)
            {
                Console.WriteLine("Minion does not exists!");
            }
            else
            {
                Console.WriteLine($"{reader["Name"]} - {reader["Age"]} years old");
            }
        }
    }
}
