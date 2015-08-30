using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;

namespace Seggu.VersionManager.VersioningServices
{
    public class BaseVersioningService
    {
        protected void ExecuteFileScript(SQLiteConnection connection, string fileName)
        {
            try
            {
                var commandText = File.ReadAllText(fileName);
                var command = new SQLiteCommand(commandText, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
