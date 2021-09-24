using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace AddMinion
{
    public class StartUp
    {
        private const string ConnectionString = @"Server=DESKTOP-Q72FB2M\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;";
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            string[] minionInput = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
            string[] minionInfo = minionInput[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string minionName = minionInfo[0];
            string minionAge = minionInfo[1];
            string minionTown = minionInfo[2];

            string[] villainInput = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
            string[] villainInfo = villainInput[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string villainName = villainInfo[0];

            StringBuilder sb = new StringBuilder();

            string getTownIdQueryText = @"SELECT Id
                                          FROM Towns
                                          WHERE [Name] = @townName";
            using SqlCommand getTownIdCmd = new SqlCommand(getTownIdQueryText, sqlConnection);
            getTownIdCmd.Parameters.AddWithValue("@townName", minionTown);

            string minionTownId = getTownIdCmd.ExecuteScalar()?.ToString();

            if (minionTownId == null)
            {
                //Add town to the database with CountyCode 1.
                string addTownQueryText = @"INSERT INTO Towns([Name],CountryCode)
                                            VALUES(@townName,@countryCode)";
                using SqlCommand addTownCmd = new SqlCommand(addTownQueryText, sqlConnection);
                addTownCmd.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("@townName",minionTown),
                    new SqlParameter("@countryCode", 1)
                });
                addTownCmd.ExecuteNonQuery();
                sb.AppendLine($"Town {minionTown} was added to the database.");
            }

            string getVillainIdQueryText = @"SELECT Id
                                             FROM Villains
                                             WHERE [Name] = @villainName";
            using SqlCommand getVillainIdCmd = new SqlCommand(getVillainIdQueryText, sqlConnection);
            getVillainIdCmd.Parameters.AddWithValue("@villainName", villainName);
            string villainId = getVillainIdCmd.ExecuteScalar()?.ToString();

            if (villainId == null)
            {
                //Add villain to the database with Evilness Factor : Evil.
                string getEvilnessFactorIdQuertText = @"SELECT Id
                                                        From EvilnessFactors
                                                        WHERE [Name] = 'Evil'";
                using SqlCommand getEvilnessFactorIdCmd = new SqlCommand(getEvilnessFactorIdQuertText, sqlConnection);
                string evilnessFactorId = getEvilnessFactorIdCmd.ExecuteScalar().ToString();

                string addVillainQueryText = @"INSERT INTO Villains([Name],EvilnessFactorId)
                                               VALUES(@villainName,@evilnessFactorId)";
                using SqlCommand addVillainCmd = new SqlCommand(addVillainQueryText, sqlConnection);
                addVillainCmd.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("@villainName",villainName),
                    new SqlParameter("@evilnessFactorId", evilnessFactorId)
                });
                addVillainCmd.ExecuteNonQuery();
                sb.AppendLine($"Villain {villainName} was added to the database.");
            }
            string townId = getTownIdCmd.ExecuteScalar().ToString();

            string addMinionQueryText = @"INSERT INTO Minions([Name],Age,TownId)
                                          VALUES(@minionName,@minionAge,@townId)";
            using SqlCommand addMinionCmd = new SqlCommand(addMinionQueryText, sqlConnection);
            addMinionCmd.Parameters.AddRange(new SqlParameter[]
            {
                    new SqlParameter("@minionName", minionName),
                    new SqlParameter("@minionAge", minionAge),
                    new SqlParameter("@townId", townId)
            });
            addMinionCmd.ExecuteNonQuery();

            string getMinionIdQueryText = @"SELECT Id
                                            FROM Minions
                                            WHERE [Name] = @minionName AND Age = @minionAge";
            using SqlCommand getMinionIdCmd = new SqlCommand(getMinionIdQueryText, sqlConnection);
            getMinionIdCmd.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter("@minionName", minionName),
                new SqlParameter("@minionAge", minionAge)
            });
            string minionId = getMinionIdCmd.ExecuteScalar().ToString();

            villainId = getVillainIdCmd.ExecuteScalar().ToString();
            string addMinionToVillainQueryText = @"INSERT INTO MinionsVillains(MinionId,VillainId)
                                                   VALUES(@minionId,@villainId)";
            using SqlCommand addMinionToVillainCmd = new SqlCommand(addMinionToVillainQueryText, sqlConnection);
            addMinionToVillainCmd.Parameters.AddWithValue("@minionId",minionId);
            addMinionToVillainCmd.Parameters.AddWithValue("@villainId", villainId);
            addMinionToVillainCmd.ExecuteNonQuery();
            sb.AppendLine($"Successfully added {minionName} to be minion of {villainName}");

            //Printing result.
            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
