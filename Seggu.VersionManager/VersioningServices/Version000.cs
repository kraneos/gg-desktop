using Seggu.VersionManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seggu.VersionManager.VersioningServices
{
    public class Version000 : BaseVersioningService, IVersioningService
    {
        private readonly string tableCreationScriptFileName = "Scripts\\Version000\\TableCreation.sql";
        //private string sampleDataInsertScriptFileName = "Scripts\\Version000\\SampleDataInsert.sql";
        
        public Version000()
        {

        }

        public void ApplyVersion()
        {
            using (var connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings[Properties.Settings.Default.SegguSQLiteConnectionString].ConnectionString))
            {
                CreateDatabase();
                CreateTables(connection);
                CreateSampleData(connection);
            }
        }

        private void CreateSampleData(SQLiteConnection connection)
        {
            //base.ExecuteFileScript(connection, this.sampleDataInsertScriptFileName);
        }

        private void CreateTables(SQLiteConnection connection)
        {
            base.ExecuteFileScript(connection, this.tableCreationScriptFileName);
        }

        private void CreateDatabase()
        {
            SQLiteConnection.CreateFile(Properties.Settings.Default.DatabaseFileName);
        }
    }
}
