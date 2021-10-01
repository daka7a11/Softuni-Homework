using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace ChangeTownNamesCasing
{
    public class StartUp
    {
        private const string ConnectionString = @"Server=DESKTOP-Q72FB2M\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;";
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            StringBuilder result = new StringBuilder();

            string countryName = Console.ReadLine();

            string getCountryIdQueryText = @"SELECT Id
                                             FROM Countries
                                             WHERE [Name] = @countryName";
            using SqlCommand getCountryIdCmd = new SqlCommand(getCountryIdQueryText, sqlConnection);
            getCountryIdCmd.Parameters.AddWithValue("@countryName", countryName);

            string countryId = getCountryIdCmd.ExecuteScalar()?.ToString();

            if (countryId == null)
            {
                Console.WriteLine("No town names were affected.");
                return;
            }

            string updateTownNamesToUpperCaseQueryText = @"UPDATE Towns
                                                           SET [Name] = UPPER([Name])
                                                           WHERE CountryCode = @countryId";
            using SqlCommand updateTownNameToUpperCaseCmd = new SqlCommand(updateTownNamesToUpperCaseQueryText,sqlConnection);
            updateTownNameToUpperCaseCmd.Parameters.AddWithValue("@countryId",countryId);

            int rowAffected = updateTownNameToUpperCaseCmd.ExecuteNonQuery();
            if (rowAffected < 1)
            {
                Console.WriteLine("No town names were affected.");
                return;
            }

            result.AppendLine($"{rowAffected} town names were affected.");

            string getTownsFromCountryQueryText = @"SELECT *
                                                    FROM Towns
                                                    WHERE CountryCode = @countryId";
            using SqlCommand getTownsFromCountryCmd = new SqlCommand(getTownsFromCountryQueryText, sqlConnection);
            getTownsFromCountryCmd.Parameters.AddWithValue("@countryId", countryId);

            using SqlDataReader reader = getTownsFromCountryCmd.ExecuteReader();

            if (!reader.HasRows)
            {
                Console.WriteLine("No town names were affected.");
                return;
            }
            result.Append("[");
            for (int i = 0; i < rowAffected; i++)
            {
                reader.Read();
                if (i+1==rowAffected)
                {
                    result.Append(reader["Name"]);
                }
                else
                {
                    result.Append($"{reader["Name"]}, ");
                }
            }
            result.Append("]");
            Console.WriteLine(result.ToString().TrimEnd());
        }
    }
}
