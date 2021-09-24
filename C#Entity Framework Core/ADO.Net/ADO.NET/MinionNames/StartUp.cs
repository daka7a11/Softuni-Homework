using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace MinionNames
{
    public class StartUp
    {
        private const string ConnectionString = @"Server=DESKTOP-Q72FB2M\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;";
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            string getVillainNameQueryText = @"SELECT v.Name
                                      FROM Villains AS v
                                      WHERE v.Id = @villainId";

            string villainId = Console.ReadLine();

            using SqlCommand getVillaionNameCmd = new SqlCommand(getVillainNameQueryText, sqlConnection);
            getVillaionNameCmd.Parameters.AddWithValue("@villainId", villainId);
            string villainName = getVillaionNameCmd.ExecuteScalar()?.ToString();

            if (villainName == null)
            {
                Console.WriteLine($"No villain with Id {villainId} exists in the database.");
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Villain: {villainName}");

            string getVillainMinionsQueryText = @"SELECT m.[Name], m.Age
                                                  FROM Villains AS v
                                                  JOIN MinionsVillains AS mv ON v.Id=mv.VillainId
                                                  JOIN Minions AS m ON mv.MinionId = m.Id
                                                  WHERE v.Id = @villainId";
            using SqlCommand getVillainMinionsCmd = new SqlCommand(getVillainMinionsQueryText, sqlConnection);
            getVillainMinionsCmd.Parameters.AddWithValue("@villainId", villainId);

            SqlDataReader reader = getVillainMinionsCmd.ExecuteReader();

            if (!reader.HasRows)
            {
                sb.AppendLine($"(no minions)");
            }

            int row = 1;
       
            while (reader.Read())
            {
                sb.AppendLine($"{row}. {reader["Name"]} {reader["Age"]}");
                row++;
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
