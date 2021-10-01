using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace RemoveVillain
{
    public class StartUp
    {
        private const string ConnectionString = @"Server=DESKTOP-Q72FB2M\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;";
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            int villainId = int.Parse(Console.ReadLine());

            using SqlTransaction sqlTransantion = sqlConnection.BeginTransaction();
            StringBuilder result = new StringBuilder();
            try
            {
                string getVillainNameQueryText = @"SELECT [Name]
                                                   FROM Villains
                                                   WHERE Id = @villainId";
                using SqlCommand getVillainNameCmd = new SqlCommand(getVillainNameQueryText, sqlConnection);
                getVillainNameCmd.Parameters.AddWithValue("@villainId", villainId);
                getVillainNameCmd.Transaction = sqlTransantion;
                string villainName = getVillainNameCmd.ExecuteScalar()?.ToString();

                if (villainName == null)
                {
                    Console.WriteLine("No such villain was found.");
                    return;
                }

                string releasesVillainMinionsQueryText = @"DELETE FROM MinionsVillains
                                                       WHERE VillainId = @villainId";
                using SqlCommand releasesVillainMinionsCmd = new SqlCommand(releasesVillainMinionsQueryText, sqlConnection);
                releasesVillainMinionsCmd.Parameters.AddWithValue("@villainId", villainId);
                releasesVillainMinionsCmd.Transaction = sqlTransantion;
                int minionReleased = releasesVillainMinionsCmd.ExecuteNonQuery();

                string deleteVillainQueryText = @"DELETE FROM Villains
                                                  WHERE Id = @villainId";
                using SqlCommand deleteVillainCmd = new SqlCommand(deleteVillainQueryText, sqlConnection);
                deleteVillainCmd.Parameters.AddWithValue("@villainId", villainId);
                deleteVillainCmd.Transaction = sqlTransantion;
                deleteVillainCmd.ExecuteNonQuery();

                sqlTransantion.Commit();
                result.AppendLine($"{villainName} was deleted.")
                    .AppendLine($"{minionReleased} minions were released.");

                Console.WriteLine(result.ToString().TrimEnd());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                try
                {
                    sqlTransantion.Rollback();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
    }
}
