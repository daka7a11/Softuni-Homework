using Microsoft.Data.SqlClient;
using System;

namespace VillainNames
{
    public class StartUp
    {
        private const string ConnectionString = @"Server=DESKTOP-Q72FB2M\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;";
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            string getVillainNamesQueryText = @"SELECT v.[Name], COUNT(mv.MinionId) AS [Minions]
                                                FROM Villains AS v
                                                JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
                                                GROUP BY v.[Name]
                                                HAVING COUNT(mv.MinionId) > 3
                                                ORDER BY Minions DESC";
            using SqlCommand getVillainNamesCmd = new SqlCommand(getVillainNamesQueryText,sqlConnection);
            using SqlDataReader reader = getVillainNamesCmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["Name"]} - {reader["Minions"]}");
            }
        }
    }
}
