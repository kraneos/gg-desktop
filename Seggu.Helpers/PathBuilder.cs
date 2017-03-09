using System;
using System.IO;

namespace Seggu.Helpers
{
    public static class PathBuilder
    {
        public static string ValidateClientPath(string categoryPath, string dateFolderPath, string clientName)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory + @"SeGGu PDFs";
            if (!(Directory.Exists(basePath)))
                Directory.CreateDirectory(basePath);

            string clientNamePath = Path.Combine(basePath, categoryPath, dateFolderPath, clientName);
            if (!(Directory.Exists(clientNamePath)))
                Directory.CreateDirectory(clientNamePath);

            return clientNamePath;
        }

    }
}
