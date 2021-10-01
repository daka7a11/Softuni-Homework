using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Text;

namespace IncreaseMinionAge
{
    public class StartUp
    {
        private const string ConnectionString = @"Server=DESKTOP-Q72FB2M\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;";
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            int[] minionIds = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string increaseMinionAgeQueryText = @"UPDATE Minions
                                                  SET Age += 1
                                                  WHERE Id = @minionId";
            for (int i = 0; i < minionIds.Length; i++)
            {
                using SqlCommand increaseMinionAgeCmd = new SqlCommand(increaseMinionAgeQueryText, sqlConnection);
                increaseMinionAgeCmd.Parameters.AddWithValue("@minionId", minionIds[i]);

                increaseMinionAgeCmd.ExecuteNonQuery();
            }

            string getMinionsQueryText = @"SELECT * FROM Minions";
            using SqlCommand getMinionsCmd = new SqlCommand(getMinionsQueryText, sqlConnection);

            using SqlDataReader reader = getMinionsCmd.ExecuteReader();

            StringBuilder sb = new StringBuilder();

            while (reader.Read())
            {
                sb.AppendLine($"{reader["Name"]} {reader["Age"]}");
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
