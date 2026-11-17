using System;
using System.IO;
using System.Text.Json;

namespace WinFormsApp2.Helpers
{
    public static class RememberMeStore
    {
        private static readonly string filePath =
            Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "PatientManagementSystem",
                "remember.json"
            );

        private class RememberData
        {
            public string Username { get; set; }
            public string Database { get; set; }
        }

        public static void Save(string username, string database)
        {
            string folder = Path.GetDirectoryName(filePath);

            Directory.CreateDirectory(folder);

            RememberData data = new RememberData
            {
                Username = username,
                Database = database
            };

            string json = JsonSerializer.Serialize(data);

            File.WriteAllText(filePath, json);
        }

        public static bool TryLoad(
            out string username,
            out string database)
        {
            username = "";
            database = "";

            try
            {
                if (!File.Exists(filePath))
                    return false;

                string json = File.ReadAllText(filePath);

                RememberData data =
                    JsonSerializer.Deserialize<RememberData>(json);

                if (data == null ||
                    string.IsNullOrWhiteSpace(data.Username) ||
                    string.IsNullOrWhiteSpace(data.Database))
                {
                    return false;
                }

                username = data.Username;
                database = data.Database;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void Clear()
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}