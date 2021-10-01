using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintAllMinionNames
{
    public class StartUp
    {
        private const string ConnectionString = @"Server=DESKTOP-Q72FB2M\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;";
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            string getAllMinionNamesQueryText = @"SELECT [Name] FROM Minions";
            using SqlCommand getAllMinionNamesCmd = new SqlCommand(getAllMinionNamesQueryText, sqlConnection);
            using SqlDataReader reader = getAllMinionNamesCmd.ExecuteReader();

            List<string> minionNames = new List<string>();

            while (reader.Read())
            {
                minionNames.Add(reader["Name"].ToString());
            }

            StringBuilder sb = new StringBuilder();
            if (minionNames.Count % 2 == 0)
            {
                for (int i = 0; i < minionNames.Count / 2; i++)
                {
                    sb.AppendLine(minionNames[i]);
                    sb.AppendLine(minionNames[minionNames.Count - 1 - i]);
                }
            }
            else
            {
                for (int i = 0; i < minionNames.Count / 2 + 1; i++)
                {
                    if (i == minionNames.Count / 2 )
                    {
                        sb.AppendLine(minionNames[i]);
                    }
                    else
                    {
                        sb.AppendLine(minionNames[i]);
                        sb.AppendLine(minionNames[minionNames.Count - 1 - i]);
                    }
                }
            }
            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
